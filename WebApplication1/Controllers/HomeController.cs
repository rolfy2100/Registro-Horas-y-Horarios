using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class HomeController : Controller
    {
        //Muestro pagina de logueo
        public ActionResult Index()
        {
            return View();
        }

        //Dirigir a paginar para registrar liquidador
        public ActionResult RegistrarLiquidador()
        {
            return View("RegistrarLiquidador");
        }

        public ActionResult AgregarLiquidador(string user, string contra, string nombres, string apellidos, long dni, string fechanacimiento, string estadocivil, string direccion, string mail, string usuario, string contraseña, string imagen)
        {

            //if (user != null && contra != null && nombres != null && apellidos != null && fechanacimiento != null && estadocivil != null && direccion != null && direccion != null && mail != null && usuario != null && contraseña != null)
            //{
                if (user == "jefa" && contra == "1234")
                {
                    Liquidador liquidador = new Liquidador();
                    liquidador.Nombres = nombres;
                    liquidador.Apellidos = apellidos;
                    liquidador.DNI = dni;
                    liquidador.FechaNacimiento = fechanacimiento;
                    liquidador.EstadoCivil = estadocivil;
                    liquidador.Direccion = direccion;
                    liquidador.Mail = mail;
                    liquidador.Usuario = usuario;
                    liquidador.Contraseña = contraseña;
                    liquidador.Imagen = imagen;

                    LiquidadorManager manager = new LiquidadorManager();
                    manager.Agregar(liquidador);
                    return View("MensajeLiquidadorAgregado");
                }
                else
                {
                    TempData["Error"] = "El usuario no existe ";
                    TempData["Error2"] = "o se ha accedido una contraseña invalida";
                    return RedirectToAction("RegistrarLiquidador");
                }
            //}            
        }
        
        //Loguearse
        public ActionResult Home()
        {
            return View("InicioOperador");
        }

        public ActionResult HomeLiquidador()
        {
            LiquidadorManager manager = new LiquidadorManager();
            List<Operadores> operadores = manager.Consultar();
            ViewBag.Operadores = operadores;

            return View("InicioLiquidador");
        }
        //Deslogueo, registro de horas trabajadas

        //Mostrar horas trabajadas en el perfil del operador
        public ActionResult RegistroOperador(int operador)
        {
            RegistroHorasManager manager = new RegistroHorasManager();
            List<RegistroHorasHorarios> registro = manager.ConsultarTodos(operador);
            ViewBag.Registro = registro;
            return View();
        }

        //Mostrar horas trabajadas en el perfil del liquidador

        public ActionResult AgregarOperador()
        {
            return View("AgregarOperador");
        } 
        public ActionResult NuevoOperador(string nombres, string apellidos, long dni, string fechanacimiento, string estadocivil, string direccion, string mail, string usuario, string contraseña, string imagen)
        {
            Operadores operadores = new Operadores();
            operadores.Nombres = nombres;
            operadores.Apellidos = apellidos;
            operadores.DNI = dni;
            operadores.FechaNacimiento = fechanacimiento;
            operadores.EstadoCivil = estadocivil;
            operadores.Direccion = direccion;
            operadores.Mail = mail;
            operadores.Usuario = usuario;
            operadores.Contraseña = contraseña;
            operadores.Imagen = imagen;

            OperadoresManager manager = new OperadoresManager();
            manager.Agregar(operadores);
            return View("MensajeOperadorAgregado");
        }
        public ActionResult ConsultarRegistro(string fechon)
        {
            RegistroHorasHorarios registroshoras1 = new RegistroHorasHorarios();
            RegistroHorasManager manager = new RegistroHorasManager();
            manager.Consultar(fechon);

            ViewBag.Registro = registroshoras1;


            return View("RegistroOperador");
        }
    }
}