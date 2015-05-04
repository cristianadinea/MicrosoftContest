<%@ Page Language="C#" MasterPageFile="~/Visitor/Base.Master" AutoEventWireup="true" CodeBehind="LogForm.aspx.cs" Inherits="WebApplication2.LogForm" Title="Pizzeria Da Mapo - Create your account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <table style="width:100%;">
        <tr>
            <td align="right">
                <asp:Label ID="NAMELabel" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="NAME" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="USERNAMELabel" runat="server" Text="UserName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="USERNAME" runat="server"></asp:TextBox>
            </td>
        </tr>
         
        <tr>
            <td align="right">
                <asp:Label ID="PASSWORDLabel" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PASSWORD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            
        </tr>
        <tr> 
            <td align="right">
                <asp:Label ID="CPASSWORDLabel" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CPASSWORD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="ADDRESSLabel" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ADDRESS" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="CITYLabel" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CITY" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="EMAILLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="EMAIL" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="OUTPUT" runat="server" Text=" "></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="NewUser" runat="server" Text="SignUp" onclick="NewUser_Click" />
                
            </td>
         </tr>
         <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
