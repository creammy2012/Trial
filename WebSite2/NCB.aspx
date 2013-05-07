<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NCB.aspx.cs" Inherits="NCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <br />
    Account#:
    <asp:TextBox ID="txtAccountNum" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellSpacing="2"
        DataKeyNames="Account_,Fname,MiddleName,Lname,MotherMaiden"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True"
        CssClass="mGrid margin" HeaderStyle-Font-Underline="false"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        AllowSorting="True" GridLines="Both" CellPadding="2" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="1px" BorderStyle="NotSet" EditRowStyle-BorderStyle="NotSet" EditRowStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="1px">
        <AlternatingRowStyle BorderStyle="Solid" />
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="Account_" HeaderText="Account Number" ReadOnly="True" />
            <asp:BoundField DataField="Fname" HeaderText="First Name" />
            <asp:BoundField DataField="MiddleName" HeaderText="Middle Initial"
                HeaderStyle-BorderStyle="Solid" />
            <asp:BoundField DataField="Lname" HeaderText="Last Name" />
            <asp:BoundField DataField="MotherMaiden" HeaderText="MotherMaiden" />
        </Columns>

    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server"
        ContextTypeName="NCBDataContext" EntityTypeName="" TableName="Customers"
        Where="Account_ == @Account_">
        <WhereParameters>
            <asp:ControlParameter ControlID="txtAccountNum" Name="Account_"
                PropertyName="Text" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    <br />
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
        DataKeyNames="Account_" Height="50px" HeaderText="Account Info" CssClass="margin"
        Width="330px" AllowPaging="True" CellPadding="2" HeaderStyle-CssClass="HeaderStyle">
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
        <FieldHeaderStyle CssClass="AlternatingRowStyle" />
        <Fields>
            <asp:BoundField DataField="Account_" HeaderText="Account Number" ReadOnly="True"
                SortExpression="Account_" />
            <asp:BoundField DataField="Fname" HeaderText="First Name" SortExpression="Fname" />
            <asp:BoundField DataField="MiddleName" HeaderText="Middle Initial"
                SortExpression="MiddleName" />
            <asp:BoundField DataField="Lname" HeaderText="Last Name" SortExpression="Lname" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
            <asp:BoundField DataField="Gender" HeaderText="Gender"
                SortExpression="Gender" />
            <asp:BoundField DataField="Addr" HeaderText="Address" SortExpression="Addr" />
            <asp:BoundField DataField="MotherMaiden" HeaderText="Mother's Maiden Name"
                SortExpression="MotherMaiden" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="CellNum" HeaderText="Cell Number"
                SortExpression="CellNum" />
        </Fields>
    </asp:DetailsView>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server"
        ContextTypeName="NCBDataContext" EntityTypeName="" TableName="Customers"
        Where="Account_ == @Account_">
        <WhereParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Account_"
                PropertyName="SelectedValue" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br />
        <table>
            <tr>
                <th colspan="2">Enter one of the following:</th>
            </tr>
            <tr>
                <td>TRN #:</td>
                <td>
                    <asp:TextBox ID="txtTrn" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>National ID #:</td>
                <td>
                    <asp:TextBox ID="txtNIS" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Passport #:</td>
                <td>
                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                        Text="Submit" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

