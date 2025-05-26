using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorio
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private static List<Articulo> _lista = new();

        public async Task<IEnumerable<Articulo>> ObtenerTodos() =>
            await Task.FromResult(_lista);

        public async Task<Articulo> ObtenerPorId(int id) =>
            await Task.FromResult(_lista.FirstOrDefault(x => x.Id == id));

        public async Task Crear(Articulo articulo)
        {
            _lista.Add(articulo);
            await Task.CompletedTask;
        }

        public async Task Actualizar(Articulo articulo)
        {
            var existente = _lista.FirstOrDefault(x => x.Id == articulo.Id);
            if (existente != null)
            {
                existente.Nombre = articulo.Nombre;
                existente.Precio = articulo.Precio;
            }
            await Task.CompletedTask;
        }

        public async Task Eliminar(int id)
        {
            var existente = _lista.FirstOrDefault(x => x.Id == id);
            if (existente != null) _lista.Remove(existente);
            await Task.CompletedTask;
        }
    }
}
