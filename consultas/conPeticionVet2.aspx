<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conPeticionVet2.aspx.cs" Inherits="conPeticionVet2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



        <div class="formulario">


                <p></p>

     <asp:Literal ID="saida" runat="server"> </asp:Literal>

    <p></p>


    <asp:Image ID="img1" Class="imagen"  Height="250px"  runat="server" />

    <p>

    </p>
     Resolucion:
        <asp:TextBox runat="server" ID="resolucion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>


         <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="resolucion" Text="<b>Introduce una resolucion.</b>" ForeColor="Red"
        ErrorMessage="A resolucion é de Prenchimento Obrigatório"
        SetFocusOnError="True" />



         <p></p>

        Tratamiento:
        <asp:TextBox runat="server" ID="tratamiento" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
        runat="server" ControlToValidate="tratamiento" Text="<b>Introduce un valor para el tratamiento.</b>" ForeColor="Red"
        ErrorMessage="O tratamiento é de Prenchimento Obrigatório"
        SetFocusOnError="True" />





        
        <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>

            </div>

</asp:Content>

