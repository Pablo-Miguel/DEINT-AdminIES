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
            Boolean estado = false;

            if (conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO estudiante " +
                $"(nombre, primerapellido, segundoapellido, email) " +
                $"VALUES ('{nombre}', '{primerApell}', '{segundoApell}', '{email}')")) {
                estado = true;
            }

            SqlCommand sentencia = new SqlCommand("SELECT MAX(id) as 'id_max' FROM estudiante");
            DataSet ds = conexion.EjecutarSentencia(sentencia);

            if (conexion.EjecutarComandoSinRetornarDatos($"INSERT INTO Alumno_Asignar_Ciclo (id_estudiante, id_ciclo) " +
                $"VALUES ({ds.Tables[0].Rows[0]["id_max"]}, {ciclo})")) {
                estado = true;
            }

            return estado;
        }

        public DataSet MostrarEstudiantes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM estudiante");
            return conexion.EjecutarSentencia(sentencia);
        }

        internal void Borrar(string id)
        {
            conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM estudiante WHERE id={id}");
            conexion.EjecutarComandoSinRetornarDatos($"DELETE FROM Alumno_Asignar_Ciclo WHERE id_estudiante={id}");
        }

        internal void Modificar(string id, string nombre, string primerApell, string segundoApell, string email, string ciclo)
        {
            conexion.EjecutarComandoSinRetornarDatos($"UPDATE ciclo SET nombre='{nombre}', " +
                $"primerapellido='{primerApell}', " +
                $"segundoapellido='{segundoApell}', " +
                $"email='{email}'" +
                $"WHERE id={id}");
            conexion.EjecutarComandoSinRetornarDatos($"UPDATE Alumno_Asignar_Ciclo SET id_ciclo='{nombre}', " +
                $"WHERE id_estudiante={id}");
        }

        internal DataSet obtenerCiclo(string id)
        {
            SqlCommand sentencia = new SqlCommand($"SELECT C.nombre FROM " +
                $"Alumno_Asignar_Ciclo A JOIN ciclo C ON A.id_ciclo = C.id " +
                $"WHERE A.id_estudiante={id}");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
