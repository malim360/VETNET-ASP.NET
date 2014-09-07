using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class conLocales : System.Web.UI.Page
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

        string SqlStr = "SELECT * FROM Local";

        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        saida.Text = "";


        if (Dados.HasRows)
        {
            saida.Text += "<table><tr><td><strong>id</strong></td><td><strong>Nombre</strong></td><td><strong>Calle</strong></td><td><strong>Numero</strong></td><td><strong>Poblacion</strong></td><td><strong>Descripcion</strong></td></tr>";
            while (Dados.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td></tr>", Dados.GetValue(0), Dados.GetString(4), Dados.GetString(1), Dados.GetValue(6), Dados.GetString(2), Dados.GetString(5));
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay locales dispobibles";
        }

        Dados.Close();
        SqlCnn.Close();





    }
}