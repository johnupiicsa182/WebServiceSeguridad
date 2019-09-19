using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WsSeguridad
{
    /// <summary>
    /// Descripción breve de WSseguridad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSseguridad : System.Web.Services.WebService
    {
        public WSseguridad()
        {

        }

        [WebMethod]
        public bool ValidarUsuario(string usuario, string password, int app) {
            Conexiones conexiones = new Conexiones();
            ValidacionMetodos metodos = new ValidacionMetodos();
            SqlConnection connection = conexiones.ConexionSeguridad();
            bool respuesta = metodos.ObtieneRespuesta(usuario, password, app, connection);
            return respuesta;
        }
    }
}