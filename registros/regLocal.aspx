<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regLocal.aspx.cs" Inherits="regLocal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="formulario">

        <p></p>

    Direccion:
        <p></p>
        <asp:TextBox runat="server" ID="calle" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredValidator_Utilizador"
        runat="server" ControlToValidate="calle" Text="<b>Introduce un valor para la calle. </b>" ForeColor="Red"
        ErrorMessage="A rua é de Prenchimento Obrigatório"
        SetFocusOnError="True" />


        <p></p>

        Numero:
        <p></p>
        <asp:TextBox runat="server" ID="numero" TextMode="SingleLine" CssClass="aspTextBox" />
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
        runat="server" ControlToValidate="numero" Text="<b>Introduce un valor para el CEP. </b>" ForeColor="Red"
        ErrorMessage="A cep é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        <asp:CompareValidator ID="CompareValidator2" runat="server" Text="<b>Introduce un CEP valido.</b>"
        controltovalidate= "numero" Type="Integer"
        ForeColor="Red"
        Operator="DataTypeCheck" />


        <p></p>
        Poblacion:
        <p></p>
        <asp:TextBox runat="server" ID="poblacion" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="poblacion" Text="<b>Introduce un valor para la poblacion. </b>" ForeColor="Red"
        ErrorMessage="A poblacion é de Prenchimento Obrigatório"
        SetFocusOnError="True" />

        



        <p></p>

        CEP:
        <p></p>
        <asp:TextBox runat="server" ID="cep" TextMode="SingleLine" CssClass="aspTextBox" />
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
        runat="server" ControlToValidate="cep" Text="<b>Introduce un valor para el CEP. </b>" ForeColor="Red"
        ErrorMessage="A cep é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        <asp:CompareValidator ID="CompareValidator1" runat="server" Text="<b>Introduce un CEP valido.</b>"
        controltovalidate= "cep" Type="Integer"
        ForeColor="Red"
        Operator="DataTypeCheck" />




  


        <p></p>
        Nombre del local:
        <p></p>
        <asp:TextBox runat="server" ID="nombre" TextMode="SingleLine" CssClass="aspTextBox"/>
       
        <p></p>       
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
        runat="server" ControlToValidate="nombre" Text="<b>Introduce un valor para nombre. </b>" ForeColor="Red"
        ErrorMessage="O nome é de Prenchimento Obrigatório"
        SetFocusOnError="True" />




        <p></p>

        Descripcion:
        <p></p>
        <asp:TextBox runat="server" ID="descripcion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
        runat="server" ControlToValidate="descripcion" Text="<b>Introduce una descripcion del problema.</b>" ForeColor="Red"
        ErrorMessage="A resolucion é de Prenchimento Obrigatório"
        SetFocusOnError="True" />

        <p></p>
            <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>

    </div>

</asp:Content>

