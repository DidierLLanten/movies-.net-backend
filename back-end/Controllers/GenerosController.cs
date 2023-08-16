using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;

        public GenerosController(IRepositorio repositorio, ILogger<GenerosController> logger,
            ApplicationDbContext context)
        {
            this.repositorio = repositorio;
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            logger.LogInformation("Vamos a mostrar los generos, msj LOG----------------------------------------------");
            // return repositorio.ObtenerTodosLosGeneros();
            return await context.Generos.ToListAsync();
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
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            //repositorio.CrearGenero(genero);
            context.Add(genero);
            await context.SaveChangesAsync();
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
