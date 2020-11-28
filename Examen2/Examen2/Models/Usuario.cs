using System;
using System.Collections.Generic;

#nullable disable

namespace Examen2.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
    }
}
