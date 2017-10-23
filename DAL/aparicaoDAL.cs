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

                    string sql = "  Insert into APARICAO Values(@apa_ID_USU, @apa_ID_ANI, @apa_COMENTARIO, @apa_VALIDADO, @apa_LATITUDE, @apa_LONGITUDE )";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@apa_ID_USU", objApar.apa_ID_USU);
                    cmd.Parameters.AddWithValue("@apa_ID_ANI", objApar.apa_ID_ANI);
                    cmd.Parameters.AddWithValue("@apa_COMENTARIO", objApar.apa_COMENTARIO);
                    cmd.Parameters.AddWithValue("@apa_VALIDADO", objApar.apa_VALIDADO);
                    cmd.Parameters.AddWithValue("@apa_LATITUDE", objApar.apa_LATITUDE);
                    cmd.Parameters.AddWithValue("@apa_LONGITUDE", objApar.apa_LONGITUDE);

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
                        Apa.apa_COMENTARIO = dr["apa_COMENTARIO"].ToString();
                        Apa.apa_LATITUDE = Convert.ToDecimal(dr["apa_LATITUDE"]);
                        Apa.apa_LONGITUDE = Convert.ToDecimal(dr["apa_LONGITUDE"]);
                        Apa.apa_VALIDADO = Convert.ToBoolean(dr["apa_VALIDADO"]);
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

                    string sql = "UPDATE ANIMAL SET apa_ID_USU=@apa_ID_USU, apa_ID_ANI=@apa_ID_ANI, apa_COMENTARIO=@apa_COMENTARIO, apa_VALIDADO=@apa_VALIDADO, apa_LATITUDE=@apa_LONGITUDE WHERE apa_ID=@apa_ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@apa_ID_USU", objApar.apa_ID_USU);
                    cmd.Parameters.AddWithValue("@apa_ID_ANI", objApar.apa_ID_ANI);
                    cmd.Parameters.AddWithValue("@apa_COMENTARIO", objApar.apa_COMENTARIO);
                    cmd.Parameters.AddWithValue("@apa_VALIDADO", objApar.apa_VALIDADO);
                    cmd.Parameters.AddWithValue("@apa_LATITUDE", objApar.apa_LATITUDE);
                    cmd.Parameters.AddWithValue("@apa_LONGITUDE", objApar.apa_LONGITUDE);
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

