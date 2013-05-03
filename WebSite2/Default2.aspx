<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" AllowPaging="True" DataKeyNames="CustID">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CustID" HeaderText="CustID" SortExpression="CustID" />
                <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Addr" HeaderText="Addr" SortExpression="Addr" />
                <asp:BoundField DataField="MotherMaiden" HeaderText="MotherMaiden" SortExpression="MotherMaiden" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="CellNum" HeaderText="CellNum" SortExpression="CellNum" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="selectAllPerson"            
             TypeName="BAL" DataObjectTypeName="Identifiers.Person" InsertMethod="InsertPerson"
             UpdateMethod="updatePerson"></asp:ObjectDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="CustID" DataSourceID="ObjectDataSource2" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="CustID" HeaderText="CustID" SortExpression="CustID" />
                <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Addr" HeaderText="Addr" SortExpression="Addr" />
                <asp:BoundField DataField="MotherMaiden" HeaderText="MotherMaiden" SortExpression="MotherMaiden" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="CellNum" HeaderText="CellNum" SortExpression="CellNum" />
                <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Identifiers.Person" InsertMethod="InsertPerson" OldValuesParameterFormatString="original_{0}" SelectMethod="selectPersonById" TypeName="BAL" UpdateMethod="updatePerson">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="CustId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
