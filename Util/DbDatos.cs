
using System.Data;
using Microsoft.Data.SqlClient;

namespace App_Tareas.Util
{

    public class DBDatos : IDBDatos
    {
        // public static string cadenaConnection = "Data Source=VASIEPC\\SQLEXPRESS; Initial Catalog=TareasDb;Trusted_Connection=True;Integrated Security=True; TrustServerCertificate=True";

        // protected readonly SqlServerConfiguration _connectionString;
        protected SqlConnection Conexion;
        // public DBDatos(SqlServerConfiguration connectionString)
        // {
        //     _connectionString = connectionString;
        // }

        public DBDatos(SqlConnection conexion)
        {
            Conexion = conexion;
        }

        // protected SqlConnection SqlServerConnection()
        // {
        //     return new SqlConnection(_connectionString.ConnectionString);
        // }

        public DataSet ListarTablas(
            string nombreProcedimiento,
            List<Parametro>? parametros = null)
        {
            // SqlConnection conexion = new SqlConnection(cadenaConnection);

            var conexion = Conexion;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;

            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }


        }

        public DataTable ListarTabla(
          string nombreProcedimiento,
          List<Parametro>? parametros = null)
        {
            Console.WriteLine("hola");
            // SqlConnection conexion = new SqlConnection(cadenaConnection);

            var conexion = Conexion;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                return tabla;

            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }


        }

        public bool Ejecutar
            (string nombreProcedimiento,
            List<Parametro>? parametros)
        {
            // SqlConnection conexion = new SqlConnection(cadenaConnection);
            var conexion = Conexion;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();
                return (i < 0) ? true : false;

            }
            catch (System.Exception)
            {

                throw;
            }

            finally
            {
                conexion.Close();
            }
        }
    }

    public interface IDBDatos
    {
        DataSet ListarTablas(string nombreProcedimiento,
                List<Parametro>? parametros = null);
        DataTable ListarTabla(string nombreProcedimiento,
                List<Parametro>? parametros = null);
        bool Ejecutar(string nombreProcedimiento,
                List<Parametro>? parametros = null);

    }

}

