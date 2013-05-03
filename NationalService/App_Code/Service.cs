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
    public bool submitUpdate(NATIONALDataContext db)
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
    private bool Submit(NATIONALDataContext db)
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
    #region NatID

    [WebMethod]
    public bool insertNatID(NatID obj)
    {
        NATIONALDataContext db = new NATIONALDataContext();
        db.NatIDs.InsertOnSubmit(obj);
        return Submit(db);
    }

    [WebMethod]
    public bool updateNatID(NatID obj)
    {
        NATIONALDataContext db = new NATIONALDataContext();
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
        NATIONALDataContext db = new NATIONALDataContext();
        var del = (from ob in db.NatIDs
                   where ob.NatIDNum == obj.NatIDNum
                   select ob).Single();
        db.NatIDs.DeleteOnSubmit(del);
        return Submit(db);
    }

    [WebMethod]
    public List<NatID> selectAllNatID()
    {
        NATIONALDataContext db = new NATIONALDataContext();
        List<NatID> obj = new List<NatID>();
        foreach (SelectAllNatIDResult ar in db.SelectAllNatID())
        {
            obj.Add(new NatID() { NatIDNum = ar.NatIDNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    [WebMethod]
    public NatID selectNatIDById(int NatIDNum)
    {
        NATIONALDataContext db = new NATIONALDataContext();
        NatID obj = new NatID();
        foreach (SelectAllNatIDByIdResult ar in db.SelectAllNatIDById(NatIDNum))
        {
            obj = new NatID() { NatIDNum = ar.NatIDNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden };
        }
        return obj;
    }

    [WebMethod]
    public List<NatID> NatIDQuery(string query)
    {
        NATIONALDataContext db = new NATIONALDataContext();
        List<NatID> obj = new List<NatID>();
        foreach (NatIDQueryResult ar in db.NatIDQuery(query))
        {
            obj.Add(new NatID() { NatIDNum = ar.NatIDNum, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, MotherMaiden = ar.MotherMaiden });
        }
        return obj;
    }

    #endregion

}
