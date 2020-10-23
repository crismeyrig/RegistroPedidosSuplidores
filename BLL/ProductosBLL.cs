using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using RegistroPedidosSuplidores.Entidades;
using RegistroPedidosSuplidores.DAL;

namespace RegistroPedidosSuplidores.BLL
{
    class ProductosBLL
    {
        public static List<Productos> GetProductos()
        {
            List<Productos> productos = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;







        }
    }
}