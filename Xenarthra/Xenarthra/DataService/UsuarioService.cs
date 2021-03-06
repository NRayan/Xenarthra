﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xenarthra.Models;

namespace Xenarthra.DataService
{
    public class UsuarioService
    {
        HttpClient client = new HttpClient();
        string Host = "http://xenarthra.somee.com";

        public async Task<bool> ValidarUsuario(string email, string senha)
        {
            try
            {
                string url = Host + "/api/Usu2?email=" + email + "&Senha=" + senha;
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<bool>(resposta);
                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CadastrarUsuario(Usuario usu)
        {
            try
            {
                string url = Host + "/api/Usu1/";
                var uri = new Uri(string.Format(url, usu.usu_ID));
                var data = JsonConvert.SerializeObject(usu);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                    throw new Exception("Erro ao incluir Usuário");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> BuscarUsuarioporEmail(string email)
        {
            try
            {
                string url = Host + "/api/USU3?email=" + email.ToString();
                var resposta = await client.GetStringAsync(url);
                var endr = JsonConvert.DeserializeObject<Usuario>(resposta);

                return endr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
