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

        public ActionResult AgregarLiquidador(string user, string contra, string nombres, string apellidos, int dni, string fechanacimiento, string estadocivil, string direccion, string mail, string usuario, string contraseña, string imagen)
        {
          
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
                    if (user != "jefa" && contra != "1234")
                    {
                        TempData["Error"] = "El usuario no existe ";
                        TempData["Error2"] = "o se ha accedido una contraseña invalida";
                        return RedirectToAction("RegistrarLiquidador");
                    }
                }
            
            return RedirectToAction("RegistrarLiquidador");
        }

        //Loguearse
        public ActionResult Home()
        {
            if (Session["UsuarioLogueado"] != null)
            {
                return View("InicioOperador");
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult HomeLiquidador()
        {
            if(Session["LiquidadorLogueado"] != null)
            {
                LiquidadorManager manager = new LiquidadorManager();
                List<Operadores> operadores = manager.Consultar();
                ViewBag.Operadores = operadores;

                return View("InicioLiquidador");
            }

            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }

        }

        //Mostrar horas trabajadas en el perfil del operador
        public ActionResult RegistroOperador(int operador = 1)
        {
            if (Session["UsuarioLogueado"] != null)
                    {

                        RegistroHorasManager manager = new RegistroHorasManager();
                        List<RegistroHorasHorarios> registro = manager.ConsultarTodos(operador);
                        int segtotales = 0;
                        foreach (RegistroHorasHorarios registro1 in registro)
                        {
                            segtotales = segtotales + registro1.Conteo;
                        }

                        int seg = segtotales % 60;
                        int mininter = segtotales / 60;
                        int min = mininter % 60;
                        int hor = mininter / 60;
                        if (hor < 1)
                        {
                            hor = 0;
                        }
                        if (min < 1)
                        {
                            min = 0;
                        }


                        string hor1 = hor.ToString();
                        string min1 = min.ToString();
                        string seg1 = seg.ToString();
                        //Agrego un 0 al frente de los valores de solo un digito
                        if (hor < 10) { hor1 = '0' + hor.ToString(); }
                        if (min < 10) { min1 = '0' + min.ToString(); }
                        if (seg < 10) { seg1 = '0' + seg.ToString(); }


                        //Asi se va a mostrar las horas trabajadas en la vista
                        string horastrabajadas = hor1 + ":" + min1 + ":" + seg1;
                        ViewBag.TrabajoTotal = horastrabajadas;
                        ViewBag.Registro = registro;
                        return View();
                    }

                    else
                    {
                        TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                        return RedirectToAction("Index", "Home");
                    }
               
        }

        //Mostrar horas trabajadas en el perfil del liquidador

        public ActionResult AgregarOperador()
        {
            if(Session["LiquidadorLogueado"] != null)
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores = manager2.Consultar();
                ViewBag.Operadores = operadores;
                return View("AgregarOperador");
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult NuevoOperador(string nombres = "1", string apellidos = "1", long dni = 1, string fechanacimiento = "1", string estadocivil = "1", string direccion = "1", string mail = "1", string usuario = "1", string contraseña = "1", string imagen = "")
        {
            if (Session["LiquidadorLogueado"] != null)
            {
            //Obtengo operadores para introducirlos en el layout
            LiquidadorManager manager2 = new LiquidadorManager();
            List<Operadores> operadores2 = manager2.Consultar();
            ViewBag.Operadores = operadores2;

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
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult ConsultarRegistroOperador(string fechon="1", int operador=1, string buscador = "10")
        {
            if (Session["UsuarioLogueado"] == null)
            {       
                
                    TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                    return RedirectToAction("Index", "Home");
                
            }
            else {

                RegistroHorasHorarios registroshoras1 = new RegistroHorasHorarios();
                RegistroHorasManager manager = new RegistroHorasManager();
                List<RegistroHorasHorarios> registro = manager.ConsultarOperador(fechon, operador, buscador);
                if (registro.Count == 0)
                {
                    TempData["Error3"] = "La fecha o mes ingresado no es valido";
                    return RedirectToAction("Home");
                }
                else
                {
                    int segtotales = 0;
                    foreach (RegistroHorasHorarios registro1 in registro)
                    {
                        segtotales = segtotales + registro1.Conteo;
                    }

                    int seg = segtotales % 60;
                    int mininter = segtotales / 60;
                    int min = mininter % 60;
                    int hor = mininter / 60;
                    if (hor < 1)
                    {
                        hor = 0;
                    }
                    if (min < 1)
                    {
                        min = 0;
                    }

                    string hor1 = hor.ToString();
                    string min1 = min.ToString();
                    string seg1 = seg.ToString();
                    //Agrego un 0 al frente de los valores de solo un digito
                    if (hor < 10) { hor1 = '0' + hor.ToString(); }
                    if (min < 10) { min1 = '0' + min.ToString(); }
                    if (seg < 10) { seg1 = '0' + seg.ToString(); }

                    //Asi se va a mostrar las horas trabajadas en la vista
                    string horastrabajadas = hor1 + ":" + min1 + ":" + seg1;

                    ViewBag.TrabajoTotal = horastrabajadas;
                    ViewBag.Registro = registro;
                    return View("RegistroOperador");
                }
            }
        }

        public ActionResult ConsultarRegLiq(int operador = 1)
        {
            if (Session["LiquidadorLogueado"] == null)
            {

                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;


                RegistroHorasHorarios registroshoras1 = new RegistroHorasHorarios();
                RegistroHorasManager manager = new RegistroHorasManager();
                List<RegistroHorasHorarios> registro = manager.ConsultarLiquidador(operador);
                int segtotales = 0;
                if (registro.Count == 0)
                {
                    TempData["Error3"] = "Este mes aun no ha trabajado";
                    return RedirectToAction("HomeLiquidador");
                }
                else
                {
                    foreach (RegistroHorasHorarios registro1 in registro)
                    {
                        segtotales = segtotales + registro1.Conteo;
                    }

                    int seg = segtotales % 60;
                    int mininter = segtotales / 60;
                    int min = mininter % 60;
                    int hor = mininter / 60;
                    if (hor < 1)
                    {
                        hor = 0;
                    }
                    if (min < 1)
                    {
                        min = 0;
                    }

                    string hor1 = hor.ToString();
                    string min1 = min.ToString();
                    string seg1 = seg.ToString();
                    //Agrego un 0 al frente de los valores de solo un digito
                    if (hor < 10) { hor1 = '0' + hor.ToString(); }
                    if (min < 10) { min1 = '0' + min.ToString(); }
                    if (seg < 10) { seg1 = '0' + seg.ToString(); }

                    //Asi se va a mostrar las horas trabajadas en la vista
                    string horastrabajadas = hor1 + ":" + min1 + ":" + seg1;

                    ViewBag.TrabajoTotal = horastrabajadas;
                    ViewBag.Registro = registro;
                    return View("RegistroLiquidador");
                }
            }
        }
        public ActionResult ConsultarRegLiqFecha(string fechon = "1")
        {
            if (Session["LiquidadorLogueado"] == null)
            {

                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;

                RegistroHorasHorarios registroshoras1 = new RegistroHorasHorarios();
                RegistroHorasManager manager = new RegistroHorasManager();
                List<RegistroHorasHorarios> registro = manager.ConsultarLiquiFecha(fechon);
                int segtotales = 0;
                if (registro.Count == 0)
                {
                    TempData["Error5"] = "La fecha ingresada no es valida";
                    return RedirectToAction("HomeLiquidador");
                }
                else
                {
                    foreach (RegistroHorasHorarios registro1 in registro)
                    {
                        segtotales = segtotales + registro1.Conteo;
                    }

                    int seg = segtotales % 60;
                    int mininter = segtotales / 60;
                    int min = mininter % 60;
                    int hor = mininter / 60;
                    if (hor < 1)
                    {
                        hor = 0;
                    }
                    if (min < 1)
                    {
                        min = 0;
                    }

                    string hor1 = hor.ToString();
                    string min1 = min.ToString();
                    string seg1 = seg.ToString();
                    //Agrego un 0 al frente de los valores de solo un digito
                    if (hor < 10) { hor1 = '0' + hor.ToString(); }
                    if (min < 10) { min1 = '0' + min.ToString(); }
                    if (seg < 10) { seg1 = '0' + seg.ToString(); }

                    //Asi se va a mostrar las horas trabajadas en la vista
                    string horastrabajadas = hor1 + ":" + min1 + ":" + seg1;

                    ViewBag.TrabajoTotal = horastrabajadas;
                    ViewBag.Registro = registro;
                    return View("RegistroLiquidador");
                }
            }
        }


        public ActionResult ConsultarRegLiqMes(string mes = "1", int operador = 1)
        {
            if (Session["LiquidadorLogueado"] == null)
            {

                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");

            }
            else
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;

                RegistroHorasHorarios registroshoras1 = new RegistroHorasHorarios();
                RegistroHorasManager manager = new RegistroHorasManager();
                List<RegistroHorasHorarios> registro = manager.ConsultarLiquiMes(mes, operador);
                int segtotales = 0;
                if (registro.Count == 0)
                {
                    TempData["Error5"] = "El operador seleccionado no trabajo en el mes seleccionado";
                    return RedirectToAction("HomeLiquidador");
                }
                else
                {
                    foreach (RegistroHorasHorarios registro1 in registro)
                    {
                        segtotales = segtotales + registro1.Conteo;
                    }

                    int seg = segtotales % 60;
                    int mininter = segtotales / 60;
                    int min = mininter % 60;
                    int hor = mininter / 60;
                    if (hor < 1)
                    {
                        hor = 0;
                    }
                    if (min < 1)
                    {
                        min = 0;
                    }

                    string hor1 = hor.ToString();
                    string min1 = min.ToString();
                    string seg1 = seg.ToString();
                    //Agrego un 0 al frente de los valores de solo un digito
                    if (hor < 10) { hor1 = '0' + hor.ToString(); }
                    if (min < 10) { min1 = '0' + min.ToString(); }
                    if (seg < 10) { seg1 = '0' + seg.ToString(); }

                    //Asi se va a mostrar las horas trabajadas en la vista
                    string horastrabajadas = hor1 + ":" + min1 + ":" + seg1;

                    ViewBag.TrabajoTotal = horastrabajadas;
                    ViewBag.Registro = registro;
                    return View("RegistroLiquidador");
                }
            }
        }


        public ActionResult DatosOperador()
        {
            if (Session["LiquidadorLogueado"] != null)
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;

                return View();
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult ModificarDatos(string nombres="1", string apellidos = "1", int dni = 1, string fechanacimiento = "1", string estadocivil = "1", string direccion = "1", string mail = "1", string usuario = "1", string contraseña = "1", string imagen = "1")
        {
            if (Session["LiquidadorLogueado"] != null)
            {
            //Obtengo operadores para introducirlos en el layout
            LiquidadorManager manager2 = new LiquidadorManager();
            List<Operadores> operadores2 = manager2.Consultar();
            ViewBag.Operadores = operadores2;


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
            manager.Actualizar(operadores);

            return RedirectToAction("DatosOperador");
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult EliminarOperador (int dni = 1)
        {
            if (Session["LiquidadorLogueado"] != null)
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;


                OperadoresManager manager = new OperadoresManager();
                manager.Eliminar(dni);


                return RedirectToAction("DatosOperador");
             }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult MisDatos()
        {
            if (Session["LiquidadorLogueado"] != null)
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;

                return View();
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult ModificarLiquidador(string nombres = "1", string apellidos = "1", int dni = 1, string fechanacimiento = "1", string estadocivil = "1", string direccion = "1", string mail = "1", string usuario = "1", string contraseña = "1", string imagen = "1")
        {
            if (Session["LiquidadorLogueado"] != null)
            {
                //Obtengo operadores para introducirlos en el layout
                LiquidadorManager manager2 = new LiquidadorManager();
                List<Operadores> operadores2 = manager2.Consultar();
                ViewBag.Operadores = operadores2;

                //Envio a la vista el liquidador
                ViewBag.liquidador = Session["LiquidadorLogueado"];

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
                manager.Actualizar(liquidador);

                TempData["hecho"] = "Tus datos fueron modificados";
                return RedirectToAction("MisDatos");
            }
            else
            {
                TempData["Error4"] = "Necesitas loguearte para acceder a esa pagina";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}