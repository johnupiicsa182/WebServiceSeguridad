using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WsSeguridad
{
    public class Conexiones
    {
        public SqlConnection ConexionSeguridad() {
            String con = ConfigurationManager.ConnectionStrings["ConexionSeguridad"].ConnectionString;
            SqlConnection connection = new SqlConnection(con);
            return connection;
        } 
    }
}