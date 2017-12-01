using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;

namespace DAL
{
    public class aparicaoDAL
    {
            string connectionString = ConfigurationManager.ConnectionStrings["BDXenarthraConnectionString"].ConnectionString;


            public void InserirAparicao(Aparicoes objApar)
            {

                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string sql = "  Insert into APARICAO Values(@apa_ID_USU, @apa_ID_ANI, @apa_Comentario, @apa_ComentarioADM, @apa_status, @apa_Latitude, @apa_Longitude, @apa_Data, @apa_IMG, apa_tipo_animal )";
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
                        Apa.apa_status = Convert.ToBoolean(dr["apa_status"]);
                        Apa.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        Apa.apa_Longitude = Convert.ToDecimal(dr["apa_Longitude"]);
                        Apa.apa_Data = Convert.ToDateTime(dr["apa_Data"]).Date;
                        //Apa.apa_IMG = Convert.ToByte(dr["apa.IMG"]);
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

