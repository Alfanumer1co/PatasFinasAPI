using System;
using System.Collections.Generic;

namespace PatasFinasAPI.Models
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Dni { get; set; }
        public string? Telefono { get; set; }
        public bool? Estado { get; set; }
    }
}
