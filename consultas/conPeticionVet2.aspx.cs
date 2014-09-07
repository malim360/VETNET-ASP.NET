using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class conPeticionVet2 : System.Web.UI.Page
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



        string SqlStr3 = "SELECT * FROM Peticion WHERE Id = @id";

        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
        Cmd3.Parameters.AddWithValue("@id", Request.QueryString["Id"]);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        saida.Text = "";


        if (Dados3.HasRows)
        {
            saida.Text += "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>Fecha</strong></td><td><strong>Descripcion</strong></td></tr>";
            while (Dados3.Read())
            {
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td></tr>", Dados3.GetString(1), Dados3.GetString(2), Dados3.GetValue(3),((DateTime)Dados3.GetValue(4)).ToShortDateString(), Dados3.GetString(5));
                byte[] imageBuffer = (byte[])Dados3.GetValue(10);
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                img1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(imageBuffer);

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


    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void InserirRegisto(object sender, EventArgs e)
    {

       base.OnLoad(e);
       string SqlStr = "UPDATE Peticion SET resolucion = @resolucion , tratamiento = @tratamiento, pendiente='false' WHERE Id = @id ";
        SqlCommand Cmd= new SqlCommand(SqlStr);
        Cmd.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
        

        //Cmd.Parameters.AddWithValue("@dniCliente", "44");
        //Cmd.Parameters.AddWithValue("@dniVeterinario", "55");
        //Cmd.Parameters.AddWithValue("@numReg", "11");
        
        Cmd.Parameters.AddWithValue("@resolucion", resolucion.Text);
        Cmd.Parameters.AddWithValue("@tratamiento", tratamiento.Text);
        Cmd.Connection= SqlCnn;
        SqlCnn.Open();
        int n= Cmd.ExecuteNonQuery();
        SqlCnn.Close();

        Response.Redirect("../registros/regCompletado.aspx");





    }
}
