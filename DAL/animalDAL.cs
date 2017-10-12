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

                string sql = " Insert into ANIMAL Values (@ani_NOMECIENT, @ani_NOME, @ani_IMG, @ani_DESCRICAO, @ani_FAMILIA, @ani_IDENTIFICACAO )";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_NOMECIENT", objAnimal.ani_NOMECIENT);
                cmd.Parameters.AddWithValue("@ani_NOME", objAnimal.ani_NOME);
                cmd.Parameters.AddWithValue("@ani_IMG", objAnimal.ani_IMG);
                cmd.Parameters.AddWithValue("@ani_DESCRICAO", objAnimal.ani_DESCRICAO);
                cmd.Parameters.AddWithValue("@ani_FAMILIA", objAnimal.ani_FAMILIA);
                cmd.Parameters.AddWithValue("@ani_IDENTIFICACAO", objAnimal.ani_IDENTIFICACAO);

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
                        A.ani_NOMECIENT = dr["ani_NOMECIENT"].ToString();
                        A.ani_NOME = dr["ani_NOME"].ToString();
                        A.ani_FAMILIA = dr["ani_FAMILIA"].ToString();
                        A.ani_DESCRICAO = dr["ani_DESCRICAO"].ToString();
                        A.ani_IDENTIFICACAO = Convert.ToInt32(dr["ani_IDENTIFICACAO"]);
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
                    A = new Animais();
                    A.ani_ID = Convert.ToInt32(dr["ani_ID"]);
                    A.ani_NOMECIENT = dr["ani_NOMECIENT"].ToString();
                    A.ani_NOME = dr["ani_NOME"].ToString();
                    A.ani_FAMILIA = dr["ani_FAMILIA"].ToString();
                    A.ani_DESCRICAO = dr["ani_DESCRICAO"].ToString();
                    A.ani_IDENTIFICACAO = Convert.ToInt32(dr["ani_IDENTIFICACAO"]);
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

                string sql = "UPDATE ANIMAL SET ani_NOMECIENT=@ani_NOMECIENT, ani_NOME=@ani_NOME, ani_FAMILIA=@ani_FAMILIA, ani_IDENTIFICACAO=@ani_IDENTIFICACAO, ani_DESCRICAO=@ani_DESCRICAO, ani_IMG=@ani_IMG WHERE ani_ID=@ani_ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_ID", objAnimal.ani_ID);
                cmd.Parameters.AddWithValue("@ani_NOMECIENT", objAnimal.ani_NOMECIENT);
                cmd.Parameters.AddWithValue("@ani_NOME", objAnimal.ani_NOME);
                cmd.Parameters.AddWithValue("@ani_FAMILIA", objAnimal.ani_FAMILIA);
                cmd.Parameters.AddWithValue("@ani_IDENTIFICACAO", objAnimal.ani_IDENTIFICACAO);
                cmd.Parameters.AddWithValue("@ani_DESCRICAO", objAnimal.ani_DESCRICAO);
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
    }
}

