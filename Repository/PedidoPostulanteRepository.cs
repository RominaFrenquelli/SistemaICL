using ICL.Data;
using ICL.Models;

namespace ICL.Repository
{
    public class PedidoPostulanteRepository
    {
        private readonly ICLContext _context;

        public PedidoPostulanteRepository(ICLContext context)
        {
            _context = context;
        }

        
        public int CrearPedidoPostulante(PedidoPostulante postulante)
        {
            _context.PedidoPostulante.Add(postulante);

            _context.SaveChanges();

            return postulante.Id;
        }

        public PedidoPostulante ObtenerPedidoPostulante(int id)
        {
            var postulante = _context.PedidoPostulante.Where(p => p.Id == id).FirstOrDefault();
            
            return postulante;
        }

        public PedidoPostulante ExistePostulante(string dni)
        {
            PedidoPostulante? postulanteExistente = _context.PedidoPostulante.FirstOrDefault(p => p.DNI == dni);

            return postulanteExistente;
        }
    }
}
