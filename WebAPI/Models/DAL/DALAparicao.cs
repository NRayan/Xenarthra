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
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
        }       

    }
}