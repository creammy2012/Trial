using Identifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
//using Identifiers;

/// <summary>
/// Summary description for BAL
/// </summary>

[DataObject(true)]	
public static class BAL
{
    //by person 
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Identifiers.SelectAllPersonByIdResult selectPersonById(int CustId)
    {
        Identifiers.Service svc = new Identifiers.Service();
        return svc.selectPersonById(CustId);
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<SelectAllPersonResult> selectAllPerson()
    {
        Identifiers.Service svc = new Identifiers.Service();
        return svc.selectAllPerson().ToList();
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static bool updatePerson(Person obj)
    {
        Identifiers.Service svc = new Identifiers.Service();
        return svc.updatePerson(obj);
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static string InsertPerson(Person obj)
    {
        Identifiers.Service svc = new Identifiers.Service();
        return svc.insertPerson(obj);
    }
    ////by passport
    //[DataObjectMethod(DataObjectMethodType.Update)]
    //public static bool updatePassport(Identifiers.Passport obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.updatePassport(obj);
    //}

    //[DataObjectMethod(DataObjectMethodType.Insert)]
    //public static bool InsertPassport(Passport obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.insertPassport(obj);
    //}
    //trn
    //[DataObjectMethod(DataObjectMethodType.Select)]
    //public static Trn selectTrnbyId(int TrnNum)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.selectTrnById(TrnNum);
    //}

    //[DataObjectMethod(DataObjectMethodType.Update)]
    //public static bool updattrn(Trn obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.updateTrn(obj);
    //}

    //[DataObjectMethod(DataObjectMethodType.Insert)]
    //public static bool InsertTrn(Trn obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.insertTrn(obj);
    //}
    ////by nationId
    //[DataObjectMethod(DataObjectMethodType.Select)]
    //public static NatID selectNatIDById(int NatIdNum)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.selectNatIDById(NatIdNum);
    //}

    //[DataObjectMethod(DataObjectMethodType.Update)]
    //public static bool updatNational(NatID obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.updateNatID(obj);
    //}

    //[DataObjectMethod(DataObjectMethodType.Insert)]
    //public static bool insertNatID(NatID obj)
    //{
    //    Identifiers.Service svc = new Service();
    //    return svc.insertNatID(obj);
    //}

}