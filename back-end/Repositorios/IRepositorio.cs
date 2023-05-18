using back_end.Entidades;

namespace back_end.Repositorios
{
    public interface IRepositorio
    {
        Genero? ObtenerPorId(int id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
