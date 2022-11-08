using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_AdminIES.DLL
{
    internal class Conexion
    {
        private string cadenaConexion = "Data Source=DESKTOP-TI4PMR8; Initial Catalog=PruebaServidor; Integrated Security = True";
        SqlConnection sqlConnection;

        public SqlConnection EstablecerConnection() { 
            this.sqlConnection = new SqlConnection(this.cadenaConexion);
            return this.sqlConnection;
        }

        public bool EjecutarComandoSinRetornarDatos(string strComando)
        {
            try {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strComando;
                sqlCommand.Connection = this.EstablecerConnection();
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            } catch (Exception e) {
                return false;
            }

        }

        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand = sqlComando;
                sqlCommand.Connection = this.EstablecerConnection();
                adapter.SelectCommand = sqlCommand;
                sqlConnection.Open();
                adapter.Fill(ds);
                sqlConnection.Close();
                return ds;
            }
            catch (Exception e)
            {
                return ds;
            }

        }

    }
}
