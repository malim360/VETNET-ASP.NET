using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class consultas_conHistorialesVet : System.Web.UI.Page
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


        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr3 = "SELECT * FROM Cliente ";
        SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);

        SqlCnn.Open();
        SqlDataReader Dados3 = Cmd3.ExecuteReader();

        if (Dados3.HasRows)
        {
            while (Dados3.Read())
                listBox1.Items.Add(Dados3.GetString(0) + " - " + Dados3.GetString(1) + " " + Dados3.GetString(2));

        }

        Dados3.Close();




        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr4 = "SELECT * FROM Animal ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);

        SqlDataReader Dados4 = Cmd4.ExecuteReader();

        if (Dados4.HasRows)
        {
            while (Dados4.Read())
                listBox2.Items.Add(Dados4.GetValue(0) + " - " + Dados4.GetString(1) + " - " + Dados4.GetString(2));

        }

        Dados4.Close();

        SqlCnn.Close();

    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {

    }


    protected void InserirRegistoT(object sender, EventArgs e)
    {

        string SqlStr = "SELECT * FROM Historial";

        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd.ExecuteReader();
        saida.Text = "";


        if (Dados4.HasRows)
        {
            saida.Text = "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>fecha</strong></td><td><strong>Tipo</strong></td><td><strong>Descripcion</strong></td> <td><strong>Resolucion</strong></td> <td><strong>Tratamiento</strong></td> <td><strong>Precio</strong></td></tr>";
            while (Dados4.Read())
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados4.GetString(0), Dados4.GetString(1), Dados4.GetValue(2), ((DateTime)Dados4.GetValue(3)).ToShortDateString() , Dados4.GetString(4), Dados4.GetString(5), Dados4.GetString(6), Dados4.GetValue(7));
            saida.Text += "</table>";
        }
        else
        {
            saida.Text += "No hay historiales dispobibles";
        }

        Dados4.Close();
        SqlCnn.Close();


    }



    protected void InserirRegisto(object sender, EventArgs e)
    {

        String var = listBox1.SelectedValue.Split('-')[0];
        string SqlStr4 = "SELECT Historial.dniCliente, Historial.dniVeterinario, Historial.idAnimal, Historial.fecha, Historial.tipo, Historial.descripcion, Historial.resolucion, Historial.tratamiento, Historial.precio FROM Historial INNER JOIN Cliente ON Cliente.dni=Historial.dniCliente WHERE Cliente.dni=@var ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);
        Cmd4.Parameters.AddWithValue("@var", var);

        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd4.ExecuteReader();


        if (Dados4.HasRows)
        {

            saida.Text = "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>fecha</strong></td><td><strong>Tipo</strong></td><td><strong>Descripcion</strong></td> <td><strong>Resolucion</strong></td> <td><strong>Tratamiento</strong></td> <td><strong>Precio</strong></td></tr>";

            while (Dados4.Read())
            {
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados4.GetString(0), Dados4.GetString(1), Dados4.GetValue(2), ((DateTime)Dados4.GetValue(3)).ToShortDateString(), Dados4.GetString(4), Dados4.GetString(5), Dados4.GetString(6), Dados4.GetValue(7));
                //saida.Text += string.Format("<tr> <td> {0}</td> </tr> ", Dados4.GetString(1));
            }
            saida.Text += "</table>";


        }
        else
        {
            saida.Text = "No tiene ningun historial asociado.";
        }

        Dados4.Close();
        SqlCnn.Close();

    }


    protected void InserirRegistoA(object sender, EventArgs e)
    {

        String var = listBox2.SelectedValue.Split('-')[0];
        string SqlStr4 = "SELECT Historial.dniCliente, Historial.dniVeterinario, Historial.idAnimal, Historial.fecha, Historial.tipo, Historial.descripcion, Historial.resolucion, Historial.tratamiento, Historial.precio FROM Historial INNER JOIN Animal ON  Animal.id=Historial.idAnimal WHERE Animal.id=@var";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);
        Cmd4.Parameters.AddWithValue("@var", var);

        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd4.ExecuteReader();


        if (Dados4.HasRows)
        {

            saida.Text = "<table><tr><td><strong>DNI Cliente</strong></td><td><strong>DNI Veterinario</strong></td><td><strong> Num Registro</strong></td><td><strong>fecha</strong></td><td><strong>Tipo</strong></td><td><strong>Descripcion</strong></td> <td><strong>Resolucion</strong></td> <td><strong>Tratamiento</strong></td> <td><strong>Precio</strong></td></tr>";

            while (Dados4.Read())
            {
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados4.GetString(0), Dados4.GetString(1), Dados4.GetValue(2), ((DateTime)Dados4.GetValue(3)).ToShortDateString(), Dados4.GetString(4), Dados4.GetString(5), Dados4.GetString(6), Dados4.GetValue(7));
                //saida.Text += string.Format("<tr> <td> {0}</td> </tr> ", Dados4.GetString(1));
            }
            saida.Text += "</table>";


        }
        else
        {
            saida.Text = "No tiene ningun historial asociado.";
        }

        Dados4.Close();
        SqlCnn.Close();

    }


}