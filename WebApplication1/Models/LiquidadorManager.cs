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
            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
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
        public Liquidador Validar(string usuario, string contraseña)
        {
            Liquidador liquidador = new Liquidador();

            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from Liquidador where Usuario = @Usuario AND Contraseña = @Contraseña";
            sentencia.Parameters.AddWithValue("@Usuario", usuario);
            sentencia.Parameters.AddWithValue("@Contraseña", contraseña);

            SqlDataReader reader = sentencia.ExecuteReader();
            if (reader.Read()) //mientras haya un registro para leer
            {
                liquidador.Usuario = reader["Usuario"].ToString();
                liquidador.Contraseña = reader["Contraseña"].ToString();
                liquidador.DNI = (int)reader["DNI"];
            }
            reader.Close();

            conexion.Close();

            return liquidador;
        }

        internal List<Operadores> Consultar()
        {
            List<Operadores> operadores = new List<Operadores>();


            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from Operadores";
            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {
                Operadores operadores2 = new Operadores(); 
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
                operadores.Add(operadores2);
            }
            reader.Close();

            conexion.Close();

            return operadores;
        }
    }
}