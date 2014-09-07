<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="consultar.aspx.cs" Inherits="consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:LoginView ID="LoginViewConsultar" runat="server">
<LoggedInTemplate>
<b>Bem vindo </b> <asp:LoginName ID="user" runat="server" />
&nbsp;
[Clique em <asp:LoginStatus ID="sair" runat="server" LogoutText="Sair"/>
para desligar a Autenticação]
</LoggedInTemplate>
</asp:LoginView>

</asp:Content>

