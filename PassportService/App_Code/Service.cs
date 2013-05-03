using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.Linq;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    #region FUNCTIONS
    public bool submitUpdate(PASSPORTDataContext db)
    {
        try
        {
            db.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        catch (ChangeConflictException ex)
        {
            foreach (ObjectChangeConflict occ in db.ChangeConflicts)
            {
                occ.Resolve(RefreshMode.OverwriteCurrentValues);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
    private bool Submit(PASSPORTDataContext db)
    {
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            db.Dispose();
        }
    }
    public string IsEmpty(string data, string old)
    {
        return data.Trim() == string.Empty ? old : data;
    }
    public Guid toGuid(string id)
    {
        Guid newGuid = new Guid(id);
        return newGuid;
    }
    #endregion
    #region Passport
    [WebMethod]
    public bool insertPassport(Passport obj)
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        db.Passports.InsertOnSubmit(obj);
        return Submit(db);
    }
    [WebMethod]
    public bool updatePassport(Passport obj)
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        IQueryable<Passport> upSection = (from passport in db.Passports
                                          where passport.PassportNum == obj.PassportNum
                                          select passport);
        try
        {
            if (upSection.ToArray().Length > 0)
            {
                foreach (Passport a in upSection)
                {
                    a.PassportNum = obj.PassportNum;
                    a.Fname = obj.Fname;
                    a.MiddleName = obj.MiddleName;
                    a.Lname = obj.Lname;
                    a.DOB = obj.DOB;
                    a.Gender = obj.Gender;
                    a.Nationality = obj.Nationality;
                    a.CountryOfBirth = obj.CountryOfBirth;
                    a.CellNum = obj.CellNum;
                    a.EmailAddr = obj.EmailAddr;
                    a.StreetNum = obj.StreetNum;
                    a.StreetName = obj.StreetName;
                    a.City = obj.City;
                    a.Parish = obj.Parish;
                    a.MotherMaiden = obj.MotherMaiden;
                    a.DateIssued = obj.DateIssued;
                    a.DateExpired = obj.DateExpired;
                }
                return submitUpdate(db);
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    [WebMethod]
    public bool deletePassport(Passport obj)
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        var del = (from ob in db.Passports
                   where ob.PassportNum == obj.PassportNum
                   select ob).Single();
        db.Passports.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<Passport> selectAllPassport()
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        List<Passport> obj = new List<Passport>();
        foreach (SelectAllPassportResult ar in db.SelectAllPassport())
        {
            obj.Add(new Passport() { PassportNum = ar.PassportNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired });
        }
        return obj;
    }

    [WebMethod]
    public Passport selectPassportById(int PassportNum)
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        Passport obj = new Passport();
        foreach (SelectAllPassportByIdResult ar in db.SelectAllPassportById(PassportNum))
        {
            obj = new Passport() { PassportNum = ar.PassportNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired };
        }
        return obj;
    }

    [WebMethod]
    public List<Passport> PassportQuery(string query)
    {
        PASSPORTDataContext db = new PASSPORTDataContext();
        List<Passport> obj = new List<Passport>();
        foreach (PassportQueryResult ar in db.PassportQuery(query))
        {
            obj.Add(new Passport() { PassportNum = ar.PassportNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired });
        }
        return obj;
    }
    #endregion

}
