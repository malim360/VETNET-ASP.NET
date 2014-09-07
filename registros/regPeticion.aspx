<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regPeticion.aspx.cs" Inherits="regPeticion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="formulario">
        <p></p>
   <asp:Literal ID="saida" runat="server" />
        <p></p>
    DNI Veterinario:
     <p></p>
    <asp:ListBox ID="listBox1" runat="server" Rows="1" CssClass="aspTextBox">

    </asp:ListBox>


    <p></p>

    Animal:
    <p></p>

     
    <asp:ListBox ID="listBox2" runat="server" Rows="1" CssClass="aspTextBox">

    </asp:ListBox>

  
   




    
        
       

        <p></p>

        Descripcion:
        <p></p>
        <asp:TextBox runat="server" ID="descripcion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="descripcion" Text="<b>Introduce una descripcion del problema.</b>" ForeColor="Red"
        ErrorMessage="A resolucion é de Prenchimento Obrigatório"
        SetFocusOnError="True" />

        <p></p>
        Imagen (max. 4MB): 
        <p></p>
        <asp:FileUpload id="image1" runat="server" CssClass="aspTextBox"/>

        <p></p>
        <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>


        </div>
</asp:Content>

