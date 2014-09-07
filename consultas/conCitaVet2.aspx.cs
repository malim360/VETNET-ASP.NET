using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class consultas_conCitaVet2 : System.Web.UI.Page
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
        string SqlStr = "UPDATE Cita SET  aceptada = @aceptada, pendiente='false' WHERE Id = @id ";
        SqlCommand Cmd = new SqlCommand(SqlStr);
        Cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);


        //Cmd.Parameters.AddWithValue("@dniCliente", "44");
        //Cmd.Parameters.AddWithValue("@dniVeterinario", "55");
        //Cmd.Parameters.AddWithValue("@numReg", "11");

        Cmd.Parameters.AddWithValue("@aceptada", Request.QueryString["Accion"]);

        Cmd.Connection = SqlCnn;
        SqlCnn.Open();
        int n = Cmd.ExecuteNonQuery();
        SqlCnn.Close();
        saida.Text = Request.QueryString["Accion"];
    }

   
}
