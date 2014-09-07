<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regVeterinario.aspx.cs" Inherits="regVeterinario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="formulario">

        <p></p>
    DNI:
        <p></p>
        <asp:TextBox runat="server" ID="dni" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
        runat="server" ControlToValidate="dni" Text="<b>Introduce un valor para el dni.</b>" ForeColor="Red"
        ErrorMessage="O reg é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        <p></p>
     Num. Colegiado:
        <p></p>
        <asp:TextBox runat="server" ID="numColegiado" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="numColegiado" Text="<b>Introduce un valor para el num. Colegiado.</b>" ForeColor="Red"
        ErrorMessage="O reg é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        <p></p>
        Nombre:
        <p></p>
        <asp:TextBox runat="server" ID="nombre" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
        runat="server" ControlToValidate="nombre" Text="<b>Introduce un valor para el Nombre. </b>" ForeColor="Red"
        ErrorMessage="O nome é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        

      <p></p>
        Apellidos:
        <p></p>
        <asp:TextBox runat="server" ID="apellidos" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
        runat="server" ControlToValidate="apellidos" Text="<b>Introduce un valor para el Apellido. </b>" ForeColor="Red"
        ErrorMessage="O nome é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
       
        <p></p>
        Num. Contacto:<p></p>
        <asp:TextBox runat="server" ID="numContacto" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
        runat="server" ControlToValidate="numContacto" Text="<b>Introduce un valor para el numero de contacto.</b>" ForeColor="Red"
        ErrorMessage="A raza é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
       <p></p>
        Tipo:
        <p></p>
        <asp:ListBox id="tipo" Rows="1" runat="server" CssClass="aspTextBox">
            <asp:ListItem
            Enabled="True"
            Selected="True"
            Text="Propio"
            Value="propio" />


            <asp:ListItem
            Enabled="True"
            
            Text="privado"
            Value="privado" />


            


        </asp:ListBox>
        
        
        
        <p></p>

        Fecha (DD/MM/AA):
        <p></p>
        <asp:TextBox runat="server" ID="fecha" TextMode="SingleLine"  CssClass="aspTextBox"/>
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
        runat="server" ControlToValidate="fecha" Text="<b>Introduce un valor para la fecha de nacimiento.</b>" ForeColor="Red"
        ErrorMessage="A fecha é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        <asp:CompareValidator ID="CompareValidator1" runat="server" Text="<b>Introduce una fecha con el siguiente formato (DD/MM/AAAA).</b>"
        controltovalidate= "fecha" Type="Date"
        ForeColor="Red"
        Operator="DataTypeCheck" />
        
        
        
        <p></p>

        Residencia: 
        <p></p>
        <asp:TextBox runat="server" ID="residencia" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>
        <p></p>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
        runat="server" ControlToValidate="residencia" Text="<b>Introduce un valor para la fecha de residencia.</b>" ForeColor="Red"
        ErrorMessage="A fecha é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        <p></p>
    <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>


        </div>

</asp:Content>

