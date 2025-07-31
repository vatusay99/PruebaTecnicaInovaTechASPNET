using System.ComponentModel.DataAnnotations;

namespace API_Productos.Modelos.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo nombre solo tiene un maximo de 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal Precio { get; set; }

        public string? Descripcion { get; set; }
    }
}
