using ICL.Data;
using ICL.Interfaces;
using ICL.Models;
using ICL.Repository;

namespace ICL.Business
{
    public class ServicioBusiness
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioBusiness(IServicioRepository servicioRepo)
        {
            _servicioRepository = servicioRepo;
        }

        public async Task<int> CrearServicio(Servicio nuevo)
        {
            return await _servicioRepository.CrearServicio(nuevo);
        }

        public async Task<List<Servicio>> ListarServicio()
        {
            return await _servicioRepository.ListarServicio();
        }

        public async Task<List<Servicio>> ObtenerPorIds(List<int> ids)
        {
            return await _servicioRepository.ObtenerPorIds(ids);
        }
    }
}
