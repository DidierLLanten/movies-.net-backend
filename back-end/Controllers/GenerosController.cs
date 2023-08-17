using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Repositorios;
using back_end.Utilidades;
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
        private readonly IMapper mapper;

        public GenerosController(IRepositorio repositorio, ILogger<GenerosController> logger,
            ApplicationDbContext context, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/generos
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            logger.LogInformation("Vamos a mostrar los generos, msj LOG----------------------------------------------");
            // return repositorio.ObtenerTodosLosGeneros();
            var queryable = context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
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
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            //repositorio.CrearGenero(genero);
            var genero = mapper.Map<Genero>(generoCreacionDTO);
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
