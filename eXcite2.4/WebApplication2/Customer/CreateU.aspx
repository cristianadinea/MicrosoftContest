<%@ Page Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="CreateU.aspx.cs" Inherits="WebApplication2.Admin.Create" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Ingredient" HeaderText="Ingredient" ReadOnly="True">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Cantitate">
                <ItemTemplate>
                    <asp:TextBox ID="TextBoxCantitate" runat="server" Height="22px" Width="30px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="New" runat="server" Text="Create" onclick="New_Click" />
   <a href="MenuU.aspx">Inapoi la meniu</a>
    </asp:Content>
   