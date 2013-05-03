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
    public bool submitUpdate(TRNDataContext db)
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
    private bool Submit(TRNDataContext db)
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
    #region Trn
   // [WebMethod]
    public bool insertTrn(Trn obj)
    {
        TRNDataContext db = new TRNDataContext();
        db.Trns.InsertOnSubmit(obj);
        return Submit(db);
    }

    //[WebMethod]
    public bool updateTrn(Trn obj)
    {
        TRNDataContext db = new TRNDataContext();
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

   // [WebMethod]
    public bool deleteTrn(Trn obj)
    {
        TRNDataContext db = new TRNDataContext();
        var del = (from ob in db.Trns
                   where ob.TrnNum == obj.TrnNum
                   select ob).Single();
        db.Trns.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<Trn> selectAllTrn()
    {
        TRNDataContext db = new TRNDataContext();
        List<Trn> obj = new List<Trn>();
        foreach (SelectAllTrnResult ar in db.SelectAllTrn())
        {
            obj.Add(new Trn() { TrnNum = ar.TrnNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    [WebMethod]
    public Trn selectTrnById(int TrnNum)
    {
        TRNDataContext db = new TRNDataContext();
        Trn obj = new Trn();
        foreach (SelectAllTrnByIdResult ar in db.SelectAllTrnById(TrnNum))
        {
            obj = new Trn() { TrnNum = ar.TrnNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden };
        }
        return obj;
    }

    [WebMethod]
    public List<Trn> TrnQuery(string query)
    {
        TRNDataContext db = new TRNDataContext();
        List<Trn> obj = new List<Trn>();
        foreach (TrnQueryResult ar in db.TrnQuery(query))
        {
            obj.Add(new Trn() { TrnNum = ar.TrnNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    #endregion

}
