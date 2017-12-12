using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Xenarthra.Models.extra;
using WebAPI.Models.extra;
using System.Text;

namespace WebAPI.Models
{
    public class DALAparicao
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["conexaoSQLServerLocal"].ConnectionString;      

        public List<Aparicao_Extended> ListarAparicoesPorTipoAni(int tipo)
        {
            List<Aparicao_Extended> _aparicoes = new List<Aparicao_Extended>();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = (@"select a.apa_ID, a.apa_Comentario, a.apa_ComentarioADM, a.apa_Data,a.apa_status,a.apa_Latitude,a.apa_Longitude,a.apa_IMG,a.apa_ID_USU,a.apa_ID_ANI,USUARIO.usu_Nome,USUARIO.usu_IMG,ANIMAL.ani_Nome
                    from APARICAO as a
                    inner join ANIMAL
                    on ANIMAL.ani_ID = a.apa_ID_ANI
                    inner join USUARIO
                    on USUARIO.usu_ID = a.apa_ID_USU
                    Where ani_Tipo = @tipo and a.apa_status=2");

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Aparicao_Extended _apar = new Aparicao_Extended();
                        _apar.apa_ID = Convert.ToInt32(dr["apa_ID"]);
                        _apar.apa_Comentario = dr["apa_Comentario"].ToString();
                        _apar.apa_ComentarioADM = dr["apa_ComentarioADM"].ToString();
                        _apar.apa_Data = Convert.ToDateTime(dr["apa_Data"]);
                        _apar.apa_status = Convert.ToInt32(dr["apa_status"]);
                        _apar.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        _apar.apa_Longitude = Convert.ToDecimal(dr["apa_Longitude"]);
                        //_apar.ani_IMG = (byte[])dr["ani_IMG"];
                        _apar.apa_ID_USU = Convert.ToInt32(dr["apa_ID_USU"]);
                        _apar.apa_ID_ANI = Convert.ToInt32(dr["apa_ID_ANI"]);
                        _apar.usu_Nome = dr["usu_Nome"].ToString();
                        //_apar.usu_IMG= (byte[])dr["usu_IMG"];
                        _apar.ani_Nome = dr["ani_Nome"].ToString();
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
        public List<Pino_Mapa> ListarPinosPorTipoAni(int tipo)
        {
            List<Pino_Mapa> _Pinos = new List<Pino_Mapa>();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = (@"select a.apa_ID,a.apa_Latitude,a.apa_Longitude,USUARIO.usu_Nome,ANIMAL.ani_Nome
                from APARICAO as a
                inner join ANIMAL
                on ANIMAL.ani_ID = a.apa_ID_ANI
				inner join USUARIO
				on USUARIO.usu_ID = a.apa_ID_USU
                Where ani_Tipo = @tipo and a.apa_status=2");

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Pino_Mapa _pino = new Pino_Mapa();
                        _pino.apa_ID = Convert.ToInt32(dr["apa_ID"]);
                        _pino.apa_Latitude = Convert.ToDecimal(dr["apa_Latitude"]);
                        _pino.apa_Longitude = Convert.ToDecimal(dr["apa_Longitude"]);
                        _pino.usu_Nome = dr["usu_Nome"].ToString();
                        _pino.ani_Nome = dr["ani_Nome"].ToString();
                        _Pinos.Add(_pino);
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

            return _Pinos;
        }
        public Aparicao_Extended BuscarAparicao(int cod)
        {
            Aparicao_Extended _apar = new Aparicao_Extended();

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"select a.apa_ID, a.apa_Comentario, a.apa_ComentarioADM, a.apa_Data,a.apa_IMG,USUARIO.usu_Nome,USUARIO.usu_IMG,ANIMAL.ani_Nome
                    from APARICAO as a
                    inner join ANIMAL
                    on ANIMAL.ani_ID = a.apa_ID_ANI
                    inner join USUARIO
                    on USUARIO.usu_ID = a.apa_ID_USU
                    Where apa_ID=@cod", conn);

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
                        _apar.apa_IMG = ByteArrayToString((byte[])dr["apa_IMG"]);
                        _apar.usu_IMG = ByteArrayToString((byte[])dr["usu_IMG"]);
                        _apar.usu_Nome= dr["usu_Nome"].ToString();
                        _apar.ani_Nome = dr["ani_Nome"].ToString();
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

                string sql = "insert into aparicao Values(@comentario,null,@Lati,@Longi,@Data,@img,1,@id_usu,1)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@comentario", apar.apa_Comentario);
                cmd.Parameters.AddWithValue("@Lati", apar.apa_Latitude);
                cmd.Parameters.AddWithValue("@Longi", apar.apa_Longitude);
                cmd.Parameters.AddWithValue("@Data", apar.apa_Data.ToString());
                cmd.Parameters.AddWithValue("@img",StringToByteArray( apar.apa_IMG));
                cmd.Parameters.AddWithValue("@id_usu", apar.apa_ID_USU);

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

        public void AtualizarAparicao(int apa_id, string apa_comentarioadm, int apa_status, int apa_id_ani)
        {
            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();

                string sql = @"UPDATE APARICAO
                               SET apa_ComentarioAdm = @apa_comentarioadm, apa_status = @apa_status, apa_ID_ANI = @apa_id_ani
                               WHERE apa_ID = @apa_id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@apa_id", apa_id);
                cmd.Parameters.AddWithValue("@apa_comentarioadm", apa_comentarioadm);
                cmd.Parameters.AddWithValue("@apa_status", apa_status);
                cmd.Parameters.AddWithValue("@apa_id_ani", apa_id_ani);

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