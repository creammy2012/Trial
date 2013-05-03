<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpPage.aspx.cs" Inherits="SignUpPage" %>

<!DOCTYPE html PUBLIC "-//W3C//Dasp:TableCell XHTML 1.0 asp:TableRowansitional//EN" "http://www.w3.org/asp:TableRow/xhtml1/Dasp:TableCell/xhtml1-asp:TableRowansitional.dasp:TableCell">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="tblePerson" runat="server" Style="border: 1px">

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPI" runat="server" Text="Personal Information"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFname" runat="server" Text="First Name:"></asp:Label>
                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFname"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>

                    <asp:Label ID="lblMname" runat="server" Text="Middle Name:"></asp:Label>
                    <asp:TextBox ID="txtMname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Middle Name" ControlToValidate="txtMname"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>

                    <asp:Label ID="lblLname" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtLname"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMaiden" runat="server" Text="Mother's Maiden Name:"></asp:Label>
                    <asp:TextBox ID="txtMaiden" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Mother's Maiden Name" ControlToValidate="txtMaiden"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
                    <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Format yyyy-mm-dd" ControlToValidate="txtDOB" ValidationExpression="^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Your Gender" ControlToValidate="txtGender"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LBLcELL" runat="server" Text="Cell Number:"></asp:Label>
                    <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Format 8765555555" ControlToValidate="txtCell" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter Your Email Address" ControlToValidate="txtEmail" ValidationExpression="^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddr" runat="server" Text="Address:"></asp:Label>
                    <asp:TextBox ID="txtAddr" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddr"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTRN" runat="server" Text="TRN:"></asp:Label>
                    <asp:TextBox ID="TXTtrn" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Please Enter Your TRN" ControlToValidate="TXTtrn" ValidationExpression="^[0-9]{9}"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPassport" runat="server" Text="Passport Number:"></asp:Label>
                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Format A1935286" ControlToValidate="txtPassport" ValidationExpression="^[a-zA-Z][0-9]{7}$"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblNatID" runat="server" Text="National ID Number:"></asp:Label>
                    <asp:TextBox ID="txtNatID" runat="server"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Format 1234567" ControlToValidate="txtNatID" ValidationExpression="^[0-9]{7}"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
