﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICL.Models;
using System.Linq.Expressions;

namespace ICL.Data
{
    public class ICLContext : DbContext
    {
        public ICLContext (DbContextOptions<ICLContext> options)
            : base(options)
        {
        }

        public DbSet<ICL.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<ICL.Models.DetalleDeListaDePrecios> DetalleDeListaDePrecios { get; set; } = default!;
        public DbSet<ICL.Models.ListaDePrecios> ListaDePrecios { get; set; } = default!;
        public DbSet<ICL.Models.Solicitud> Solicitud { get; set; } = default!;
        public DbSet<ICL.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<ICL.Models.Redactor> Redactor { get; set; } = default!;
        public DbSet<ICL.Models.Servicio> Servicio { get; set; } = default!;
        public DbSet<ICL.Models.PedidoPostulante> PedidoPostulante { get; set; } = default!;
        public DbSet<ICL.Models.PedidoPostulante> Usuario { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        if (typeof(MiClaseBase).IsAssignableFrom(entityType.ClrType))
        //        {
        //            // Filtro global para ignorar deshabilitados
        //            var parameter = Expression.Parameter(entityType.ClrType, "e");
        //            var property = Expression.Property(parameter, "Enable");
        //            var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(true)), parameter);

        //            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        //        }
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
