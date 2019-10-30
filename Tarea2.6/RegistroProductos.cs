using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tarea2._6.Models;

namespace Tarea2._6
{
    public class RegistroProductos
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConsTr"].ToString();
            con = new SqlConnection(constr);
        }
        public List<Producto> GetAll()
        {
            Conectar();
            List<Producto> Productos = new List<Producto>();
            string sqlString =
                "SELECT * FROM Productos";
            SqlCommand comando = new SqlCommand(sqlString, con);

            //Podemos mejorar el codigo, utilizando un try....

            con.Open(); //Abrimos la conexion a la DB.
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Producto Prod = new Producto
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Descripcion = reader["Descripcion"].ToString(),
                    Tipo = reader["Tipo"].ToString(),
                    Precio = decimal.Parse(reader["Precio"].ToString())
                };

                Productos.Add(Prod);
            }

            con.Close();  //Cerramos la conexión.      

            return Productos;
        }
    }
}