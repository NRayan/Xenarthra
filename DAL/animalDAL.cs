using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;

namespace DAL
{
    public class animalDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BDXenarthraConnectionString"].ConnectionString;


        public void InserirAnimal(Animais objAnimal)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = " Insert into ANIMAL Values (@ani_NomeCient, @ani_Nome, @ani_IMG, @ani_Descricao, @ani_Tipo)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_NomeCient", objAnimal.ani_NomeCient);
                cmd.Parameters.AddWithValue("@ani_Nome", objAnimal.ani_Nome);
                cmd.Parameters.AddWithValue("@ani_IMG", objAnimal.ani_IMG);
                cmd.Parameters.AddWithValue("@ani_Descricao", objAnimal.ani_Descricao);
                cmd.Parameters.AddWithValue("@ani_Tipo", objAnimal.ani_Tipo);

                cmd.ExecuteNonQuery();

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
        }

        public List<Animais> ListarAnimais()
        {
            List<Animais> lista = new List<Animais>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM ANIMAL";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Animais A = null;
                    while (dr.Read())
                    {
                        A = new Animais();
                        A.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                        A.ani_NomeCient = dr["ani_NomeCient"].ToString();
                        A.ani_Nome = dr["ani_Nome"].ToString();
                        A.ani_Descricao = dr["ani_Descricao"].ToString();
                        A.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
                        //A.ani_IMG = (byte[])dr["ani_IMG"];

                        lista.Add(A);
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

            return lista;
        }

        public List<Animais> BuscarAnimaisNome(string Nome)
        {
            List<Animais> lista = new List<Animais>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM ANIMAL WHERE ani_Nome = @ani_Nome";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_Nome", Nome);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Animais A = null;
                    while (dr.Read())
                    {
                        A = new Animais();
                        A.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                        A.ani_NomeCient = dr["ani_NomeCient"].ToString();
                        A.ani_Nome = dr["ani_Nome"].ToString();
                        A.ani_Descricao = dr["ani_Descricao"].ToString();
                        A.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
                        A.ani_IMG = (byte[])dr["ani_IMG"];

                        lista.Add(A);
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

            return lista;
        }
        public Animais BuscarAnimalCodigo(int cod)
        {
            Animais A = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM ANIMAL WHERE ani_ID = @ani_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_ID", cod);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    A = new Animais();
                    A.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                    A.ani_NomeCient = dr["ani_NomeCient"].ToString();
                    A.ani_Nome = dr["ani_Nome"].ToString();
                    A.ani_Descricao = dr["ani_Descricao"].ToString();
                    A.ani_Tipo = Convert.ToInt32(dr["ani_Tipo"]);
                    A.ani_IMG = (byte[])dr["ani_IMG"];
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

            return A;
        }



       
       public void AlteraAnimal(Animais objAnimal)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "UPDATE ANIMAL SET ani_NomeCient=@ani_NomeCient, ani_Nome=@ani_Nome, ani_Tipo=@ani_Tipo, ani_Descricao=@ani_Descricao, ani_IMG=@ani_IMG WHERE ani_ID=@ani_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_ID", objAnimal.ani_ID);
                cmd.Parameters.AddWithValue("@ani_NomeCient", objAnimal.ani_NomeCient);
                cmd.Parameters.AddWithValue("@ani_Nome", objAnimal.ani_Nome);
                cmd.Parameters.AddWithValue("@ani_Tipo", objAnimal.ani_Tipo);
                cmd.Parameters.AddWithValue("@ani_Descricao", objAnimal.ani_Descricao);
                cmd.Parameters.AddWithValue("@ani_IMG", objAnimal.ani_IMG);
                cmd.ExecuteNonQuery();
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
        }


        public void ExcluirAnimal(int codigo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                string sql = "DELETE FROM ANIMAL WHERE ani_ID = @ani_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_ID", codigo);

                cmd.ExecuteNonQuery();
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
        }
        public int BuscarCodUltimoAnimal()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            int codigo = 0;
            try
            {
                conn.Open();

                string sql = " select top 1 ani_ID from ANIMAL order by ani_ID desc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    codigo = Convert.ToInt32(dr["ani_ID"]);
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

            return codigo;
        }
    }
}

