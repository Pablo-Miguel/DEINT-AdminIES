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
        public bool Agregar(string nombre, string primerApell, string segundoApell, string email, string ciclo)
        {
            return conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO estudiante " +
                $"(nombre, primerApell, segundoApell, email, ciclo) " +
                $"VALUES ('{nombre}', '{primerApell}', '{segundoApell}', '{email}', '{ciclo}')");
        }

        public DataSet MostrarEstudiantes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM estudiante");
            return conexion.EjecutarSentencia(sentencia);
        }

        internal void Borrar(string id)
        {
            conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM estudiante WHERE id={id}");
        }

        internal void Modificar(string id, string nombre, string primerApell, string segundoApell, string email, string ciclo)
        {
            conexion.EjecutarComandoSinRetornarDatos($"UPDATE ciclo SET nombre='{nombre}', " +
                $"primerApellido='{primerApell}', " +
                $"segundoApellido='{segundoApell}', " +
                $"email='{email}', ciclo='{ciclo}' " +
                $"WHERE id={id}");
        }
    }
}
