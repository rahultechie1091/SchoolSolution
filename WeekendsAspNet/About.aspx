<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WeekendsAspNet.About" %>

<%@ Register Src="~/Feedback.ascx" TagPrefix="uc1" TagName="Feedback" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <uc1:Feedback runat="server" id="Feedback" />
</asp:Content>
