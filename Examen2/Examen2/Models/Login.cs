using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
        public int modo { get; set; }
        public int operacion { get; set; }
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public int Cantidad { get; set; }
    }
}
