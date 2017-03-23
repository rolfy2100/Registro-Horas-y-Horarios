using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication16.Models;

namespace WebApplication1.Models
{
    public class OperadoresManager
    {
        public void Agregar(Operadores operadores)
        {
            SqlConnection conexion = new SqlConnection("Server=DESKTOP-L10RHV9\\SQLEXPRESS;Database=RegistroHorasOperadores;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "insert into Operadores (Nombres, Apellidos, DNI, FechaNacimiento, EstadoCivil, Direccion, Mail, Usuario, Contraseña, Imagen) VALUES (@Nombres, @Apellidos, @DNI, @FechaNacimiento, @EstadoCivil, @Direccion, @Mail, @Usuario, @Contraseña, @Imagen)";
            sentencia.Parameters.AddWithValue("@Nombres", operadores.Nombres);
            sentencia.Parameters.AddWithValue("@Apellidos", operadores.Apellidos);
            sentencia.Parameters.AddWithValue("@DNI", operadores.DNI);
            sentencia.Parameters.AddWithValue("@FechaNacimiento", operadores.FechaNacimiento);
            sentencia.Parameters.AddWithValue("@EstadoCivil", operadores.EstadoCivil);
            sentencia.Parameters.AddWithValue("@Direccion", operadores.Direccion);
            sentencia.Parameters.AddWithValue("@Mail", operadores.Mail);
            sentencia.Parameters.AddWithValue("@Usuario", operadores.Usuario);
            sentencia.Parameters.AddWithValue("@Contraseña", operadores.Contraseña);
            sentencia.Parameters.AddWithValue("@Imagen", operadores.Imagen);

            sentencia.ExecuteNonQuery();
            
            conexion.Close();
        }
        internal Operadores Validar(string usuario, string contraseña)
        {
            Operadores operadores2 = new Operadores();


            SqlConnection conexion = new SqlConnection("Server=DESKTOP-L10RHV9\\SQLEXPRESS;Database=RegistroHorasOperadores;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from Operadores where Usuario = @Usuario AND  Contraseña = @Contraseña";
            sentencia.Parameters.AddWithValue("@Usuario", usuario);
            sentencia.Parameters.AddWithValue("@Contraseña", contraseña);
            SqlDataReader reader = sentencia.ExecuteReader();
            if (reader.Read()) //mientras haya un registro para leer
            {
                operadores2.Nombres = reader["Nombres"].ToString();
                operadores2.Apellidos = reader["Apellidos"].ToString();
                operadores2.FechaNacimiento = reader["FechaNacimiento"].ToString();
                operadores2.EstadoCivil = reader["EstadoCivil"].ToString();
                operadores2.Direccion = reader["Direccion"].ToString();
                operadores2.Mail = reader["Mail"].ToString();
                operadores2.Imagen = reader["Imagen"].ToString();
                operadores2.DNI =  (int)reader["DNI"];
                operadores2.Usuario = reader["Usuario"].ToString();
                operadores2.Contraseña = reader["Contraseña"].ToString();                
            }
            else
            {
                operadores2 = null;
            }
            reader.Close();

            conexion.Close();

            return operadores2;
        }

        internal Operadores Usuarios()
        {
            Operadores operadores2 = new Operadores();


            SqlConnection conexion = new SqlConnection("Server=DESKTOP-L10RHV9\\SQLEXPRESS;Database=RegistroHorasOperadores;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from Operadores";
            SqlDataReader reader = sentencia.ExecuteReader();
            if (reader.Read()) //mientras haya un registro para leer
            {
                operadores2.Nombres = reader["Nombres"].ToString();
                operadores2.Apellidos = reader["Apellidos"].ToString();
                operadores2.FechaNacimiento = reader["FechaNacimiento"].ToString();
                operadores2.EstadoCivil = reader["EstadoCivil"].ToString();
                operadores2.Direccion = reader["Direccion"].ToString();
                operadores2.Mail = reader["Mail"].ToString();
                operadores2.Imagen = reader["Imagen"].ToString();
                operadores2.DNI = (int)reader["DNI"];
                operadores2.Usuario = reader["Usuario"].ToString();
                operadores2.Contraseña = reader["Contraseña"].ToString();
            }
            else
            {
                operadores2 = null;
            }
            reader.Close();

            conexion.Close();

            return operadores2;
        }
    }
}