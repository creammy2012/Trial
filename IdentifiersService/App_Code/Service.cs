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
    #region FUNCTIONS
    public bool submitUpdate(IDENTIFIERSDataContext db)
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
    private bool Submit(IDENTIFIERSDataContext db)
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

    public Service()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Person
    [WebMethod]
    public bool insertPerson(Person obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        db.Persons.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updatePerson(Person obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        IQueryable<Person> upSection = (from person in db.Persons
                                        where person.CustID == obj.CustID
                                        select person);
        try
        {
            if (upSection.ToArray().Length > 0)
            {
                foreach (Person a in upSection)
                {
                    a.CustID = obj.CustID;
                    a.Fname = obj.Fname;
                    a.MiddleName = obj.MiddleName;
                    a.Lname = obj.Lname;
                    a.DOB = obj.DOB;
                    a.Gender = obj.Gender;
                    a.Addr = obj.Addr;
                    a.MotherMaiden = obj.MotherMaiden;
                    a.Email = obj.Email;
                    a.CellNum = obj.CellNum;
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
    public bool deletePerson(Person obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        var del = (from ob in db.Persons
                   where ob.CustID == obj.CustID
                   select ob).Single();
        db.Persons.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<Person> selectAllPerson()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Person> obj = new List<Person>();
        foreach (SelectAllPersonResult ar in db.SelectAllPerson())
        {
            obj.Add(new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum });
        }
        return obj;
    }

    [WebMethod]
    public Person selectPersonById(int CustID)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        Person obj = new Person();
        foreach (SelectAllPersonByIdResult ar in db.SelectAllPersonById(CustID))
        {
            obj = new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum };
        }
        return obj;
    }

    [WebMethod]
    public List<Person> PersonQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Person> obj = new List<Person>();
        foreach (PersonQueryResult ar in db.PersonQuery(query))
        {
            obj.Add(new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum });
        }
        return obj;
    }

    #endregion

    #region Passport
    [WebMethod]
    public bool insertPassport(Passport obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        db.Passports.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updatePassport(Passport obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
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
                    a.CustID = obj.CustID;
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
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        var del = (from ob in db.Passports
                   where ob.PassportNum == obj.PassportNum
                   select ob).Single();
        db.Passports.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<Passport> selectAllPassport()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Passport> obj = new List<Passport>();
        foreach (SelectAllPassportResult ar in db.SelectAllPassport())
        {
            obj.Add(new Passport() { PassportNum = ar.PassportNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired });
        }
        return obj;
    }

    [WebMethod]
    public Passport selectPassportById(int PassportNum)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        Passport obj = new Passport();
        foreach (SelectAllPassportByIdResult ar in db.SelectAllPassportById(PassportNum))
        {
            obj = new Passport() { PassportNum = ar.PassportNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired };
        }
        return obj;
    }

    [WebMethod]
    public List<Passport> PassportQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Passport> obj = new List<Passport>();
        foreach (PassportQueryResult ar in db.PassportQuery(query))
        {
            obj.Add(new Passport() { PassportNum = ar.PassportNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Nationality = ar.Nationality, CountryOfBirth = ar.CountryOfBirth, CellNum = ar.CellNum, EmailAddr = ar.EmailAddr, StreetNum = ar.StreetNum, StreetName = ar.StreetName, City = ar.City, Parish = ar.Parish, MotherMaiden = ar.MotherMaiden, DateIssued = ar.DateIssued, DateExpired = ar.DateExpired });
        }
        return obj;
    }
    #endregion

    #region NatID
    
    [WebMethod]
    public bool insertNatID(NatID obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        db.NatIDs.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updateNatID(NatID obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        IQueryable<NatID> upSection = (from natid in db.NatIDs
                                       where natid.NatIDNum == obj.NatIDNum
                                       select natid);
        try
        {
            if (upSection.ToArray().Length > 0)
            {
                foreach (NatID a in upSection)
                {
                    a.NatIDNum = obj.NatIDNum;
                    a.CustID = obj.CustID;
                    a.Fname = obj.Fname;
                    a.MiddleName = obj.MiddleName;
                    a.Lname = obj.Lname;
                    a.DOB = obj.DOB;
                    a.Gender = obj.Gender;
                    a.MotherMaiden = obj.MotherMaiden;
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
    public bool deleteNatID(NatID obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        var del = (from ob in db.NatIDs
                   where ob.NatIDNum == obj.NatIDNum
                   select ob).Single();
        db.NatIDs.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<NatID> selectAllNatID()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<NatID> obj = new List<NatID>();
        foreach (SelectAllNatIDResult ar in db.SelectAllNatID())
        {
            obj.Add(new NatID() { NatIDNum = ar.NatIDNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    [WebMethod]
    public NatID selectNatIDById(int NatIDNum)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        NatID obj = new NatID();
        foreach (SelectAllNatIDByIdResult ar in db.SelectAllNatIDById(NatIDNum))
        {
            obj = new NatID() { NatIDNum = ar.NatIDNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden };
        }
        return obj;
    }

    [WebMethod]
    public List<NatID> NatIDQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<NatID> obj = new List<NatID>();
        foreach (NatIDQueryResult ar in db.NatIDQuery(query))
        {
            obj.Add(new NatID() { NatIDNum = ar.NatIDNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    #endregion

    #region DataPull

    [WebMethod]
    public bool insertDataPull(DataPull obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        db.DataPulls.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updateDataPull(DataPull obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        IQueryable<DataPull> upSection = (from datapull in db.DataPulls
                                          where datapull.DataID == obj.DataID
                                          select datapull);
        try
        {
            if (upSection.ToArray().Length > 0)
            {
                foreach (DataPull a in upSection)
                {
                    a.DataID = obj.DataID;
                    a.CustID = obj.CustID;
                    a.NatIDNum = obj.NatIDNum;
                    a.PassportNum = obj.PassportNum;
                    a.TrnNum = obj.TrnNum;
                    a.TimePull = obj.TimePull;
                    a.TimeUpdate = obj.TimeUpdate;
                    a.Fname = obj.Fname;
                    a.MiddleName = obj.MiddleName;
                    a.Lname = obj.Lname;
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
    public bool deleteDataPull(DataPull obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        var del = (from ob in db.DataPulls
                   where ob.DataID == obj.DataID
                   select ob).Single();
        db.DataPulls.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<DataPull> selectAllDataPull()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<DataPull> obj = new List<DataPull>();
        foreach (SelectAllDataPullResult ar in db.SelectAllDataPull())
        {
            obj.Add(new DataPull() { DataID = ar.DataID, CustID = ar.CustID, NatIDNum = ar.NatIDNum, PassportNum = ar.PassportNum, TrnNum = ar.TrnNum, TimePull = ar.TimePull, TimeUpdate = ar.TimeUpdate, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname });
        }
        return obj;
    }

    [WebMethod]
    public DataPull selectDataPullById(int DataID)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        DataPull obj = new DataPull();
        foreach (SelectAllDataPullByIdResult ar in db.SelectAllDataPullById(DataID))
        {
            obj = new DataPull() { DataID = ar.DataID, CustID = ar.CustID, NatIDNum = ar.NatIDNum, PassportNum = ar.PassportNum, TrnNum = ar.TrnNum, TimePull = ar.TimePull, TimeUpdate = ar.TimeUpdate, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname };
        }
        return obj;
    }

    [WebMethod]
    public List<DataPull> DataPullQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<DataPull> obj = new List<DataPull>();
        foreach (DataPullQueryResult ar in db.DataPullQuery(query))
        {
            obj.Add(new DataPull() { DataID = ar.DataID, CustID = ar.CustID, NatIDNum = ar.NatIDNum, PassportNum = ar.PassportNum, TrnNum = ar.TrnNum, TimePull = ar.TimePull, TimeUpdate = ar.TimeUpdate, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname });
        }
        return obj;
    }
    #endregion

    #region Trn
    [WebMethod]
    public bool insertTrn(Trn obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        db.Trns.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updateTrn(Trn obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        IQueryable<Trn> upSection = (from trn in db.Trns
                                     where trn.TrnNum == obj.TrnNum
                                     select trn);
        try
        {
            if (upSection.ToArray().Length > 0)
            {
                foreach (Trn a in upSection)
                {
                    a.TrnNum = obj.TrnNum;
                    a.CustID = obj.CustID;
                    a.Fname = obj.Fname;
                    a.MiddleName = obj.MiddleName;
                    a.Lname = obj.Lname;
                    a.DOB = obj.DOB;
                    a.Gender = obj.Gender;
                    a.MotherMaiden = obj.MotherMaiden;
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
    public bool deleteTrn(Trn obj)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        var del = (from ob in db.Trns
                   where ob.TrnNum == obj.TrnNum
                   select ob).Single();
        db.Trns.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<Trn> selectAllTrn()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Trn> obj = new List<Trn>();
        foreach (SelectAllTrnResult ar in db.SelectAllTrn())
        {
            obj.Add(new Trn() { TrnNum = ar.TrnNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    [WebMethod]
    public Trn selectTrnById(int TrnNum)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        Trn obj = new Trn();
        foreach (SelectAllTrnByIdResult ar in db.SelectAllTrnById(TrnNum))
        {
            obj = new Trn() { TrnNum = ar.TrnNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden };
        }
        return obj;
    }

    [WebMethod]
    public List<Trn> TrnQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        List<Trn> obj = new List<Trn>();
        foreach (TrnQueryResult ar in db.TrnQuery(query))
        {
            obj.Add(new Trn() { TrnNum = ar.TrnNum, CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }
    #endregion

}
