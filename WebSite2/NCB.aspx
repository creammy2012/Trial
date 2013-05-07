<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NCB.aspx.cs" Inherits="NCB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <br />
    Account#:
    <asp:TextBox ID="txtAccountNum" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="Account_,Fname,MiddleName,Lname,MotherMaiden"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True"
        AllowSorting="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="Account_" HeaderText="Account_" ReadOnly="True"
                SortExpression="Account_" />
            <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName"
                SortExpression="MiddleName" />
            <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />                       
            <asp:BoundField DataField="MotherMaiden" HeaderText="MotherMaiden"
                SortExpression="MotherMaiden" />           
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
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
        DataKeyNames="Account_" Height="50px"
        Width="125px" AllowPaging="True">
        <Fields>
            <asp:BoundField DataField="Account_" HeaderText="Account_" ReadOnly="True"
                SortExpression="Account_" />
            <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName"
                SortExpression="MiddleName" />
            <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
            <asp:BoundField DataField="Gender" HeaderText="Gender"
                SortExpression="Gender" />
            <asp:BoundField DataField="Addr" HeaderText="Addr" SortExpression="Addr" />
            <asp:BoundField DataField="MotherMaiden" HeaderText="MotherMaiden"
                SortExpression="MotherMaiden" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="CellNum" HeaderText="CellNum"
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

    <asp:Panel ID="Panel1" runat="server">
        Enter one of the following:<br />
        TRN #:
    <asp:TextBox ID="txtTrn" runat="server"></asp:TextBox>
        <br />
        NIS #:<asp:TextBox ID="txtNIS" runat="server"></asp:TextBox>
        <br />
        Passport #:
    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
            Text="Submit" />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <br />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

