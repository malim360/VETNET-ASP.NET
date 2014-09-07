<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regCita.aspx.cs" Inherits="registros_regCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="formulario">

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
        Lugar:
        <p></p>

        <asp:ListBox id="lugar" Rows="1" runat="server" CssClass="aspTextBox">
            <asp:ListItem
            Enabled="True"
            Selected="True"
            Text="Clinica"
            Value="clinica" />


            <asp:ListItem
            Enabled="True"
            
            Text="Hogar"
            Value="hogar" />

        </asp:ListBox>


    <p></p>



     Hora:
        <p></p>

        <asp:TextBox runat="server" ID="hora" TextMode="SingleLine"  CssClass="hora"/>
        :
        <asp:TextBox runat="server" ID="minutos" TextMode="SingleLine" CssClass="hora" />
        <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
        runat="server" ControlToValidate="hora" Text="<b>Introduce un valor para la hora.</b>" ForeColor="Red"
        ErrorMessage="A fecha é de Prenchimento Obrigatório"
        SetFocusOnError="True" />
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
        runat="server" ControlToValidate="minutos" Text="<b>Introduce un valor para los minutos.</b>" ForeColor="Red"
        ErrorMessage="A fecha é de Prenchimento Obrigatório"
        SetFocusOnError="True" />

         <asp:RangeValidator ID="RangeValidator2" runat="server" Text="<b>Introduce un valor entre [0-23].</b>"
        ErrorMessage="Incorrecto" ControlToValidate="hora"
        ForeColor="Red"
        MinimumValue="0" MaximumValue="23" Type="Integer" />

        <asp:RangeValidator ID="RangeValidator3" runat="server" Text="<b>Introduce un valor entre [0-59].</b>"
        ErrorMessage="Incorrecto" ControlToValidate="minutos"
        ForeColor="Red"
        MinimumValue="0" MaximumValue="59" Type="Integer" />


    
        <p></p>

    <asp:Calendar DayNameFormat="Full" runat="server" ID="fecha" >
   <WeekendDayStyle BackColor="#fafad2" ForeColor="#ff0000" />
   <DayHeaderStyle ForeColor="#0000ff" />
   <TodayDayStyle BackColor="#00ff00" />
</asp:Calendar>


    
        <p></p>

    
        <asp:Button ID="enviar" runat="server" Text="Enviar" OnClick="InserirRegisto" class="boton"/>





        </div>


</asp:Content>

