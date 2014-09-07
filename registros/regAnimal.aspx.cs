using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class regAnimal : System.Web.UI.Page
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

        //Comprobar que el usuario es un cliente
        if (!Auxiliar.isCliente())
        {
            Response.Redirect("../error/noUser.aspx");


        }
    }





    protected void InserirRegisto(object sender, EventArgs e)
    {
        String StrInsert;

        DateTime DataRegisto = DateTime.Today;
        StrInsert = "INSERT INTO Animal( nReg, nombre, raza,tipo,peso,altura,fecNac,descripcion)";
        StrInsert += "VALUES( @numReg, @nombre, @raza, @tipo, @peso, @altura, @fecha, @descripcion)" + "SELECT CAST(scope_identity() AS int)"; ;
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);
        Cmd.Parameters.AddWithValue("@numReg", numReg.Text);
        Cmd.Parameters.AddWithValue("@nombre", nombre.Text);
        Cmd.Parameters.AddWithValue("@raza", raza.Text);
        Cmd.Parameters.AddWithValue("@tipo", tipo.Text);
        Cmd.Parameters.AddWithValue("@peso", Convert.ToInt32(peso.Text));
        Cmd.Parameters.AddWithValue("@altura", Convert.ToInt32(altura.Text));
        Cmd.Parameters.AddWithValue("@fecha", fecha.Text);
        Cmd.Parameters.AddWithValue("@descripcion", descripcion.Text);

        SqlCnn.Open();

        //Cmd.ExecuteNonQuery();
        Int32 count = 0;
        count = (Int32) Cmd.ExecuteScalar();
        //saida.Text = count.ToString();
        SqlCnn.Close();




        //Sacar dni
        string SqlStr2 = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd2.ExecuteReader();
        String dni = "";

        if (Dados.HasRows)
        {

            while (Dados.Read())
                dni = Dados.GetString(0);

        }


        Dados.Close();
        SqlCnn.Close();




        //Introducir dueño
         String StrInsert2;

        StrInsert2 = "INSERT INTO Propietario (dniCliente,idAnimal)";
        StrInsert2 += "VALUES( @dni, @idAnimal)";
        SqlCommand Cmd5 = new SqlCommand(StrInsert2, SqlCnn);
        Cmd5.Parameters.AddWithValue("@dni", dni);
        Cmd5.Parameters.AddWithValue("@idAnimal", count);
        

        SqlCnn.Open();

        //Cmd.ExecuteNonQuery();
       
        Cmd5.ExecuteScalar();
        //saida.Text = count.ToString();
        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");


    }
}