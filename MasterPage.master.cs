using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void OutputDay()
    {
        Response.Write(DateTime.Now.ToString("D"));
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



    protected override void OnLoad(EventArgs e)
    {

        Boolean res = true;
        sair.Visible = true;

        if (Auxiliar.isLog())
        {
            Menu1.Visible = true;
            res = false;
            sair.Visible = false;

        }
        else
        {

            /*
            string SqlStr = "SELECT * FROM Cliente WHERE usuario = @usuario ";
            SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
            Cmd.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
            SqlCnn.Open();
            SqlDataReader Dados = Cmd.ExecuteReader();



            if (Dados.HasRows)
            {
                Menu4.Visible = true;
                res = false;
            }

            Dados.Close();
            SqlCnn.Close();

              
             */
            if (Auxiliar.isCliente())
            {
                Menu4.Visible = true;
                res = false;
                imgC.Visible = true;
                textC.Visible = true;

            }

            /*
            string SqlStr2 = "SELECT * FROM Veterinario WHERE usuario = @usuario ";

            SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
            Cmd2.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
            SqlCnn.Open();
            SqlDataReader Dados2 = Cmd2.ExecuteReader();



            if (Dados2.HasRows)
            {
                Dados2.Read();
                Menu3.Visible = true;
                res = false;
                String dni = Dados2.GetString(0);
                Dados2.Close();
               
            */

            if(Auxiliar.isVeterinario()){
                imgV.Visible = true;
                textV.Visible = true;
                Menu3.Visible = true;
                res = false;
                String dni=Auxiliar.dniCurrent();


            
                //Comprobar si hay nuevas notificaciones. 
                string SqlStr3 = "SELECT * FROM Peticion WHERE dniVeterinario = @dni AND Pendiente='true' ";
                SqlCnn.Open();

                SqlCommand Cmd3 = new SqlCommand(SqlStr3, SqlCnn);
                Cmd3.Parameters.AddWithValue("@dni",dni );
                SqlDataReader Dados3 = Cmd3.ExecuteReader();

                if (Dados3.HasRows)
                {

                    imgR1.Visible = true;
                    textR1.Visible = true; 
                }
                
                Dados3.Close();

            }


            SqlCnn.Close();



        }

        //Si estas logueado, pero no eres ni veterinario ni cliente.
        if (res)
        {
            Menu2.Visible = true;


        }

       


    }
}
   


