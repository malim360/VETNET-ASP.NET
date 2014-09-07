using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class consultas_conCitaCli : System.Web.UI.Page
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
        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        Cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        saida.Text = "";
        String dni = "";

        if (Dados.HasRows)
        {

            while (Dados.Read())
                dni = Dados.GetString(0);

        }

        Dados.Close();
        SqlCnn.Close();












        string SqlStr3 = "SELECT * FROM Cita WHERE dniCliente=@dni AND pendiente='false'";

        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
        Cmd3.Parameters.AddWithValue("@dni", dni);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        saida.Text = "";


        if (Dados3.HasRows)
        {
            saida.Text += "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong>Fecha</strong></td><td><strong>Hora</strong></td> <td><strong>Respuesta</strong></td> <td><strong>Ubicacion</strong></td> </tr>";
            while (Dados3.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td> </tr>", Dados3.GetString(1), Dados3.GetString(2), ((DateTime)Dados3.GetValue(4)).ToShortDateString(), Dados3.GetString(5), Dados3.GetString(7),Dados3.GetString(8));
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay citas dispobibles";
        }

        Dados3.Close();
        SqlCnn.Close();





    }
}
