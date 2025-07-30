using System.Diagnostics.CodeAnalysis;

namespace ProductosApiRest.Models
{
    public class Producto
    {
        public long Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [NotNull]
        public decimal precio { get; set; }


    }
}
