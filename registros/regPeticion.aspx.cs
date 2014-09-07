using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class regPeticion : System.Web.UI.Page
{
    ListItem[] myList;
    String dni;

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



        //Comprobar que el usuario es un cliente
        if (!Auxiliar.isCliente())
        {
            Response.Redirect("../error/noUser.aspx");


        }

        //Rellenar ListBox con el acceso a la base de datos.

        string SqlStr3 = "SELECT * FROM Veterinario ";
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




        //dni del cliente
        string SqlStr2 = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd2.ExecuteReader();
        dni = "";

        if (Dados.HasRows)
        {

            while (Dados.Read())
                dni = Dados.GetString(0);

        }


        Dados.Close();
        SqlCnn.Close();










        string SqlStr4 = "SELECT Animal.Id, Animal.nombre FROM Propietario INNER JOIN Animal ON Propietario.idAnimal = Animal.Id WHERE Propietario.dniCliente=@dniC ";
        SqlCommand Cmd4 = new SqlCommand(SqlStr4, SqlCnn);
        Cmd4.Parameters.AddWithValue("@dniC", dni);

        SqlCnn.Open();
        SqlDataReader Dados4 = Cmd4.ExecuteReader();


        if (Dados4.HasRows)
        {


            while (Dados4.Read())

                listBox2.Items.Add(Dados4.GetValue(0).ToString() + " - " + Dados4.GetString(1));

        }




        Dados3.Close();
        SqlCnn.Close();
        
        
    }





    protected void InserirRegisto(object sender, EventArgs e)
    {

        Boolean subI = true;

        try
        {
            if (image1.HasFile)
            {
                // Se verifica que la extensión sea de un formato válido
                string ext = image1.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos =
                  new string[] { "jpg", "jpeg", "bmp", "png", "gif" };
                if (Array.IndexOf(formatos, ext) < 0)
                {
                    subI = true;

                }
                    
                
            }
            
        }
        catch (Exception ex)
        {
        }

        
        

        String StrInsert;

        DateTime DataRegisto = DateTime.Today;
        StrInsert = "INSERT INTO Peticion( dniCliente, dniVeterinario, idAnimal, fecha, descripcion,pendiente,hora,imagen)";
        StrInsert += "VALUES( @dniCliente ,@dniVeterinario, @numReg, @fecha, @descripcion, 'true',@hora,@imagen)";
        SqlCommand Cmd = new SqlCommand(StrInsert, SqlCnn);

        DateTime thisDay = DateTime.Today;

        
        Cmd.Parameters.AddWithValue("@dniCliente", dni);
        Cmd.Parameters.AddWithValue("@dniVeterinario", listBox1.SelectedValue.Split('-')[0]);
        Cmd.Parameters.AddWithValue("@numReg", listBox2.SelectedValue.Split('-')[0]);

        Cmd.Parameters.AddWithValue("@hora", DateTime.Now.ToShortTimeString());

        Cmd.Parameters.AddWithValue("@fecha", thisDay.Date);
        
        Cmd.Parameters.AddWithValue("@descripcion", descripcion.Text);

        if (subI)
        {
            byte[] imagen = new byte[image1.PostedFile.InputStream.Length];
            image1.PostedFile.InputStream.Read(imagen, 0, imagen.Length);
            Cmd.Parameters.AddWithValue("@imagen", imagen);

        }
        else
        {
            Cmd.Parameters.AddWithValue("@imagen", null);


        }




       


        SqlCnn.Open();
        Cmd.ExecuteNonQuery();



        SqlCnn.Close();

        Response.Redirect("regCompletado.aspx");

        //Saida.Text = "Dados Introduzidos";
    }
}