using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RoldanIgnacio_DASParcial01
{
    public class UniversidadDB
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Universidad;Integrated Security=true;";
        //private string connectionString = "Data Source=LegionNachi\\MSSQLSERVER01;Initial Catalog=Universidad;Integrated Security=true;";


        public List<Alumnos> Get()
        {
            List<Alumnos> ListaAlumnos = new List<Alumnos>();

                string query = "select IdAlumno, Nombre, Apellido,DNI, Codigo_Carrera from Alumnos";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumnos Alumnos1 = new Alumnos();
                        Alumnos1.Id = reader.GetInt32(0);
                        Alumnos1.Nombre = reader.GetString(1);
                        Alumnos1.Apellido = reader.GetString(2);
                        Alumnos1.DNI = reader.GetInt32(3);
                        Alumnos1.Codigo_Carrera = reader.GetString(4);
                        ListaAlumnos.Add(Alumnos1);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos" + ex.Message);
                }
            }
            return ListaAlumnos;
        }

        public Alumnos GetAlumno(int _id)
        {
            string query = "select IdAlumno, Nombre, Apellido, DNI, Codigo_Carrera from Alumnos" + " where IdAlumno=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", _id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Alumnos Alumnos1 = new Alumnos();
                    Alumnos1.Id = reader.GetInt32(0);
                    Alumnos1.Nombre = reader.GetString(1);
                    Alumnos1.Apellido = reader.GetString(2);
                    Alumnos1.DNI = reader.GetInt32(3);
                    Alumnos1.Codigo_Carrera = reader.GetString(4);

                    reader.Close();
                    connection.Close();
                    return Alumnos1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos" + ex.Message);
                }
            }
        }


        public void Add(string _nombre, string _apellido, int _dni, string _codigo)
        {
            string query = "insert into Alumnos(Nombre, Apellido, DNI, Codigo_Carrera) values" + "(@nombre, @apellido, @dni, @codigo) ";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", _nombre);
                command.Parameters.AddWithValue("@apellido", _apellido);
                command.Parameters.AddWithValue("@dni", _dni);
                command.Parameters.AddWithValue("@codigo", _codigo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos" + ex.Message);
                }
            }
        }

        public void Update(string _nombre, string _apellido, int _dni, string _codigo, int _id)
        {
            string query = "update Alumnos set Nombre=@nombre, Apellido=@apellido, DNI=@dni, Codigo_Carrera=@codigo" + " where IdAlumno=@id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", _nombre);
                command.Parameters.AddWithValue("@apellido", _apellido);
                command.Parameters.AddWithValue("@dni",_dni);
                command.Parameters.AddWithValue("@codigo", _codigo);
                command.Parameters.AddWithValue("@id", _id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos" + ex.Message);
                }
            }
        }

        public void Remove(int _id)
        {
            string query = "delete from Alumnos" + " where IdAlumno=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", _id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos" + ex.Message);
                }
            }
        }


        public List<Alumnos> BuscarPorDNI(int _dni)
        {
            string query = "select IdAlumno, Nombre, Apellido, DNI, Codigo_Carrera from Alumnos where DNI=@dni";

            List<Alumnos> ListaFiltrada = new List<Alumnos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dni", _dni);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumnos alumno = new Alumnos
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            DNI = reader.GetInt32(3),
                            Codigo_Carrera = reader.GetString(4)
                        };
                        ListaFiltrada.Add(alumno);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos: " + ex.Message);
                }
            }
            return ListaFiltrada;
        }

    }


    public class Alumnos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Codigo_Carrera { get; set; }
    }
}
