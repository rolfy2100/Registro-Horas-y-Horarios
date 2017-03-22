using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication16.Models;

namespace WebApplication1.Models
{
    public class LiquidadorManager
    {
        public void Agregar(Liquidador liquidador)
        {
            SqlConnection conexion = new SqlConnection("Server=DESKTOP-L10RHV9\\SQLEXPRESS;Database=RegistroHorasOperadores;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "insert into Liquidador (Nombres, Apellidos, DNI, FechaNacimiento, EstadoCivil, Direccion, Mail, Usuario, Contraseña, Imagen) VALUES (@Nombres, @Apellidos, @DNI, @FechaNacimiento, @EstadoCivil, @Direccion, @Mail, @Usuario, @Contraseña, @Imagen)";
            sentencia.Parameters.AddWithValue("@Nombres", liquidador.Nombres);
            sentencia.Parameters.AddWithValue("@Apellidos", liquidador.Apellidos);
            sentencia.Parameters.AddWithValue("@DNI", liquidador.DNI);
            sentencia.Parameters.AddWithValue("@FechaNacimiento", liquidador.FechaNacimiento);
            sentencia.Parameters.AddWithValue("@EstadoCivil", liquidador.EstadoCivil);
            sentencia.Parameters.AddWithValue("@Direccion", liquidador.Direccion);
            sentencia.Parameters.AddWithValue("@Mail", liquidador.Mail);
            sentencia.Parameters.AddWithValue("@Usuario", liquidador.Usuario);
            sentencia.Parameters.AddWithValue("@Contraseña", liquidador.Contraseña);
            sentencia.Parameters.AddWithValue("@Imagen", liquidador.Imagen);

            sentencia.ExecuteNonQuery();

            conexion.Close();
        }
        public List<Liquidador> Loguear()
        {
            List<Liquidador> liquidador = new List<Liquidador>();

            SqlConnection conexion = new SqlConnection("Server=DESKTOP-L10RHV9\\SQLEXPRESS;Database=RegistroHorasOperadores;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from Liquidador";

            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {
                Liquidador liquidador2 = new Liquidador();
                liquidador2.Usuario = reader["Usuario"].ToString();
                liquidador2.Contraseña = reader["Contraseña"].ToString();
                liquidador.Add(liquidador2);
            }
            reader.Close();

            conexion.Close();

            return liquidador;
        }
    }
}