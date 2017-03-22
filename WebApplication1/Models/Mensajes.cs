using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication16.Models;

namespace WebApplication1.Models
{
    public class Mensajes
    {
        public long ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public Operadores Autor { get; set; }
        public Operadores Receptor { get; set; }
    }
}