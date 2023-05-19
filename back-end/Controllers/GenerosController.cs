using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio, ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Vamos a mostrar los generos, msj LOG----------------------------------------------");
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")]
        public ActionResult<Guid> GetGUID()
        {
            return repositorio.ObtenerGUID();
        }

        [HttpGet("{id:int=1}")]
        public ActionResult<Genero> Get(int id)
        {
            logger.LogDebug($"Obteniendo un genero por el ID, {id}, msj LOG");
            var genero = repositorio.ObtenerPorId(id);
            if (genero == null)
            {
                logger.LogWarning($"No pudimos encontrar, un genero por el ID, {id}, msj LOG+++++++++++++");
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public void Put() { }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
