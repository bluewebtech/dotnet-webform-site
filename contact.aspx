<%@ Page Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="contact.aspx.cs" 
         Inherits="dotnet_webform_site.contact" 
         MasterPageFile="~/layouts/web.master" %>

<asp:Content ContentPlaceHolderId="title" runat="server"><%=title%></asp:Content>

<asp:Content ContentPlaceHolderId="content" runat="server">
<h2><%=title%></h2>
<% if(!IsPostBack) { %>
<form name="contact" id="Form1" role="form" method="post" runat="server">
    <div class="form-group">
        <label for="fullName">Full Name:</label>
        <input type="text" name="fullName" id="fullName" class="form-control" />
    </div>
    <div class="form-group">
        <label for="email">E-mail</label>
        <input type="email" name="email" id="email" class="form-control" />
    </div>
    <div class="form-group">
        <label for="telephone">Telephone</label>
        <input type="text" name="telephone" id="telephone" class="form-control" />
    </div>
    <div class="form-group">
        <label for="comments">Comments / Questions:</label>
       <textarea  name="comments" id="comments" class="form-control"></textarea>
    </div>
    <button type="submit" name="process" id="process" class="btn btn-primary">Process</button>
</form>
<% } else { %>
<p>Contact Form Processed Successfully!</p>
<% } %>
</asp:Content>