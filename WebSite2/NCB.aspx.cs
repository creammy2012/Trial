using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NCB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex == -1)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        NCBDataContext db = new NCBDataContext();
        var value = from val in db.Customers
                    where val.Account_ == Convert.ToInt32(GridView1.SelectedDataKey.Values["Account_"].ToString())
                    select val;
        DetailsView1.DataSource = value;
        DetailsView1.DataBind();
        if (GridView1.SelectedIndex == -1)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Identifiers.Service sv = new Identifiers.Service();     
        Identifiers.Person per= new Identifiers.Person() 
        { NAtionID=txtNIS.Text,Passport=txtPassport.Text, TRN=txtTrn.Text
        ,
          Fname = GridView1.SelectedDataKey.Values["Fname"].ToString(),
          Lname = GridView1.SelectedDataKey.Values["Lname"].ToString(),
          MiddleName = GridView1.SelectedDataKey.Values["MiddleName"].ToString(),
          MotherMaiden = GridView1.SelectedDataKey.Values["MotherMaiden"].ToString()
        };
        lblMessage.Text=sv.verify(per);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        NCBDataContext db = new NCBDataContext();
        var value = from val in db.Customers
                    where val.Account_ == Convert.ToInt32(txtAccountNum.Text)
                    select val;
        GridView1.DataSource = value;
        GridView1.DataBind();
    }
}