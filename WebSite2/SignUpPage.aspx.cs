using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BAL.InsertPerson(new Identifiers.Person() { Addr = txtAddr.Text, CellNum = Convert.ToInt32(txtCell.Text), DOB = Convert.ToDateTime(txtDOB.Text), Email = txtEmail.Text, Fname = txtFname.Text, Lname = txtLname.Text, Gender = txtGender.Text, MiddleName = txtMname.Text, MotherMaiden=txtMaiden.Text,NAtionID=txtNatID.Text, TRN=TXTtrn.Text,Passport=txtPassport.Text});
    }
}