<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regHistorial.aspx.cs" Inherits="regHistorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="formulario">

        <p></p>
    
        DNI Cliente:
        <p></p>

        <p></p>


    <asp:ListBox ID="listBox1" runat="server" Rows="1" CssClass="aspTextBox">

    </asp:ListBox>

    



        <p></p>
        Num. Reg. Animal:
        <p></p>

        <p></p>


    <asp:ListBox ID="listBox2" runat="server" Rows="1" CssClass="aspTextBox">

    </asp:ListBox>

        <p></p>
        Tipo:
        <p></p>

        <asp:ListBox id="tipo" Rows="1" runat="server" CssClass="aspTextBox">
            <asp:ListItem
            Enabled="True"
            Selected="True"
            Text="Consulta"
            Value="consulta" />


            <asp:ListItem
            Enabled="True"
            
            Text="Tratamiento Rutinario"
            Value="tratamiento" />


            <asp:ListItem
            Enabled="True"
            
            Text="Urgencia"
            Value="urgencia" />


        </asp:ListBox>


    



        <p></p>

        Descripcion:
        <p></p>

        <asp:TextBox runat="server" ID="descripcion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>



        <p></p>

        Resolucion:
        <p></p>

        <asp:TextBox runat="server" ID="resolucion" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>

        <p></p>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        runat="server" ControlToValidate="resolucion" Text="<b>Introduce una resolucion.</b>" ForeColor="Red"
        ErrorMessage="A resolucion é de Prenchimento Obrigatório"
        SetFocusOnError="True" />



        <p></p>

        Tratamiento:
        <p></p>

        <asp:TextBox runat="server" ID="tratamiento" TextMode="Multiline" Rows="3" CssClass="aspTextBox2"/>
        <p></p>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
        runat="server" ControlToValidate="tratamiento" Text="<b>Introduce un valor para el tratamiento.</b>" ForeColor="Red"
        ErrorMessage="O tratamiento é de Prenchimento Obrigatório"
        SetFocusOnError="True" />



        <p></p>

        Precio (€):

        <p></p>

        <asp:TextBox runat="server" ID="precio" TextMode="SingleLine" CssClass="aspTextBox"/>
        <p></p>
        <asp:RangeValidator ID="RangeValidator1" runat="server" Text="<b>Introduce un valor entre [0-1000].</b>"
        ErrorMessage="Incorrecto" ControlToValidate="precio"
        ForeColor="Red"
        MinimumValue="0" MaximumValue="1000" Type="Double" />


   



        <p></p>

     Hora:
        <p></p>

        <asp:TextBox runat="server" ID="hora" Class="hora" TextMode="SingleLine"  />
        :
        <asp:TextBox runat="server" ID="minutos" Class="hora" TextMode="SingleLine"  />

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

    <asp:Calendar DayNameFormat="Full" runat="server" ID="fecha" CssClass="fecha">
   <WeekendDayStyle BackColor="#fafad2" ForeColor="#ff0000" />
   <DayHeaderStyle ForeColor="#0000ff" />
   <TodayDayStyle BackColor="#00ff00" />
</asp:Calendar>

<p></p>
           
       <asp:Button ID="enviar" class="boton" runat="server" Text="Enviar" OnClick="InserirRegisto" />

        </div>

</asp:Content>

