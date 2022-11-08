using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_AdminIES.DLL
{
    internal class EstudianteDLL
    {
        Conexion conexion;
        public EstudianteDLL()
        {
            conexion = new Conexion();
        }
        public bool Agregar(string nombreCiclo)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO Ciclo(nombre) VALUES ('{nombreCiclo}')");
        }

        public DataSet MostrarCiclos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM ciclo");
            return conexion.EjecutarSentencia(sentencia);
        }

        internal void Borrar(string id)
        {
            conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM ciclo WHERE id={id}");
        }

        internal void Modificar(string id, string nombre)
        {
            conexion.EjecutarComandoSinRetornarDatos($"UPDATE ciclo SET nombre='{nombre}' WHERE id={id}");
        }
    }
}
