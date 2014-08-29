<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="missing.aspx.cs" 
         Inherits="dotnet_webform_site.missing" 
         MasterPageFile="~/layouts/web.master" %>

<asp:Content ContentPlaceHolderId="title" runat="server"><%=title%></asp:Content>

<asp:Content ContentPlaceHolderId="content" runat="server">
<h2><%=title%></h2>
<p>Page not Found</p>
</asp:Content>