using API_Productos.Modelos;
using API_Productos.Modelos.Dtos;
using AutoMapper;

namespace API_Productos.ProductoMappers
{
    public class ProductosMappers: Profile
    {
        public ProductosMappers()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, CrearProductoDto>().ReverseMap();
        }
    }
}
