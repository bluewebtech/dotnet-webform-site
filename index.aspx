<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="index.aspx.cs" 
         Inherits="dotnet_webform_site.index"
         MasterPageFile="~/layouts/web.master" %>

<asp:Content ContentPlaceHolderId="title" runat="server"><%=title%></asp:Content>

<asp:Content ContentPlaceHolderId="content" runat="server">
<h2><%=title%></h2>
<p>Welcome content here.</p>
</asp:Content>