﻿using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAPI.Models
{
    public class DALUsuario
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;

        public void CadastrarUsuario(Usuario _usu)
        {        
        SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();

                string sql = "insert into USUARIO Values(@nome,0,@email,@senha,0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", _usu.usu_Nome);
                cmd.Parameters.AddWithValue("@img", _usu.usu_IMG);
                cmd.Parameters.AddWithValue("@email", _usu.usu_Email);
                cmd.Parameters.AddWithValue("@senha", _usu.usu_Senha);

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

        public bool ValidarUsuario(string email, string senha)
        {

            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = "select * from USUARIO where usu_Email = @email AND usu_Senha = @senha ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                    return true;
                else
                    return false;

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

        public Usuario BuscarUsuarioporNome(string nome)
        {
            Usuario _usu = new Usuario();
            SqlConnection conn = new SqlConnection(connectionStr);

            try
            {
                conn.Open();
                string sql = "select * from USUARIO where usu_Nome = @nome";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    _usu.usu_ID = Convert.ToInt32(dr["usu_ID"]);
                    _usu.usu_Nome = dr["usu_Nome"].ToString();
                    _usu._usu_IMG = (byte[])dr["_usu_IMG"];
                    _usu.usu_Email = dr["usu_Email"].ToString();
                    _usu.usu_Senha = dr["usu_Senha"].ToString();
                    _usu.usu_ADM = Convert.ToBoolean(dr["usu_ADM"]);
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
            return _usu;
        }
    }
}