using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class conVeterinarios : System.Web.UI.Page
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

        string SqlStr = "SELECT * FROM Veterinario";
       
        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        saida.Text = "";


        if (Dados.HasRows)
        {
            saida.Text += "<table id='menu1' class='menu1'><tr><th><strong>Dni</strong></th><th><strong>Nombre</strong></th><th><strong>Apellidos</strong></th><th><strong>Regimen</strong></th></tr>";
            while (Dados.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> </tr>", Dados.GetValue(0), Dados.GetString(1), Dados.GetString(2), Dados.GetString(6));
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay veterinarios dispobibles";
        }

        Dados.Close();
        SqlCnn.Close();

       



    }
}