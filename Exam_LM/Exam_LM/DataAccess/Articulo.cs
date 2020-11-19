using System;
using System.Collections.Generic;

#nullable disable

namespace Exam_LM.DataAccess
{
    public partial class Articulo
    {
        public Articulo()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
