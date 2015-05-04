<%@ Page Language="C#" MasterPageFile="~/Visitor/Base.Master" AutoEventWireup="true" CodeBehind="MenuV.aspx.cs" Inherits="WebApplication2.MenuV" Title="Pizzeria Da Mapo - Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
        DataSourceID="LinqDataSource1" DataTextField="Nume" DataValueField="Nume" 
        Height="82px" Width="260px" onselectedindexchanged="ListBox1_SelectedIndexChanged"          
      ></asp:ListBox>
    <asp:TextBox ID="TextBox1" runat="server"  
        Height="26px" Width="65px"></asp:TextBox>
    <asp:Button ID="Send" runat="server" Text="Afiseaza pret" onclick="Send_Click" ></asp:Button>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Ron"></asp:Label>
    <br /> 
    <asp:Label ID="Label2" runat="server" ></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Adauga la cos" onclick="Send_Click1" ></asp:Button>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="WebApplication2.App_DB.ProductDataContext" Select="new (Nume)" 
        TableName="Pizzas" EnableUpdate="True">
    </asp:LinqDataSource>
</asp:Content>
