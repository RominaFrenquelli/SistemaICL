using ICL.Data;
using ICL.Models;

namespace ICL.Repository
{
    public class ClienteRepository
    {
        private readonly ICLContext _context;

        public ClienteRepository(ICLContext context)
        {
            _context = context;
        }

        public int CrearCliente(Cliente elCLiente)
        {
            _context.Cliente.Add(elCLiente);

            _context.SaveChanges();

            return elCLiente.Id;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _context.Cliente.ToList();
        }

        public List<Cliente> BuscarClientes(string nombreDelCliente)
        {
           var cliente = _context.Cliente.Where(x=>x.RazonSocial.Contains(nombreDelCliente)).ToList();

            return cliente;
        }
    }
}
