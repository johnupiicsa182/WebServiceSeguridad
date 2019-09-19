using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WsSeguridad
{
    public class ValidacionMetodos
    {
        private bool respuesta;
        public bool ObtieneRespuesta(string usuario, string password, int sistema, SqlConnection connection) {
            try
            {
                SqlCommand command = new SqlCommand("spObtenerUsuario", connection);
                SqlDataAdapter adapter = new SqlDataAdapter("spObtenerUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@user_name", SqlDbType.VarChar).Value = usuario;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                command.Parameters.Add("@app", SqlDbType.Int).Value = sistema;
                command.Parameters.Add("@log", SqlDbType.Bit).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                respuesta = Convert.ToBoolean(command.Parameters["@log"].Value);
                connection.Close();
                command.Dispose();
                connection.Dispose();
            }
            catch (SqlException e) {
                e.GetHashCode();
            }
            return respuesta;
        }
    }
}