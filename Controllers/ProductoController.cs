using API_Productos.Modelos;
using API_Productos.Modelos.Dtos;
using API_Productos.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductorepositorio _ptRepo;

        private readonly IMapper _mapper;

        public ProductoController(IProductorepositorio ptRepo, IMapper mapper)
        {
            _ptRepo = ptRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProductos()
        {

            var ListaProductos = _ptRepo.GetProductos();
            var ListaProductosDto = new List<ProductoDto>();

            foreach (var lista in ListaProductos)
            {
                ListaProductosDto.Add(_mapper.Map<ProductoDto>(lista));
            }

            return Ok(ListaProductosDto);

        }
        
        [HttpGet("{id:int}", Name = "GetProducto")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProducto(int id)
        {

            var itemProducto = _ptRepo.GetProducto(id);
            if (itemProducto == null)
            {
                return NotFound();
            }
            var itemProductoDto = _mapper.Map<ProductoDto>(itemProducto);

            return Ok(itemProductoDto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CrearProducto([FromBody] CrearProductoDto crearProductoDto)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if(crearProductoDto == null) { return BadRequest(ModelState); }
            if (_ptRepo.ExisteProducto(crearProductoDto.Nombre)) {
                ModelState.AddModelError("", $"El Producto ya existe"); 
                return StatusCode(404, ModelState);
            }

            var producto = _mapper.Map<Producto>(crearProductoDto);

            if (!_ptRepo.CrearProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {producto.Nombre}.");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetProducto", new {producto.Id}, producto);

        }

        [HttpPut("{id:int}", Name = "ActualizarPutProducto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ActualizarPutProducto(int id, [FromBody] ProductoDto productoDto)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (productoDto == null || id != productoDto.Id) { return BadRequest(ModelState); }

            var producto = _mapper.Map<Producto>(productoDto);

            if (!_ptRepo.ActualizarProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal Actualizando el registro {producto.Nombre}.");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarProducto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult BorrarProducto(int id)
        {

            if (!_ptRepo.ExisteProducto(id))
            {
                return NotFound();
            }

            var product = _ptRepo.GetProducto(id);

            if (!_ptRepo.BorrarProducto(product))
            {
                ModelState.AddModelError("", $"Algo salio mal eliminando el producto: {product.Nombre}.");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }



    }
}
