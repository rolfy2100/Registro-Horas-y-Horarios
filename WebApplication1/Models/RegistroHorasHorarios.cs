using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication16.Models
{
    public class RegistroHorasHorarios
    {
        public Operadores Operador { get; set; }
        public string FechaEntrada { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string HorasTrabajadas { get; set; }
        public int Conteo { get; set; }
    }
}