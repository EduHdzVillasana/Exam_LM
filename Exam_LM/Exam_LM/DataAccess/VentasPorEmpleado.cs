using System;
using System.Collections.Generic;

#nullable disable

namespace Exam_LM.DataAccess
{
    public partial class VentasPorEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Rfc { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public double? IngresosTotales { get; set; }
        public int? VentasTotales { get; set; }
    }
}
