using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication16.Models;

namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios

        public ActionResult DoLogin(string usuario, string contraseña)
        {
            OperadoresManager manager = new OperadoresManager();
            Operadores operadores2 = manager.Validar(usuario, contraseña);
            LiquidadorManager manager2 = new LiquidadorManager();
            Liquidador liquidador1 = manager2.Validar(usuario, contraseña);

            if (operadores2 != null)
            {
                //ESTÁ BIEN
                Session["UsuarioLogueado"] = operadores2;
            }
            else
            {
                if (liquidador1 != null)
                {
                    return RedirectToAction("HomeLiquidador", "Home");
                }
                //EL USUARIO NO EXISTE O ESTA MAL LA CONTRASEÑA
                TempData["Error"] = "El usuario no existe o está mal la contraseña";
            }
            return RedirectToAction("Home", "Home");
        }


        public ActionResult Salir(int operador,string fechaentrada, string horaentrada, string horasalida, int horastrabajadas)
        {
            RegistroHorasHorarios horashorarios = new RegistroHorasHorarios();
            RegistroHorasManager registrohoras = new RegistroHorasManager();
            horashorarios.FechaEntrada = fechaentrada;
            horashorarios.HoraEntrada = horaentrada;
            horashorarios.HoraSalida = horasalida;
            horashorarios.HorasTrabajadas = horastrabajadas;
            registrohoras.AgregarRegistro(horashorarios, operador); 
            ViewBag.Usuario = Session["UsuarioLogueado"];
            Session["UsuarioLogueado"] = null;
            return View("MensajeSalida");
        }
    }
}