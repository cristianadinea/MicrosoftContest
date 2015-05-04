<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserA.aspx.cs" Inherits="WebApplication2.Admin.UserA" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form3">
    <div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="LinqDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
            Height="492px" Width="500px" 
            >
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" ReadOnly="True" />
            <asp:BoundField DataField="City" HeaderText="City" 
                SortExpression="City" ReadOnly="True" />
            <asp:CheckBoxField DataField="IsAdmin" HeaderText="IsAdmin" ReadOnly="True" 
                SortExpression="IsAdmin" >
                <HeaderStyle Font-Bold="True" />
            </asp:CheckBoxField>
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" />
            <asp:CheckBoxField DataField="Banned" HeaderText="Banned" 
                SortExpression="Banned" ReadOnly="True" />
        </Columns>
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="Black" />
    </asp:GridView>
       <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WebApplication2.App_DB.ProductDataContext" EnableUpdate="True" 
        OrderBy="UserID" TableName="Users" EnableDelete="True" 
            Select="new (Name, Address, City, IsAdmin, Email, Banned)" 
            EnableInsert="True">
    </asp:LinqDataSource>
    </div>
   </form>
</asp:Content>
