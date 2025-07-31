using System.ComponentModel.DataAnnotations;

namespace API_Productos.Modelos
{
    public class Producto
    {

        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }

        public string? Descripcion {  get; set; }
    }
}
