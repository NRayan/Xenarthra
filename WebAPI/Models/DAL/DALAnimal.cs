using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace WebAPI.Models
{
    public class DALAnimal
    {

        string connectionStr = ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;


        public List<Animal> ListarAnimais()
        {
            List<Animal> _animais = new List<Animal>();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ANIMAL", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Animal _ani = new Animal();
                        _ani.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                        _ani.ani_NomeCient = dr["ani_NomeCient"].ToString();
                        _ani.ani_Nome = dr["ani_Nome"].ToString();
                        _ani.ani_IMG = ByteArrayToString((byte[])dr["ani_IMG"]);
                        _ani.ani_Descricao = dr["ani_Descricao"].ToString();
                        _ani.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
                        _animais.Add(_ani);
                    }
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

            return _animais;
        }

        public List<Animal> ListarAnimaisPorTipo(int cod)
        {
            List<Animal> _animais = new List<Animal>();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from animal Where ani_tipo= @cod", conn);
                cmd.Parameters.AddWithValue("@cod", cod);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Animal _ani = new Animal();
                        _ani.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                        _ani.ani_NomeCient = dr["ani_NomeCient"].ToString();
                        _ani.ani_Nome = dr["ani_Nome"].ToString();
                        _ani.ani_IMG = ByteArrayToString((byte[])dr["ani_IMG"]);
                        _ani.ani_Descricao = dr["ani_Descricao"].ToString();
                        _ani.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
                        _animais.Add(_ani);
                    }
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

            return _animais;
        }

        public Animal BuscarAnimal(int cod)
        {
            Animal _ani = new Animal();
            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = "select * from animal Where ani_id = @cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", cod);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    _ani.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                    _ani.ani_NomeCient = dr["ani_NomeCient"].ToString();
                    _ani.ani_Nome = dr["ani_Nome"].ToString();
                    _ani.ani_IMG = ByteArrayToString((byte[])dr["ani_IMG"]);
                    _ani.ani_Descricao = dr["ani_Descricao"].ToString();
                    _ani.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
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
            return _ani;

        }
        public static string ByteArrayToString(byte[] ba) //ByteArray para String Hexadecimal
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)//String Hexadecimal para ByteArray 
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}