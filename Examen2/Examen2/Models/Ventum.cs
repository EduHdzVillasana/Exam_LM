using System;
using System.Collections.Generic;

#nullable disable

namespace Examen2.Models
{
    public partial class Ventum
    {
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int IdEmpleado { get; set; }
        public string Clave { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
