using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class regLocal : System.Web.UI.Page
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
    }





    protected void InserirRegisto(object sender, EventArgs e)
    {
        String StrInsert;

        DateTime DataRegisto = DateTime.Today;
        StrInsert = "INSERT INTO Local(nombre, calle,poblacion,CEP,numero,descripcion)";
        StrInsert += "VALUES(@nombre, @calle, @poblacion, @CEP, @numero, @descripcion)";
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);
        
        Cmd.Parameters.AddWithValue("@nombre", nombre.Text);
        Cmd.Parameters.AddWithValue("@calle", calle.Text);
        Cmd.Parameters.AddWithValue("@poblacion", poblacion.Text);
        Cmd.Parameters.AddWithValue("@CEP", Convert.ToInt32(cep.Text));
        Cmd.Parameters.AddWithValue("@numero", Convert.ToInt32(numero.Text));
        Cmd.Parameters.AddWithValue("@descripcion", descripcion.Text);

        SqlCnn.Open();
        Cmd.ExecuteNonQuery();
        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");

        //Saida.Text = "Dados Introduzidos";
    }
}