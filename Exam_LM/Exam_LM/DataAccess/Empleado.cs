using System;
using System.Collections.Generic;

#nullable disable

namespace Exam_LM.DataAccess
{
    public partial class Empleado
    {
        public Empleado()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdEmpleado { get; set; }
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rfc { get; set; }

        public virtual Puesto IdPuestoNavigation { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
