using back_end.Entidades;

namespace back_end.Repositorios
{
    public class RepositorioEnMemoria: IRepositorio
    {
        private List<Genero> _generos;
        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero() {Id = 1, Nombre = "Comedia"},
                new Genero() {Id = 2, Nombre = "Accion"},
            };            
        }

        public List<Genero> ObtenerTodosLosGeneros() { 
            return _generos;
        }

        public Genero? ObtenerPorId(int id) {
            // return new Genero() { Id = id };
            return _generos.FirstOrDefault(gender => gender.Id == id);
        }
    }
}
