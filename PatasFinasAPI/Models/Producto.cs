using System;
using System.Collections.Generic;

namespace PatasFinasAPI.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
    }
}
