using Microsoft.EntityFrameworkCore;
using RegistroPedidosSuplidores;
using RegistroPedidosSuplidores.Entidades;
using System;

namespace RegistroPedidosSuplidores.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Ventas> Ventas {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Pedidos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 1, Descripcion = "Carton de Leche", Costo = 65, Inventario = 200 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 2, Descripcion = "Arroz,5 Lb", Costo = 500, Inventario = 253 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 3, Descripcion = "Carton de Huevo", Costo = 210, Inventario = 50 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 4, Descripcion = "Manzanas,unidad", Costo = 45, Inventario = 253 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 5, Descripcion = "Fresas Congeladas,1 Lb", Costo = 120, Inventario = 100 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 6, Descripcion = "Harina de trigo,1 lb", Costo = 25, Inventario = 200 });
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 7, Descripcion = "Bolones,1 funda", Costo = 300, Inventario = 253 });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 1, Nombres = "Nestle" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 2, Nombres = "El soberano" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 3, Nombres = "Huevos Endy" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 4, Nombres = "El frutal" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 5, Nombres = "Constanza" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 6, Nombres = "La Blanquita" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            { SuplidorId = 7, Nombres = "Yogeta" });
        }
    }
}
