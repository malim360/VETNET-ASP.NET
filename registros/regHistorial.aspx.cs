using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class regHistorial : System.Web.UI.Page
{
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


        //Comprobar que el usuario es un veterinario
        if (!Auxiliar.isVeterinario())
        {
            Response.Redirect("../error/noUser.aspx");


        }


        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr3 = "SELECT * FROM Cliente ";
        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        if (Dados3.HasRows)
        {
            while (Dados3.Read())
                listBox1.Items.Add(Dados3.GetString(0) + " - " + Dados3.GetString(1) + " " + Dados3.GetString(2));

        }

        Dados3.Close();




        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr4 = "SELECT * FROM Animal ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);

        SqlDataReader Dados4 = Cmd4.ExecuteReader();

        if (Dados4.HasRows)
        {
            while (Dados4.Read())
                listBox2.Items.Add(Dados4.GetValue(0) + " - " + Dados4.GetString(1) + " - " + Dados4.GetString(2));

        }

        Dados4.Close();

        SqlCnn.Close();

    }





    protected void InserirRegisto(object sender, EventArgs e)
    {

        String dni = Auxiliar.dniCurrent();
        /*
        string SqlStr2 = "SELECT * FROM Veterinario WHERE usuario = @usuario ";
        bool res = true;
        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd2.ExecuteReader();
        String dni = Auxiliar.dniCurrent();

        if (Dados.HasRows)
        {

            while (Dados.Read())
                dni = Dados.GetString(0);

        }


        Dados.Close();
        SqlCnn.Close();


        */



        //String a=fecha.SelectedDate.Day+"/"+fecha.SelectedDate.Month+"/"+fecha.SelectedDate.Year;
        String a = String.Format("{0:MM/dd/yyyy}", fecha.SelectedDate); 
        
    
        
        
        
        
        String StrInsert;

        DateTime DataRegisto = DateTime.Today;
        StrInsert = "INSERT INTO Historial( dniCliente, dniVeterinario, idAnimal ,fecha, tipo,descripcion, resolucion, tratamiento, precio,hora)";
        StrInsert += "VALUES( @dniCliente ,@dniVeterinario, @regAnimal,@fecha, @tipo, @descripcion, @resolucion, @tratamiento, @precio, @hora)";
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);
        Cmd.Parameters.AddWithValue("@dniCliente", listBox1.SelectedValue.Split('-')[0]);
        Cmd.Parameters.AddWithValue("@dniVeterinario", dni);
        Cmd.Parameters.AddWithValue("@regAnimal", Convert.ToInt32(listBox2.SelectedValue.Split('-')[0]));
        Cmd.Parameters.AddWithValue("@tipo", tipo.Text);
        Cmd.Parameters.AddWithValue("@fecha", a);
        Cmd.Parameters.AddWithValue("@descripcion", descripcion.Text);
        Cmd.Parameters.AddWithValue("@resolucion", resolucion.Text);
        Cmd.Parameters.AddWithValue("@tratamiento", tratamiento.Text);
        Cmd.Parameters.AddWithValue("@precio", Convert.ToInt32(precio.Text));
        Cmd.Parameters.AddWithValue("@hora", hora.Text+":"+minutos.Text);


        SqlCnn.Open();
        Cmd.ExecuteNonQuery();
        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");



        //Saida.Text = "Dados Introduzidos";
    }
}