<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regAnimal.aspx.cs" Inherits="regAnimal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <div class="formulario">


        <p></p>

        Num. Reg. Animal:
        <p></p>
        <asp:TextBox runat="server" ID="numReg" TextMode="SingleLine" CssClass="aspTextBox"/>
        <p></p>       
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
        runat="server" ControlToValidate="numReg" Text="<b>Introduce un valor para el reg Animal.</b>" ForeColor="Red"
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
        Raza:
        <p></p>

        <asp:TextBox runat="server" ID="raza" TextMode="SingleLine" CssClass="aspTextBox"/>
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredValidator_Utilizador"
        runat="server" ControlToValidate="raza" Text="<b>Introduce un valor para la raza.</b>" ForeColor="Red"
        ErrorMessage="A raza é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        
        
       <p></p>
        Tipo:
       <p></p>

        <asp:ListBox id="tipo" Rows="1" runat="server" CssClass="aspTextBox">
            <asp:ListItem
            Enabled="True"
            Selected="True"
            Text="Animal Domestico"
            Value="domestico" />


            <asp:ListItem
            Enabled="True"
            
            Text="Animal de Ganaderia"
            Value="ganaderia" />


            


        </asp:ListBox>
        
        
        
        
        
        
        <p></p>

        Peso (Kg):
            <p></p>
        <asp:TextBox runat="server" ID="peso" TextMode="SingleLine" CssClass="aspTextBox"/>
       <p></p>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="peso" Text="<b>Introduce un valor para el peso.</b>" ForeColor="Red"
        ErrorMessage="O peso é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
        
        <asp:CompareValidator ID="CompVal" runat="server"
        ControlToValidate="peso" ValueToCompare="0" Type="Integer"
        Operator="GreaterThanEqual" Text="<b>Introduce un valor superior a 0.</b>"
        ForeColor="Red"
        ErrorMessage="Introduza um valor inteiro igual ou superior a 18" />
       
        <asp:CompareValidator ID="CompareValidator2" runat="server"
        ControlToValidate="peso" ValueToCompare="250" Type="Integer"
        Operator="LessThanEqual" Text="<b>Introduce un valor inferior a 250.</b>"
        ForeColor="Red"
        ErrorMessage="Introduza um valor inteiro igual ou inferior a 250. " />
         
        
        
<p></p>
        Altura (Cm):
            <p></p>
        <asp:TextBox runat="server" ID="altura" TextMode="SingleLine" CssClass="aspTextBox"/>
        <p></p>
        <asp:RangeValidator ID="RangeValidator1" runat="server" Text="<b>Introduce un valor entre [0-1000].</b>"
        ErrorMessage="Incorrecto" ControlToValidate="altura"
        ForeColor="Red"
        MinimumValue="0" MaximumValue="1000" Type="Integer" />
        <p></p>


        
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
        Descripcion:

        <p></p>
        <asp:TextBox runat="server" ID="descripcion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>
        <p></p>


        <asp:Literal runat="server" ID="saida" />
        <p></p>
        

        <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>


            </div>
</asp:Content>

