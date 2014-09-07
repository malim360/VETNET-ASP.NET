using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Auxiliar
/// </summary>
public static class Auxiliar
{

    

   

    public static Boolean isVeterinario()
    {

        string CnnString = ConfigurationManager.
        ConnectionStrings["BaseDadosSQL"].ConnectionString;
        SqlConnection SqlCnn = new SqlConnection(CnnString);
        Boolean res = false;



        string SqlStr2 = "SELECT * FROM Veterinario WHERE usuario = @usuario ";

            SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
            Cmd2.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
            SqlCnn.Open();
            SqlDataReader Dados2 = Cmd2.ExecuteReader();



            if (Dados2.HasRows)
            {
                res = true;
            }

            SqlCnn.Close();

            Dados2.Close();


        return res;

    }


    public static Boolean isCliente()
    {

        string CnnString = ConfigurationManager.
        ConnectionStrings["BaseDadosSQL"].ConnectionString;
        SqlConnection SqlCnn = new SqlConnection(CnnString);
        Boolean res = false;



        string SqlStr2 = "SELECT * FROM Cliente WHERE usuario = @usuario ";

        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados2 = Cmd2.ExecuteReader();



        if (Dados2.HasRows)
        {
            res = true;
        }

        SqlCnn.Close();

        Dados2.Close();


        return res;

    }
    public static Boolean isLog()
    {
        return (HttpContext.Current.User.Identity.Name.Length == 0);

    }

    public static String dniCurrent()
    {


        string CnnString = ConfigurationManager.
        ConnectionStrings["BaseDadosSQL"].ConnectionString;
        SqlConnection SqlCnn = new SqlConnection(CnnString);
        String dni="";



        string SqlStr2 = "SELECT * FROM Cliente WHERE usuario = @usuario ";
        SqlCommand Cmd2 = new SqlCommand(SqlStr2, SqlCnn);
        Cmd2.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados2 = Cmd2.ExecuteReader();

        if (Dados2.HasRows)
        {
            Dados2.Read();
            dni = Dados2.GetString(0);
        }

        SqlCnn.Close();
        Dados2.Close();



        string SqlStr = "SELECT * FROM Veterinario WHERE usuario = @usuario ";
        SqlCommand Cmd = new SqlCommand(SqlStr, SqlCnn);
        Cmd.Parameters.AddWithValue("@usuario", HttpContext.Current.User.Identity.Name);
        SqlCnn.Open();
        SqlDataReader Dados = Cmd.ExecuteReader();
        if (Dados.HasRows)
        {
            Dados.Read();
            dni = Dados.GetString(0);

        }

        Dados.Close();
        SqlCnn.Close();

        return dni;

    }
}