using back_end.Entidades;

namespace back_end.Repositorios
{
    public interface IRepositorio
    {
        void CrearGenero(Genero genero);
        Guid ObtenerGUID();
        Genero? ObtenerPorId(int id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
