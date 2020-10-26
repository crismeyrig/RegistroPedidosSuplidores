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
    public class VentasBLL
    {
        /* public static bool Guardar(Ventas ventas
        {
            bool paso;

            if (!Existe(ventas.VentaId))
                paso = Insertar(ventas);
            else
                paso = Modificar(ventas);

            return paso;
        }
        
         public static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
               
                foreach (var item in Ventas.Detalle)
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
            }*/
        }
    }
