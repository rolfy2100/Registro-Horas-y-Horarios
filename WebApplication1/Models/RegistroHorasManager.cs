﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication16.Models;

namespace WebApplication1.Models
{
    public class RegistroHorasManager
    {
        public void AgregarRegistro(RegistroHorasHorarios horashorarios, int operador)
        {
            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "insert into RegistroHorasHorarios (Operador, FechaEntrada, HoraEntrada, HoraSalida, HorasTrabajadas, Conteo) VALUES (@Operador, @FechaEntrada, @HoraEntrada, @HoraSalida, @HorasTrabajadas, @Conteo)";
            sentencia.Parameters.AddWithValue("@Operador", operador);
            sentencia.Parameters.AddWithValue("@FechaEntrada", horashorarios.FechaEntrada);
            sentencia.Parameters.AddWithValue("@HoraEntrada", horashorarios.HoraEntrada);
            sentencia.Parameters.AddWithValue("@HoraSalida", horashorarios.HoraSalida);
            sentencia.Parameters.AddWithValue("@HorasTrabajadas", horashorarios.HorasTrabajadas);
            sentencia.Parameters.AddWithValue("@Conteo", horashorarios.Conteo);

            sentencia.ExecuteNonQuery();

            conexion.Close();
        }

        public List<RegistroHorasHorarios> ConsultarTodos(int operador)
        {

            List<RegistroHorasHorarios> registrohoras = new List<RegistroHorasHorarios>();

            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia

            sentencia.CommandText = "Select * from RegistroHorasHorarios where Operador = @Operador";
            sentencia.Parameters.AddWithValue("@Operador", operador);

            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {

                RegistroHorasHorarios registrohoras2 = new RegistroHorasHorarios();
                registrohoras2.FechaEntrada = reader["FechaEntrada"].ToString();
                registrohoras2.HoraEntrada = reader["HoraEntrada"].ToString();
                registrohoras2.HoraSalida = reader["HoraSalida"].ToString();
                registrohoras2.Conteo = (int)reader["Conteo"];
                registrohoras2.HorasTrabajadas = reader["HorasTrabajadas"].ToString();

                registrohoras.Add(registrohoras2);
            }
            reader.Close();

            conexion.Close();

            return registrohoras;
        }
        public List<RegistroHorasHorarios> ConsultarOperador(string fechon, int operador)
        {
            List<RegistroHorasHorarios> registrohoras1 = new List<RegistroHorasHorarios>();
            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "Select * from RegistroHorasHorarios where FechaEntrada = '" + fechon + "' and Operador = '" + operador + "'";

            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {
                RegistroHorasHorarios registrohoras2 = new RegistroHorasHorarios();
                registrohoras2.FechaEntrada = reader["FechaEntrada"].ToString();
                registrohoras2.HoraEntrada = reader["HoraEntrada"].ToString();
                registrohoras2.HoraSalida = reader["HoraSalida"].ToString();
                registrohoras2.Conteo = (int)reader["Conteo"];
                registrohoras2.HorasTrabajadas = reader["HorasTrabajadas"].ToString();

                registrohoras1.Add(registrohoras2);
            }
            reader.Close();

            conexion.Close();

            return registrohoras1;
        }

        public List<RegistroHorasHorarios> ConsultarLiquidador(string fechon)
        {
            List<RegistroHorasHorarios> registrohoras1 = new List<RegistroHorasHorarios>();
            SqlConnection conexion = new SqlConnection("Server=CPX-XJPS8OPFPHQ;Database=RegistroHorasHorarios;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "Select * from RegistroHorasHorarios where FechaEntrada = '" + fechon + "'";

            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {
                RegistroHorasHorarios registrohoras2 = new RegistroHorasHorarios();
                registrohoras2.FechaEntrada = reader["FechaEntrada"].ToString();
                registrohoras2.HoraEntrada = reader["HoraEntrada"].ToString();
                registrohoras2.HoraSalida = reader["HoraSalida"].ToString();
                registrohoras2.Conteo = (int)reader["Conteo"];
                registrohoras2.HorasTrabajadas = reader["HorasTrabajadas"].ToString();

                registrohoras1.Add(registrohoras2);
            }
            reader.Close();

            conexion.Close();

            return registrohoras1;
        }
    }
}