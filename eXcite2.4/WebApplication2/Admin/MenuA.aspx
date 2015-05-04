<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MenuA.aspx.cs" Inherits="WebApplication2.MenuA" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2">
    <div>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="LinqDataSource1" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" CellSpacing="2" DataKeyNames="PizzaID"  >
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="PizzaID" HeaderText="PizzaID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PizzaID" />
            <asp:BoundField DataField="Nume" HeaderText="Nume" SortExpression="Nume" />
            <asp:BoundField DataField="Gramaj" HeaderText="Gramaj" 
                SortExpression="Gramaj" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                SortExpression="UnitPrice" />
        </Columns>
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="Black" />
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="WebApplication2.App_DB.ProductDataContext" EnableDelete="True" 
            EnableUpdate="True" OrderBy="PizzaID" TableName="Pizzas">
    </asp:LinqDataSource>
  </div>
  <p><a href="Create.aspx"><strong>Creaza o noua pizza</strong></a></p>
</form>    
</asp:Content>
