using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorio
{
    public interface IArticuloRepositorio
    {
        Task<IEnumerable<Articulo>> ObtenerTodos();
        Task<Articulo> ObtenerPorId(int id);
        Task Crear(Articulo articulo);
        Task Actualizar(Articulo articulo);
        Task Eliminar(int id);
    }
}
