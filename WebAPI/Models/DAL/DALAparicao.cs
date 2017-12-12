using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAPI.Models
{
    public class DALAparicao
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;

        public List<Aparicao> ListarAparicoesPorTipoAni(int tipo)
        {
            List<Aparicao> _aparicoes = new List<Aparicao>();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = (@"select apa.apa_ID, apa.apa_Comentario, apa.apa_ComentarioADM, apa.apa_Data,apa.apa_status,apa.apa_Latitude,apa.apa_Longitude,apa.apa_IMG,apa.apa_ID_USU,apa.apa_ID_ANI
                from APARICAO as apa
                inner join ANIMAL
                on ANIMAL.ani_ID = apa.apa_ID_ANI
                Where ani_Tipo = @tipo");

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Aparicao _apar = new Aparicao();
                        _apar.apa_ID = Convert.ToInt32(dr["apa_ID"]);
                        _apar.apa_Comentario = dr["apa_Comentario"].ToString();
                        _apar.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        _apar.apa_Data = Convert.ToDateTime(dr["apa_Data"]);
                        _apar.apa_status = Convert.ToBoolean(dr["apa_status"]);
                        _apar.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        _apar.apa_Longitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        //_apar.ani_IMG = (byte[])dr["ani_IMG"];
                        _apar.apa_ID_USU = Convert.ToInt32(dr["apa_ID_USU"]);
                        _apar.apa_ID_ANI = Convert.ToInt32(dr["apa_ID_ANI"]);
                        _aparicoes.Add(_apar);
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

            return _aparicoes;
        }

        public Aparicao BuscarAparicao(int cod)
        {
            Aparicao _apar = new Aparicao();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from APARICAO where apa_ID=@cod", conn);
                cmd.Parameters.AddWithValue("@cod", cod);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        _apar.apa_ID = Convert.ToInt32(dr["apa_ID"]);
                        _apar.apa_Comentario = dr["apa_Comentario"].ToString();
                        _apar.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        _apar.apa_Data = Convert.ToDateTime(dr["apa_Data"]);
                        _apar.apa_status = Convert.ToBoolean(dr["apa_status"]);
                        _apar.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        _apar.apa_Longitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        //_apar.ani_IMG = (byte[])dr["ani_IMG"];
                        _apar.apa_ID_USU = Convert.ToInt32(dr["apa_ID_USU"]);
                        _apar.apa_ID_ANI = Convert.ToInt32(dr["apa_ID_ANI"]);
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

            return _apar;
        }

        public void CadastrarAparicao(Aparicao apar)
        {
            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();

                string sql = "insert into aparicao Values(@comentario,@comentarioADM,@Lati,@Longi,@Data,@img,@status,@id_usu,@id_ani)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@comentario", apar.apa_Comentario);
                cmd.Parameters.AddWithValue("@comentarioADM", apar.apa_ComentarioADM);
                cmd.Parameters.AddWithValue("@Lati", apar.apa_Latitude);
                cmd.Parameters.AddWithValue("@Longi", apar.apa_Longitude);
                // cmd.Parameters.AddWithValue("@img", _usu.usu_IMG);
                cmd.Parameters.AddWithValue("@status", apar.apa_status);
                cmd.Parameters.AddWithValue("@id_usu", apar.apa_ID_USU);
                cmd.Parameters.AddWithValue("@id_ani", apar.apa_ID_ANI);

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