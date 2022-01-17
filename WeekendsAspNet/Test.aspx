<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" MasterPageFile="~/Admin.Master" Inherits="WeekendsAspNet.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<table>
<tr>
<td>UserName:</td>
<td><asp:TextBox ID="txtUsername" runat="server"/></td>
</tr>
<tr>
<td>Password:</td>
<td><asp:TextBox ID="txtPwd" runat="server" TextMode="Password"/></td>
</tr>
<tr>
<td></td>
<td><asp:Button ID="btnLogin" runat="server" Text="Login"
onclick="btnLogin_Click" />  </td>
</tr>
<tr>
<td colspan="2"><asp:Label ID="lblMsg" runat="server" Font-Bold="true"/> </td>
</tr>
</table>
</div>
</asp:Content>