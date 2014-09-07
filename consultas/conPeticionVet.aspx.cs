using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class conPeticionVet : System.Web.UI.Page
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

        //Comprobar que el usuario es un veterinario
        if (!Auxiliar.isVeterinario())
        {
            Response.Redirect("../error/noUser.aspx");


        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {

        string SqlStr = "SELECT * FROM Veterinario WHERE usuario = @usuario ";
        bool res = true;
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
        else
        {

            saida.Text = "No estas registrado como veterinario. ";
            Dados.Close();
            SqlCnn.Close();
            return;
        }

        Dados.Close();
        SqlCnn.Close();












        string SqlStr3 = "SELECT * FROM Peticion WHERE dniVeterinario=@dni AND pendiente='true'";

        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
        Cmd3.Parameters.AddWithValue("@dni", dni);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        saida.Text = "";


        if (Dados3.HasRows)
        {
            saida.Text += "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>fecha</strong></td><td><strong>Descripcion</strong></td> <td> Enlace </td></tr>";
            while (Dados3.Read()){
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td>", Dados3.GetValue(1), Dados3.GetString(2), Dados3.GetValue(3),((DateTime)Dados3.GetValue(4)).ToShortDateString(), Dados3.GetString(5));
                saida.Text += "<td> <a href=conPeticionVet2.aspx?Id=" + Dados3.GetValue(0) +">Modificar </a></td></tr>";
            }
            
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay peticiones dispobibles";
        }

        Dados3.Close();
        SqlCnn.Close();





    }
}
