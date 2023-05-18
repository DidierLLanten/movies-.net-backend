using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public List<Genero> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{id:int=1}")]
        public Genero Get(int id) {
            var genero = repositorio.ObtenerPorId(id);
            if(genero == null)
            {
                //return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public void Post() { 

        }

        [HttpPut]
        public void Put() { }

        [HttpDelete]
        public void Delete() 
        {

        }    
    }
}
