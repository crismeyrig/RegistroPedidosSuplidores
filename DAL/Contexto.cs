using Microsoft.EntityFrameworkCore;
using RegistroPedidosSuplidores;
using RegistroPedidosSuplidores.Entidades;
using System;

namespace RegistroPedidosSuplidores.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }

        public DbSet<OrdenesDetalle> OrdenesDetalles { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Pedidos.db");
        }
    }
}