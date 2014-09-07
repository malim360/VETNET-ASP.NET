using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class registros_regCita : System.Web.UI.Page
{
    ListItem[] myList;
    String dni;

    protected void Page_Load(object sender, EventArgs e)
    {












    }

    SqlConnection SqlCon;
    public SqlConnection SqlCnn
    {
        get { return SqlCon; }
        set { SqlCon = value; }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string CnnString = ConfigurationManager.
        ConnectionStrings["BaseDadosSQL"].ConnectionString;
        SqlCnn = new SqlConnection(CnnString);


        //Comprobar que el usuario es un cliente
        if (!Auxiliar.isCliente())
        {
            Response.Redirect("../error/noUser.aspx");


        }

        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr3 = "SELECT * FROM Veterinario ";
        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();


        if (Dados3.HasRows)
        {


            while (Dados3.Read())

                listBox1.Items.Add(Dados3.GetString(0) + " - " + Dados3.GetString(1) + " " + Dados3.GetString(2));

        }




        Dados3.Close();
        SqlCnn.Close();




        //dni del cliente
        string SqlStr2 = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd2.ExecuteReader();
        dni = "";

        if (Dados.HasRows)
        {

            while (Dados.Read())
                dni = Dados.GetString(0);

        }


        Dados.Close();
        SqlCnn.Close();










        string SqlStr4 = "SELECT Animal.Id, Animal.nombre FROM Propietario INNER JOIN Animal ON Propietario.idAnimal = Animal.Id WHERE Propietario.dniCliente=@dniC ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);
        Cmd4.Parameters.AddWithValue("@dniC", dni);

        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd4.ExecuteReader();


        if (Dados4.HasRows)
        {


            while (Dados4.Read())

                listBox2.Items.Add(Dados4.GetValue(0).ToString() + " - " + Dados4.GetString(1));

        }




        Dados3.Close();
        SqlCnn.Close();


    }





    protected void InserirRegisto(object sender, EventArgs e)
    {




        String StrInsert;

        StrInsert = "INSERT INTO Cita( dniCliente, dniVeterinario, idAnimal, fecha, aceptada,pendiente,hora,ubicacion)";
        StrInsert += "VALUES( @dniCliente ,@dniVeterinario, @numReg, @fecha, 'false' , 'true',@hora,@ubicacion)";
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);

        //String a=fecha.VisibleDate.Day+"/"+fecha.VisibleDate.Month+"/"+fecha.VisibleDate.Year;
        //String a = fecha.SelectedDate.ToShortDateString();
        String a = String.Format("{0:MM/dd/yyyy}", fecha.SelectedDate); 


        Cmd.Parameters.AddWithValue("@dniCliente", dni);
        Cmd.Parameters.AddWithValue("@dniVeterinario", listBox1.SelectedValue.Split('-')[0]);
        Cmd.Parameters.AddWithValue("@numReg", listBox2.SelectedValue.Split('-')[0]);

        Cmd.Parameters.AddWithValue("@hora", hora.Text + ":" + minutos.Text);

        Cmd.Parameters.AddWithValue("@fecha", a);
        Cmd.Parameters.AddWithValue("@ubicacion", lugar.Text);






        SqlCnn.Open();
        Cmd.ExecuteNonQuery();



        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");

        //Saida.Text = "Dados Introduzidos";
    }
}