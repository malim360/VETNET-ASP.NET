<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conAnimalesVet.aspx.cs" Inherits="consultas_conAnimalesVet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     

        <div class="formulario">


            <p></p>

    <asp:ListBox ID="listBox1" runat="server" Rows="1" CssClass="aspTextBox">

    </asp:ListBox>

    <p></p>
        <asp:Button ID="enviar" runat="server" Text="Buscaer por Dueño" OnClick="InserirRegisto" CssClass="boton"/>

    
        <asp:Button ID="Button1" runat="server" Text="Buscar Todos" OnClick="InserirRegistoT" CssClass="boton"/>

        <p></p>



            </div>

  
    <p></p>
                <asp:Literal ID="saida" runat="server"> </asp:Literal>

    


</asp:Content>

