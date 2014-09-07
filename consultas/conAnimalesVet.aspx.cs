using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class consultas_conAnimalesVet : System.Web.UI.Page
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
        SqlCnn.Close();

    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        
    }


    protected void InserirRegistoT(object sender, EventArgs e){
            
        string SqlStr = "SELECT * FROM Animal";

            SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
            SqlCnn.Open();
            SqlDataReader Dados = Cmd.ExecuteReader();
            saida.Text = "";


            if (Dados.HasRows)
            {
                saida.Text += "<table><tr><td><strong>nReg</strong></td><td><strong>Nombre</strong></td><td><strong>raza</strong></td><td><strong>peso</strong></td><td><strong>altura</strong></td><td><strong>fecNac</strong></td><td><strong>tipo</strong></td><td><strong>Descripcion</strong></td></tr>";
                while (Dados.Read())
                    saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados.GetValue(1), Dados.GetString(2), Dados.GetString(3), Dados.GetValue(4), Dados.GetValue(5), ((DateTime)Dados.GetValue(6)).ToShortDateString(), Dados.GetString(7), Dados.GetString(8));
                saida.Text += "</table>";
            }
            else
            {
                saida.Text += "No hay locales dispobibles";
            }

            Dados.Close();
            SqlCnn.Close();


     }



    protected void InserirRegisto(object sender, EventArgs e)
    {

        String dni = listBox1.SelectedValue.Split('-')[0];
        string SqlStr4 = "SELECT Animal.nReg, Animal.nombre, Animal.raza, Animal.peso, Animal.altura, Animal.fecNac, Animal.tipo, Animal.descripcion FROM Propietario INNER JOIN Animal ON Propietario.idAnimal = Animal.Id WHERE Propietario.dniCliente=@dniC ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);
        Cmd4.Parameters.AddWithValue("@dniC", dni);

        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd4.ExecuteReader();


        if (Dados4.HasRows)
        {

            saida.Text = "<table name='Animales'><tr><td><strong>nReg</strong></td><td><strong>Nombre</strong></td><td><strong>raza</strong></td><td><strong>peso</strong></td><td><strong>altura</strong></td><td><strong>fecNac</strong></td><td><strong>tipo</strong></td><td><strong>Descripcion</strong></td></tr>";

            while (Dados4.Read())
            {
                saida.Text += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3}</td> <td> {4}</td><td> {5}</td><td> {6}</td><td> {7}</td></tr>", Dados4.GetString(0), Dados4.GetString(1), Dados4.GetString(2), Dados4.GetValue(3), Dados4.GetValue(4),((DateTime)Dados4.GetValue(5)).ToShortDateString(), Dados4.GetString(6), Dados4.GetString(7));
                //saida.Text += string.Format("<tr> <td> {0}</td> </tr> ", Dados4.GetString(1));
            }
            saida.Text += "</table>";


        }
        else
        {
            saida.Text = "No tiene ningun animal asociado.";
        }




        Dados4.Close();
        SqlCnn.Close();

    


    }

    
}