using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroPedidosSuplidores.DAL;
using RegistroPedidosSuplidores.Entidades;

namespace RegistroPedidosSuplidores.BLL
{
    public class OrdenesBLL
    {
       
        public static bool Guardar(Ordenes ordenes)
        {
            bool paso;

            if (!Existe(ordenes.OrdenId))
                paso = Insertar(ordenes);
            else
                paso = Modificar(ordenes);

            return paso;
        }
    
        public static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
               
                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item.productos).State = EntityState.Modified;
                }
               
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
               public static bool Modificar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM OrdenesDetalle WHERE OrdenId={ordenes.OrdenId}");

                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
              public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ordenes = OrdenesBLL.Buscar(id);
                if (ordenes != null)
                {
                    contexto.Ordenes.Remove(ordenes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
                public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
      
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.OrdenId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        
        public static Ordenes Buscar(int id)
        {
            Ordenes ordenes = new Ordenes();
            Contexto contexto = new Contexto();

            try
            {
                ordenes = contexto.Ordenes
                    .Where(d => d.OrdenId == id)
                    .Include(d => d.Detalle)
                    .ThenInclude(p => p.productos)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }
    }
}