using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class consultas_conAnimalesCli : System.Web.UI.Page
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












        string SqlStr3 = "SELECT Animal.nReg, Animal.nombre, Animal.raza, Animal.peso, Animal.altura, Animal.fecNac, Animal.tipo, Animal.descripcion FROM Propietario INNER JOIN Animal ON Propietario.idAnimal = Animal.Id WHERE Propietario.dniCliente=@dni ";

        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
        Cmd3.Parameters.AddWithValue("@dni", dni);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        saida.Text = "";


        if (Dados3.HasRows)
        {
            saida.Text = "<table><tr><td><strong>nReg</strong></td><td><strong>Nombre</strong></td><td><strong>raza</strong></td><td><strong>peso</strong></td><td><strong>altura</strong></td><td><strong>fecNac</strong></td><td><strong>tipo</strong></td><td><strong>Descripcion</strong></td></tr>";
            while (Dados3.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados3.GetString(0), Dados3.GetString(1), Dados3.GetString(2), Dados3.GetValue(3), Dados3.GetValue(4), ((DateTime)Dados3.GetValue(5)).ToShortDateString(), Dados3.GetString(6), Dados3.GetString(7));
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No tienes animales dispobibles";
        }

        Dados3.Close();
        SqlCnn.Close();





    }
}
