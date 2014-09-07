using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class regCliente : System.Web.UI.Page
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
        StrInsert = "INSERT INTO Cliente( dni, nombre, apellidos, numContacto,fecNac ,residencia ,status , usuario)";
        StrInsert += "VALUES( @dni, @nombre, @apellidos, @numContacto, @fecNac , @residencia , @regimen , @usuario)";
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);
        Cmd.Parameters.AddWithValue("@dni", dni.Text);
        Cmd.Parameters.AddWithValue("@nombre", nombre.Text);
        Cmd.Parameters.AddWithValue("@apellidos", apellidos.Text);
        Cmd.Parameters.AddWithValue("@numContacto", numContacto.Text);
        Cmd.Parameters.AddWithValue("@fecNac", fecha.Text);
        Cmd.Parameters.AddWithValue("@residencia", residencia.Text);
        Cmd.Parameters.AddWithValue("@regimen", tipo.Text);
        Cmd.Parameters.AddWithValue("@usuario", User.Identity.Name);

        SqlCnn.Open();
        try
        {
            Cmd.ExecuteNonQuery();

        }
        catch (Exception exc)
        {
            Response.Redirect("../error/ErrorID.aspx");

        }
        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");

        //Saida.Text = "Dados Introduzidos";
    }
}