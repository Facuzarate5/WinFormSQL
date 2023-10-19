using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsEjemploSQL; 

namespace WindowsFormsEjemploSQL
{
    internal class EmpleadoConexionSQL
    {
        private string connectionString;

        public EmpleadoConexionSQL()
        {


            //connectionString = $"Server=localhost\\SQLEXPRESS;Database={databaseName};User Id={user};Password=TU_CONTRASEÑA_AQUÍ;";

            //conexion.ConnectionString = "data source=localhost\\SQLEXPRESS; initial catalog=Ejemplo; integrated security=sspi";
            connectionString = "data source=localhost\\SQLEXPRESS; initial catalog=Ejemplo; integrated security=sspi";
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = "data source=localhost\\SQLEXPRESS; initial catalog=Ejemplo; integrated security=sspi";
                connection.Open();

               
                string query = "SELECT * FROM Productos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leo los datos de los empleados desde la base de datos
                            int id = reader.GetInt32(0); 
                            string nombre = reader.GetString(1); 
                            string descripcion = reader.GetString(2); 
                            decimal precio = reader.GetDecimal(3); 

                            // Creao un objeto Empleado y lo agrego a la lista
                            Empleado empleado = new Empleado(id, nombre, descripcion, precio);
                            empleados.Add(empleado);
                        }
                    }
                }
            }

            return empleados;
        }
    }
}
