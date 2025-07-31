using API_Productos.Modelos;

namespace API_Productos.Repositorio.IRepositorio
{
    public interface IProductorepositorio
    {
        ICollection<Producto> GetProductos();
        Producto GetProducto(int id);

        bool ExisteProducto(int id);
        bool ExisteProducto(string nombre);

        bool CrearProducto(Producto producto);

        bool ActualizarProducto(Producto producto);

        bool BorrarProducto(Producto producto);

        bool Guardar();
    }
}
