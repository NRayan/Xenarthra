using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Data;

namespace DAL
{
    public class aparicaoDAL
    {
            string connectionString = ConfigurationManager.ConnectionStrings["BDXenarthraConnectionString"].ConnectionString;
        public struct RetCatalogo
        {
           public Animais AN;
           public Aparicoes AP;
        }

            public void InserirAparicao(Aparicoes objApar)
            {

                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string sql = "  Insert into APARICAO Values(@apa_Comentario, @apa_ComentarioADM,@apa_Data,@apa_Latitude, @apa_Longitude,@apa_IMG,@apa_status,@apa_tipo_animal, @apa_ID_USU, @apa_ID_ANI)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@apa_ID_USU", objApar.apa_ID_USU);
                    cmd.Parameters.AddWithValue("@apa_ID_ANI", objApar.apa_ID_ANI);
                    cmd.Parameters.AddWithValue("@apa_Comentario", objApar.apa_Comentario);
                    cmd.Parameters.AddWithValue("@apa_ComentarioADM", objApar.apa_ComentarioADM);
                    cmd.Parameters.AddWithValue("@apa_status", objApar.apa_status);
                    cmd.Parameters.AddWithValue("@apa_Latitude", objApar.apa_Latitude);
                    cmd.Parameters.AddWithValue("@apa_Longitude", objApar.apa_Longitude);
                    cmd.Parameters.AddWithValue("@apa_Data", objApar.apa_Data);
                    cmd.Parameters.AddWithValue("@apa_IMG", objApar.apa_IMG);
                    cmd.Parameters.AddWithValue("@apa_tipo_animal", objApar.apa_tipo_animal);
                


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

        public List<RetCatalogo> BuscarAparicoesNome(string Nome)
        {
            List<RetCatalogo> lista = new List<RetCatalogo>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "Select ani_Nome,apa_ComentarioADM,apa_IMG from ANIMAL as AN inner join APARICAO as AP ON AN.ani_ID = AP.apa_ID_ANI WHERE ani_Nome = @ani_Nome";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ani_Nome", Nome);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    RetCatalogo An_AP;
                    
                    while (dr.Read())
                    {
                        An_AP = new RetCatalogo();
                        An_AP.AN.ani_Nome = dr["ani_Nome"].ToString();
                        An_AP.AP.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        //An_AP.AP.apa_IMG = (byte[])dr["apa_IMG"];

                        lista.Add(An_AP);
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

        public List<Aparicoes> BuscarAparicoesCatalogo()
        {
            List<Aparicoes> lista = new List<Aparicoes>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "Select apa_Latitude,apa_Longitude,apa_Comentario,apa_ComentarioADM,apa_IMG from APARICAO";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    
                   Aparicoes Apari;

                    while (dr.Read())
                    {
                        
                       Apari = new Aparicoes();
                       Apari.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        Apari.apa_Comentario = dr["apa_Comentario"].ToString();
                        Apari.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        Apari.apa_Longitude = Convert.ToDecimal(dr["apa_Longitude"]);
                        //Apari.apa_IMG = (byte[])dr["apa_IMG"];

                        lista.Add(Apari);
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
            public Aparicoes BuscarAparicaoCodigoAnimal(int cod)
            {
                Aparicoes Apa = null;

                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string sql = "SELECT * FROM APARICAO WHERE apa_ID_ANI = @ani_ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ani_ID", cod);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        Apa = new Aparicoes();
                        Apa.apa_ID_ANI = Convert.ToInt32(dr["apa_ID_ANI"]);
                        Apa.apa_ID_USU = Convert.ToInt32(dr["apa_ID_USU"]);
                        Apa.apa_Comentario = dr["apa_Comentario"].ToString();
                        Apa.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        //Apa.apa_status = Convert.ToInt32(dr["apa_status"]);
                        Apa.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        Apa.apa_Longitude = Convert.ToDecimal(dr["apa_Longitude"]);
                        Apa.apa_Data = Convert.ToDateTime(dr["apa_Data"]).Date;
                        //Apa.apa_IMG = (byte[])dr["apa_IMG"];
                        Apa.apa_tipo_animal = Convert.ToInt32(dr["apa_tipo_animal"]);
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

                return Apa;
            }


            public void AlteraAparicao(Aparicoes objApar)
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string sql = "UPDATE ANIMAL SET @apa_ID_USU, @apa_ID_ANI, @apa_Comentario, @apa_ComentarioADM, @apa_status, @apa_Latitude, @apa_Longitude, @apa_Data, @apa_IMG, apa_tipo_animal";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@apa_ID_USU", objApar.apa_ID_USU);
                    cmd.Parameters.AddWithValue("@apa_ID_ANI", objApar.apa_ID_ANI);
                    cmd.Parameters.AddWithValue("@apa_Comentario", objApar.apa_Comentario);
                    cmd.Parameters.AddWithValue("@apa_ComentarioADM", objApar.apa_ComentarioADM);
                    cmd.Parameters.AddWithValue("@apa_status", objApar.apa_status);
                    cmd.Parameters.AddWithValue("@apa_Latitude", objApar.apa_Latitude);
                    cmd.Parameters.AddWithValue("@apa_Longitude", objApar.apa_Longitude);
                    cmd.Parameters.AddWithValue("@apa_Data", objApar.apa_Data);
                    cmd.Parameters.AddWithValue("@apa_IMG", objApar.apa_IMG);
                    cmd.Parameters.AddWithValue("@apa_tipo_animal", objApar.apa_tipo_animal);
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


            public void ExcluirAparicao(int codigo)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();

                    string sql = "DELETE FROM APARICAO WHERE apa_ID_ANI = @apa_ID_ANI";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@apa_ID_ANI", codigo);

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

