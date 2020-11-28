using System;
using System.Collections.Generic;

#nullable disable

namespace Examen2.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
