<%@ Page Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="OrderU.aspx.cs" Inherits="WebApplication2.Customer.OrderU" Title="Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 433px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td align="left" class="style4">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
        BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
        ShowGridLines="True" Width="220px" 
        onselectionchanged="Calendar1_SelectionChanged1">
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
    </asp:Calendar>
    <asp:Button ID="ListOrders" runat="server" Text="ListOrders" 
        onclick="ListOrders_Click" />
    <br />
    </td>
    <td>
    <asp:Label ID="Label1" runat="server" Font-Names="Consolas" Font-Size="Medium" 
            ForeColor="Red" ></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Names="Consolas" Font-Size="Medium"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Content>
    
  