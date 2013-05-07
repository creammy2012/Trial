using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data;

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
 

    //Web method to verify a person's identity. If the given credentials match then the verification method reutrns true, If not,it returns false,
    [WebMethod]
    public string verify(Person obj)
    {
        TRN.Service trnSv = new TRN.Service();
        National.Service nationalSv = new National.Service();
        passport.Service passportSv = new passport.Service();
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        if (string.IsNullOrEmpty(obj.TRN) && string.IsNullOrEmpty(obj.NAtionID) && string.IsNullOrEmpty(obj.Passport))//checks if all fields are empty
        {
            return "You must enter at least one of the following (TRN, Passport # or, National ID)";
        }
        else
        {
            if (!string.IsNullOrEmpty(obj.TRN) && !string.IsNullOrEmpty(obj.NAtionID) && !string.IsNullOrEmpty(obj.Passport))//checks if at least one field has information
            {
                if (trnCheck(obj) && nisCheck(obj) && PassportCheck(obj))
                {

                    return "verification successful";
                }
                else
                {
                    return "The credentials did not match up correctly";
                }
            }
            else
                if (!string.IsNullOrEmpty(obj.TRN) && !string.IsNullOrEmpty(obj.NAtionID))//checks the given information
                {
                    if (trnCheck(obj) && nisCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
                else if (!string.IsNullOrEmpty(obj.TRN) && !string.IsNullOrEmpty(obj.Passport))//checks the given information
                {
                    if (trnCheck(obj) && PassportCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
                else if (!string.IsNullOrEmpty(obj.NAtionID) && !string.IsNullOrEmpty(obj.Passport))//checks the given information
                {
                    if (nisCheck(obj) && PassportCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
                else if (!string.IsNullOrEmpty(obj.TRN) && string.IsNullOrEmpty(obj.NAtionID) && string.IsNullOrEmpty(obj.Passport))//checks the given information
                {
                    if (trnCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
                else if (string.IsNullOrEmpty(obj.TRN) && !string.IsNullOrEmpty(obj.NAtionID) && string.IsNullOrEmpty(obj.Passport))//checks the given information
                {
                    if (nisCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
                else if (string.IsNullOrEmpty(obj.TRN) && string.IsNullOrEmpty(obj.NAtionID) && !string.IsNullOrEmpty(obj.Passport))//checks the given information
                {
                    if (PassportCheck(obj))
                    {
                        return "verification successful";
                    }
                    else
                    {
                        return "The credentials did not match up correctly";
                    }
                }
        }
        return "verification failed";
    }

    //If the trn provided was true then a text message is sent out to the person stating that the transaction made is successful
    //If the trn provided was false then a text message will be sent out that a transaction was attempted using various personal information along with the location, time and date etc
    protected bool trnCheck(Person obj)
    {
        TRN.Service trnSv = new TRN.Service();
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        TRN.Trn t = null;

        Person person = (from p in db.Persons
                         where p.TRN == obj.TRN && p.Fname == obj.Fname && obj.Lname == p.Lname &&
                    (obj.MiddleName == p.MiddleName || p.MotherMaiden == obj.MotherMaiden)
                         select p).SingleOrDefault();

        if (person == null)
        {
            t = (from trn in trnSv.selectAllTrn()
                 where trn.TrnNum.ToString() == obj.TRN &&
                     trn.Fname == obj.Fname && obj.Lname == trn.Lname &&
                     (obj.MiddleName == trn.MiddleName || trn.MotherMaiden == obj.MotherMaiden)
                 select trn).SingleOrDefault();
            
            if (t == null)
            {

                //send text message asking informing the person that some one is trying to make a transaction using their credentials and they should verify with the following institution
                return false;//"The credentials could not be verified.";
            }
            else
            {
                //Send Text message that there was a match and they should confirm that they are making the transaction
                return true;//"The credentials verified successfully.";
            }
        }
        else
        {
            //Send Text message that there was a match and they should confirm that they are making the transaction
            return true;// "The credentials verified successfully.";
        }
    }

    //If the National ID provided was true then a text message is sent out to the person stating that the transaction made is successful
    //If the National ID provided was false then a text message will be sent out that a transaction was attempted using various personal information along with the location, time and date etc
    protected bool nisCheck(Person obj)
    {
        National.Service natSv = new National.Service();
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        National.NatID n = null;

        Person person = (from p in db.Persons
                         where p.NAtionID == obj.NAtionID && p.Fname == obj.Fname && obj.Lname == p.Lname &&
                    (obj.MiddleName == p.MiddleName || p.MotherMaiden == obj.MotherMaiden)
                         select p).SingleOrDefault();

        if (person == null)
        {
            n = (from nat in natSv.selectAllNatID()
                 where nat.NatIDNum.ToString() == obj.NAtionID &&
                     nat.Fname == obj.Fname && obj.Lname == nat.Lname &&
                     (obj.MiddleName == nat.MiddleName || nat.MotherMaiden == obj.MotherMaiden)
                 select nat).SingleOrDefault();
            if (n == null)
            {
                //send text message asking informing the person that some one is trying to make a transaction using their credentials and they should verify with the following institution
                return false;//"The credentials could not be verified.";
            }
            else
            {
                //Send Text message that there was a match and they should confirm that they are making the transaction
                return true;//"The credentials verified successfully.";
            }
        }
        else
        {
            //Send Text message that there was a match and they should confirm that they are making the transaction
            return true;// "The credentials verified successfully.";
        }
    }

    //If the Passport Number provided was true then a text message is sent out to the person stating that the transaction made is successful
    //If the Passport Number was false then a text message will be sent out that a transaction was attempted using various personal information along with the location, time and date etc
    protected bool PassportCheck(Person obj)
    {
        passport.Service passportSv = new passport.Service();
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        passport.Passport pas = null;

        Person person = (from p in db.Persons
                         where p.Passport == obj.Passport && p.Fname == obj.Fname && obj.Lname == p.Lname &&
                    (obj.MiddleName == p.MiddleName || p.MotherMaiden == obj.MotherMaiden)
                         select p).SingleOrDefault();

        if (person == null)
        {
            pas = (from pass in passportSv.selectAllPassport()
                   where pass.PassportNum.ToString() == obj.Passport &&
                       pass.Fname == obj.Fname && obj.Lname == pass.Lname &&
                       (obj.MiddleName == pass.MiddleName || pass.MotherMaiden == obj.MotherMaiden)
                   select pass).SingleOrDefault();
            if (pas == null)
            {
                //send text message asking informing the person that some one is trying to make a transaction using their credentials and they should verify with the following institution
                return false;//"The credentials could not be verified.";
            }
            else
            {
                //Send Text message that there was a match and they should confirm that they are making the transaction
                return true;//"The credentials verified successfully.";
            }
        }
        else
        {
            //Send Text message that there was a match and they should confirm that they are making the transaction
            return true;// "The credentials verified successfully.";
        }
    }


    //[WebMethod]
    //public string insertPerson(Person obj)
    //{
    //    IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
    //    if (obj.TRN == string.Empty && obj.NAtionID == string.Empty && obj.Passport == string.Empty)
    //    {
    //        return "You must enter at least one of the following (TRN, Passport # or, National ID)";
    //    }
    //    else
    //    {
    //        db.Persons.InsertOnSubmit(obj);
    //        if (Submit(db))
    //        {
    //            return "Person saved successfully";
    //        }
    //    }
    //    return "Error saving person";
    //}

    //method to update person table
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
                    a.TRN = obj.TRN;
                    a.Passport = obj.Passport;
                    a.NAtionID = obj.NAtionID;
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

    //[WebMethod]
    //public bool deletePerson(Person obj)
    //{
    //    IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
    //    var del = (from ob in db.Persons
    //               where ob.CustID == obj.CustID
    //               select ob).Single();
    //    db.Persons.DeleteOnSubmit(del);
    //    return Submit(db);
    //}

    //Web method to select all persons from the database

    //METHOD to select all persons
    [WebMethod]
    public List<SelectAllPersonResult> selectAllPerson()
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        return db.SelectAllPerson().ToList();
        //List<Person> obj = new List<Person>();
        //foreach (SelectAllPersonResult ar in db.SelectAllPerson())
        //{
        //    obj.Add(new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum });
        //}
        //return obj;
    }

    //method to select all persons by ID
    [WebMethod]
    public SelectAllPersonByIdResult selectPersonById(int CustID)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        return db.SelectAllPersonById(CustID).SingleOrDefault();
        //Person obj = new Person();
        //foreach (SelectAllPersonByIdResult ar in db.SelectAllPersonById(CustID))
        //{
        //    obj = new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum };
        //}
        //return obj;
    }

    //returns person
    [WebMethod]
    public List<PersonQueryResult> PersonQuery(string query)
    {
        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();
        return db.PersonQuery(query).ToList();
        //List<Person> obj = new List<Person>();
        //foreach (PersonQueryResult ar in db.PersonQuery(query))
        //{
        //    obj.Add(new Person() { CustID = ar.CustID, Fname = ar.Fname, MiddleName = ar.MiddleName, Lname = ar.Lname, DOB = ar.DOB, Gender = ar.Gender, Addr = ar.Addr, MotherMaiden = ar.MotherMaiden, Email = ar.Email, CellNum = ar.CellNum });
        //}
        //return obj;
    }

    //Method to update the Identifier Database with the most recent information from the external databases
    [WebMethod]
    public void updateIdentfiersDb()
    {

        TRN.Service trnSv = new TRN.Service();
        National.Service nationalSv = new National.Service();
        passport.Service passportSv = new passport.Service();

        IDENTIFIERSDataContext db = new IDENTIFIERSDataContext();

        List<Person> personList = (from p in db.Persons select p).ToList();
        List<TRN.Trn> allNewTrns = trnSv.selectAllTrn().Where(val => !personList.Select(v => v.TRN).Contains(val.TrnNum.ToString())).ToList();

        foreach (TRN.Trn t in allNewTrns)
        {
            Person p = (from val in personList
                        where t.Fname == val.Fname && val.Lname == t.Lname &&
                            (val.MiddleName == t.MiddleName || t.MotherMaiden == val.MotherMaiden)
                        select val).SingleOrDefault();
            if (p != null)
            {
                p.TRN = t.TrnNum.ToString();
            }
            else
            {
                Person newPerson = new Person() { TRN = t.TrnNum.ToString(), DOB = t.DOB.HasValue ? t.DOB.Value : DateTime.MinValue, Fname = t.Fname, Gender = t.Gender, Lname = t.Lname, MiddleName = t.MiddleName, MotherMaiden = t.MotherMaiden };
                personList.Add(newPerson);
                db.Persons.InsertOnSubmit(newPerson);
            }
        }

        List<National.NatID> allNewNationals = nationalSv.selectAllNatID().Where(val => !personList.Select(v => v.NAtionID).Contains(val.NatIDNum.ToString())).ToList();
        foreach (National.NatID n in allNewNationals)
        {
            Person p = (from val in personList
                        where n.Fname == val.Fname && val.Lname == n.Lname &&
                            (val.MiddleName == n.MiddleName || n.MotherMaiden == val.MotherMaiden)
                        select val).SingleOrDefault();
            if (p != null)
            {
                p.NAtionID = n.NatIDNum.ToString();
            }
            else
            {
                Person newPerson = new Person() { NAtionID = n.NatIDNum.ToString(), DOB = n.DOB.HasValue ? n.DOB.Value : DateTime.MinValue, Fname = n.Fname, Gender = n.Gender, Lname = n.Lname, MiddleName = n.MiddleName, MotherMaiden = n.MotherMaiden };
                personList.Add(newPerson);
                db.Persons.InsertOnSubmit(newPerson);
            }
        }
        List<passport.Passport> allNewPassports = passportSv.selectAllPassport().Where(val => !personList.Select(v => v.Passport).Contains(val.PassportNum.ToString())).ToList();
        foreach (passport.Passport pas in allNewPassports)
        {
            Person p = (from val in personList
                        where pas.Fname == val.Fname && val.Lname == pas.Lname &&
                             (val.MiddleName == pas.MiddleName || pas.MotherMaiden == val.MotherMaiden)
                        select val).SingleOrDefault();
            if (p != null)
            {
                p.Passport = pas.PassportNum.ToString();
                p.Email = pas.EmailAddr;
                if (pas.CellNum.HasValue)
                    p.CellNum = pas.CellNum.Value;
            }
            else
            {
                int id = -1;
                if (pas.CellNum.HasValue)
                    id = pas.CellNum.Value;
                Person newPerson = new Person()
                {
                    Addr = pas.StreetName,
                    Passport = pas.PassportNum.ToString(),
                    DOB = pas.DOB.HasValue ? pas.DOB.Value : DateTime.MinValue,
                    Fname = pas.Fname,
                    Gender = pas.Gender,
                    Lname = pas.Lname,
                    MiddleName = pas.MiddleName,
                    MotherMaiden = pas.MotherMaiden,
                    Email = pas.EmailAddr,
                    CellNum = id
                };
                db.Persons.InsertOnSubmit(newPerson);
            }
        }
        db.SubmitChanges();
    }

    #endregion

}
