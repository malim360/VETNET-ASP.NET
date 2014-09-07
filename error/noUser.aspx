<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="noUser.aspx.cs" Inherits="error_noUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%
        String res="No estas registrado";
         %>
<% if(Auxiliar.isCliente()){
       res = "Esta pagina solo esta permitida para Veterinarios. ";
    }
    %>

    <% if(Auxiliar.isVeterinario()){
       res = "Esta pagina solo esta permitida para Clientes. ";
    }
    %>

    <% Response.Write("<h1>"+res+"</h1>"); %>


</asp:Content>

