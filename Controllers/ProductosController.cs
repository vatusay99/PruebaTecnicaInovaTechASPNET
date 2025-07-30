using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace ProductosApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public readonly string con;
        public ProductosController(IConfiguration configuration) 
        {
            con = configuration.GetConnectionString("conexion");
        }
    }
}
