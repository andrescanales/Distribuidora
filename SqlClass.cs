using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Distribuidora
{
    class SqlClass
    {
        public SqlConnection conexion() {
            string cadena = "Server=CANALES-PC\\SQLEXPRESS;User ID=Andres;Initial catalog=Distribuidora;Integrated security=true;";
            SqlConnection objeto = new SqlConnection();
            objeto.ConnectionString = cadena;
            objeto.Open();
            return objeto;
        }

        public SqlDataAdapter adapter(string query, SqlConnection con) {
            SqlDataAdapter objeto = new SqlDataAdapter(query, con);
            return objeto;
        }

        public SqlCommand sqlquery(string query, SqlConnection con) {
            SqlCommand obj_query = new SqlCommand(query, con);
            return obj_query;
        }
    }
}
