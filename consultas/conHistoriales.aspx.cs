using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class conHistoriales : System.Web.UI.Page
{
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
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        //Comprobar que el usuario es un cliente
        if (!Auxiliar.isCliente())
        {
            Response.Redirect("../error/noUser.aspx");


        }


        string SqlStr = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        bool res = true;
        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        Cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        saida.Text = "";
        String dni="";

        if (Dados.HasRows)
        {
            
            while (Dados.Read())
                dni = Dados.GetString(0);
               
        }

        Dados.Close();
        SqlCnn.Close();

        string SqlStr2 = "SELECT * FROM Veterinario WHERE usuario = @usuario ";

        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados2 = Cmd2.ExecuteReader();



        if (Dados2.HasRows)
        {
            while (Dados2.Read())
                dni = Dados2.GetString(0);
        }


        Dados2.Close();
        SqlCnn.Close();










        string SqlStr3 = "SELECT * FROM Historial WHERE dniCliente=@dni OR dniVeterinario=@dni";

        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
        Cmd3.Parameters.AddWithValue("@dni", dni);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();
        
        saida.Text = "";


        if (Dados3.HasRows)
        {
            saida.Text += "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>fecha</strong></td><td><strong>Tipo</strong></td><td><strong>Descripcion</strong></td> <td><strong>Resolucion</strong></td> <td><strong>Tratamiento</strong></td> <td><strong>Precio</strong></td></tr>";
            while (Dados3.Read())
            {
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td> <td> {6}</td> <td> {7}</td> <td> {8}</td></tr>", Dados3.GetValue(0), Dados3.GetString(1), Dados3.GetValue(2), ((DateTime)Dados3.GetValue(3)).ToShortDateString(), Dados3.GetString(4), Dados3.GetString(5), Dados3.GetString(6), Dados3.GetString(7), Dados3.GetValue(8));


            }

            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay historiales dispobibles";
        }

        Dados3.Close();
        SqlCnn.Close();





    }
}