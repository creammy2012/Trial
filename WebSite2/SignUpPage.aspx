<%@ Page Language="C#" AutoEventWireup="asp:TableRowue" CodeFile="SignUpPage.aspx.cs" Inherits="SignUpPage" %>
<!DOCTYPE html PUBLIC "-//W3C//Dasp:TableCell XHTML 1.0 asp:TableRowansitional//EN" "http://www.w3.org/asp:TableRow/xhtml1/Dasp:TableCell/xhtml1-asp:TableRowansitional.dasp:TableCell">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table ID="tblePerson" runat="server" style="border:1px">
  
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblPI" runat="server" Text="Personal Information"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblFname" runat="server" Text="First Name:"></asp:Label>
        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    
        <asp:Label ID="lblMname" runat="server" Text="Middle Name:"></asp:Label>
        <asp:TextBox ID="txtMname" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    
        <asp:Label ID="lblLname" runat="server" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblMaiden" runat="server" Text="Mother's Maiden Name:"></asp:Label>
        <asp:TextBox ID="txtMaiden" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
        <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
        <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
        <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
     <asp:Label ID="LBLcELL" runat="server" Text="Cell Number:"></asp:Label>
        <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
     <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
     <asp:Label ID="lblAddr" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="txtAddr" runat="server"></asp:TextBox>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblTRN" runat="server" Text="TRN:"></asp:Label>
        <asp:TextBox ID="TXTtrn" runat="server"></asp:TextBox>
    </asp:TableCell>
     <asp:TableCell>
        <asp:Label ID="lblPassport" runat="server" Text="Passport Number:"></asp:Label>
        <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
    </asp:TableCell>
     <asp:TableCell>
        <asp:Label ID="lblNatID" runat="server" Text="National ID Number:"></asp:Label>
        <asp:TextBox ID="txtNatID" runat="server"></asp:TextBox>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell></asp:TableCell>
    <asp:TableCell></asp:TableCell>
    <asp:TableCell>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
