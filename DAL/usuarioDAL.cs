using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;

namespace DAL
{
    class usuarioDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BDXenarthraConnectionString"].ConnectionString;

        public static string CalculaCriptografia(string text)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public bool AutenticaUsuario(string Usuario, string senha)
        {
            bool Autentica = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM USUARIO WHERE usu_USUARIO = @Usuario AND usu_SENHA = @senha";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Autentica = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return Autentica;
        }
    }
}
