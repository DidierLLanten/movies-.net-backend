using back_end.Entidades;

namespace back_end.Repositorios
{
    public class RepositorioEnMemoria : IRepositorio
    {
        private List<Genero> _generos;
        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero() {Id = 1, Nombre = "Comedia"},
                new Genero() {Id = 2, Nombre = "Accion"},
            };

            _guid = Guid.NewGuid();
        }

        public Guid _guid;

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public Genero? ObtenerPorId(int id)
        {
            // return new Genero() { Id = id };
            return _generos.FirstOrDefault(gender => gender.Id == id);
        }

        public void CrearGenero(Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);
        }

        public Guid ObtenerGUID()
        {
            return _guid;
        }
    }
}
