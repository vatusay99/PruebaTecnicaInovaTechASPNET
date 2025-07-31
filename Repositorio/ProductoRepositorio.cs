using API_Productos.Data;
using API_Productos.Modelos;
using API_Productos.Repositorio.IRepositorio;
using System.Drawing;

namespace API_Productos.Repositorio
{
    public class ProductoRepositorio: IProductorepositorio
    {
        private readonly AplicationDbContext _db;

        public ProductoRepositorio(AplicationDbContext db)
        {
            _db = db;
        }
        public bool ActualizarProducto(Producto producto)
        {
           _db.Productos.Update(producto);
            return Guardar();
        }

        public bool BorrarProducto(Producto producto)
        {
            _db.Productos.Remove(producto);
            return Guardar();
        }

        public bool CrearProducto(Producto producto)
        {
            _db.Productos.Add(producto);
            return Guardar();
        }

        public bool ExisteProducto(int id)
        {
            return _db.Productos.Any(x => x.Id == id);
        }

        public bool ExisteProducto(string nombre)
        {
            bool valor = _db.Productos.Any( p =>  p.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public Producto GetProducto(int id)
        {
            /*
            if(int.TryParse(id, out int numero))
            {
                return _db.Productos.FirstOrDefault(p => p.Id == id);
            }
            var product = _db.Productos.FirstOrDefault(p => p.Id == id);
            if (product.Id == null) return product;
            return product;*/
            return _db.Productos.First(p => p.Id == id);
        }

        public ICollection<Producto> GetProductos()
        {
            return _db.Productos.OrderBy(p => p.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
