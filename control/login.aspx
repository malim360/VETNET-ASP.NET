<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Login ID="autenticacao" runat="server"
CreateUserText="Novo Utilizador"
CreateUserUrl="registro.aspx"
DestinationPageUrl="consultar.aspx" />


</asp:Content>

