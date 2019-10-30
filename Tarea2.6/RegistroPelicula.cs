using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tarea2._6.Models;

namespace Tarea2._6
{
    public class RegistroPelicula
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConsTr"].ToString();
            con = new SqlConnection(constr);
        }
        public int GrabarPelicula(Peliculas peli)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO TBL_Peliculas(Titulo,Director,AutorPrincipal,No_Actores,Duracion,Estreno)" +
                    "VALUES" +
                "(@Titulo, @Director, @AutorPrincipal,@No_Actores,@Duracion,@Estreno)", con);

            comando.Parameters.AddWithValue("@Titulo", peli.Titulo);
            comando.Parameters.AddWithValue("@Director", peli.Director);
            comando.Parameters.AddWithValue("@AutorPrincipal", peli.AutorPrincipal);
            comando.Parameters.AddWithValue("@No_Actores", peli.numAutores);
            comando.Parameters.AddWithValue("@Duracion", peli.Duracion);
            comando.Parameters.AddWithValue("@Estreno", peli.Estreno);
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Peliculas> GetAll()
        {
            Conectar();
            List<Peliculas> peliculas = new List<Peliculas>();
            string sqlString =
                "SELECT * FROM TBL_Peliculas";
            SqlCommand comando = new SqlCommand(sqlString, con);

            //Podemos mejorar el codigo, utilizando un try....

            con.Open(); //Abrimos la conexion a la DB.
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Peliculas Peli = new Peliculas
                {
                    Codigo = int.Parse(reader["Codigo"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Director = reader["Director"].ToString(),
                    AutorPrincipal = reader["AutorPrincipal"].ToString(),
                    numAutores = int.Parse(reader["No_Actores"].ToString()),
                    Duracion = double.Parse(reader["Duracion"].ToString()),
                    Estreno = int.Parse(reader["Estreno"].ToString())
                };

                peliculas.Add(Peli);
            }

            con.Close();  //Cerramos la conexión.      

            return peliculas;
        }
        public Peliculas Recuperar(int Codigo)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("Select * from TBL_Peliculas where Codigo=@Codigo",con);

            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Peliculas Peli = new Peliculas();
            if(reader.Read())
            {
                Peli.Codigo = int.Parse(reader["Codigo"].ToString());
                Peli.Titulo = reader["Titulo"].ToString();
                Peli.Director = reader["Director"].ToString();
                Peli.AutorPrincipal = reader["AutorPrincipal"].ToString();
                Peli.numAutores = int.Parse(reader["No_Actores"].ToString());
                Peli.Duracion = double.Parse(reader["Duracion"].ToString());
                Peli.Estreno = int.Parse(reader["Estreno"].ToString());
            }
            con.Close();
            return Peli;
        }
        public int Modificar(Peliculas peli)
        {
            SqlCommand comando = new SqlCommand(@"UPDATE TBL_Peliculas SET Titulo = @Titulo , Director = @Director, 
                                                    AutorPrincipal = @AutorPrincipal, No_Actores = @No_Actores, Duracion = @Duracion,
                                                    Estreno = @Estreno
                                                    WHERE Codigo = @Codigo", con);

            comando.Parameters.AddWithValue("@Codigo", peli.Codigo);
            comando.Parameters.AddWithValue("@Titulo", peli.Titulo);
            comando.Parameters.AddWithValue("@Director", peli.Director);
            comando.Parameters.AddWithValue("@AutorPrincipal", peli.AutorPrincipal);
            comando.Parameters.AddWithValue("@No_Actores", peli.numAutores);
            comando.Parameters.AddWithValue("@Duracion", peli.Duracion);
            comando.Parameters.AddWithValue("@Estreno", peli.Estreno);
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int codigo)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("DELETE FROM TBL_PELICULA WHERE Codigo = @Codigo", con);
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}