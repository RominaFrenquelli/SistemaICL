using ICL.Data;
using ICL.Models;
using ICL.Repository;

namespace ICL.Business
{
    public class ServicioBusiness
    {
        private readonly ServicioRepository _repository;

        public ServicioBusiness(ICLContext context)
        {
            _repository = new ServicioRepository(context);
        }

        public int CrearServicio(Servicio nuevo)
        {
            return _repository.CrearServicio(nuevo);
        }

        public List<Servicio> ListarServicio()
        {
            return _repository.ListarServicio();
        }
    }
}
