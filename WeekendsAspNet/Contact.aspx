<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" Trace="true" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WeekendsAspNet.Contact" %>

<%@ Register Src="~/Feedback.ascx" TagPrefix="uc1" TagName="Feedback" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    <asp:HiddenField ID="hdnName" runat="server" />
    <asp:TextBox ID="txtName" runat="server" />
    <asp:Button ID="btnSave" runat="server" Text ="Save" OnClick="btnSave_Click"/>
    <uc1:Feedback runat="server" id="Feedback" />
</asp:Content>
