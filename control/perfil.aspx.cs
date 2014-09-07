using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class pefil : System.Web.UI.Page
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

        string SqlStr = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        bool res = true;
        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        Cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        saida.Text = "";


        if (Dados.HasRows)
        {
            res = false;
            saida.Text = "Estas registrado como un Cliente. ";
            saida.Text += "<table><tr><td><strong>Dni</strong></td><td><strong>Nombre</strong></td><td><strong>Apellidos</strong></td></tr>";
            while (Dados.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2}</td> </tr>", Dados.GetValue(0), Dados.GetString(1), Dados.GetString(2));
            saida.Text += "</table>";
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
            res = false;
            saida.Text = "Estas registrado como un Veterinario. ";
            saida.Text += "<table><tr><td><strong>Dni</strong></td><td><strong>Nombre</strong></td><td><strong>Apellidos</strong></td></tr>";
            while (Dados2.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2}</td> </tr>", Dados2.GetValue(0), Dados2.GetString(1), Dados2.GetString(2));
            saida.Text += "</table>";
        }
        
               
        Dados2.Close();
        SqlCnn.Close();
        if (res)
        {
            saida.Text += "<a href=../registros/regVeterinario.aspx>Registrarse como Veterinario</a> </br>";
            saida.Text += "<a href=../registros/regCliente.aspx>Registrarse como Cliente</a>";


        }
        


    }
}