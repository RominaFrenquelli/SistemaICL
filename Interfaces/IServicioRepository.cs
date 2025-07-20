using ICL.Models;

namespace ICL.Interfaces
{
    public interface IServicioRepository
    {
        Task<int> CrearServicio(Servicio nuevo);
        Task<List<Servicio>> ListarServicio();
        Task<List<Servicio>> ObtenerPorIds(List<int> ids); 
    }
}
