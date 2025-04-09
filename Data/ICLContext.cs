using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICL.Models;

namespace ICL.Data
{
    public class ICLContext : DbContext
    {
        public ICLContext (DbContextOptions<ICLContext> options)
            : base(options)
        {
        }

        public DbSet<ICL.Models.Administrador> Administrador { get; set; } = default!;
        public DbSet<ICL.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<ICL.Models.DetalleDeListaDePrecios> DetalleDeListaDePrecios { get; set; } = default!;
        public DbSet<ICL.Models.ListaDePrecios> ListaDePrecios { get; set; } = default!;
        public DbSet<ICL.Models.Solicitud> Solicitud { get; set; } = default!;
        
        public DbSet<ICL.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<ICL.Models.Redactor> Redactor { get; set; } = default!;
        public DbSet<ICL.Models.Servicio> Servicio { get; set; } = default!;
        public DbSet<ICL.Models.PedidoPostulante> PedidoPostulante { get; set; } = default!;

    }
}
