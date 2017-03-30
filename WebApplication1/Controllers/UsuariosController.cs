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
                return RedirectToAction("Home", "Home");
            }
            else
            {
                if (liquidador1 != null && liquidador1.DNI != 0) 
                {
                    Session["LiquidadorLogueado"] = liquidador1;
                    return RedirectToAction("HomeLiquidador", "Home");
                }
                else
                { 
                    //EL USUARIO NO EXISTE O ESTA MAL LA CONTRASEÑA
                    TempData["Error"] = "El usuario no existe o se ha accedido una contraseña invalida";
                    return RedirectToAction("Index","Home");
                }
            }
        }


        public ActionResult Salir(int operador, string fechaentrada, string horaentrada, string horasalida, string horastrabajadas, string mes, int contador)
        {

            if (Session["UsuarioLogueado"] != null)
                {
                    RegistroHorasHorarios horashorarios = new RegistroHorasHorarios();
                    RegistroHorasManager registrohoras = new RegistroHorasManager();
                    horashorarios.FechaEntrada = fechaentrada;
                    horashorarios.HoraEntrada = horaentrada;
                    horashorarios.HoraSalida = horasalida;
                    horashorarios.Conteo = contador;
                    horashorarios.HorasTrabajadas = horastrabajadas;
                    horashorarios.Mes = mes;
                    registrohoras.AgregarRegistro(horashorarios, operador);
                    ViewBag.Usuario = Session["UsuarioLogueado"];
                    Session["UsuarioLogueado"] = null;
                    return View("MensajeSalida");
                }
                else
                {
                    TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                    return RedirectToAction("Home, Index");
                }
            
            
        }
        public ActionResult SalirLiquidador()
        {
            if (Session["LiquidadorLogueado"] != null)
            {
                Session["LiquidadorLogueado"] = null;
                return View("Salida");
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Home, Index");
            }
        }
    }
}