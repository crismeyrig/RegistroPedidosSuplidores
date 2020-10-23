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

    public class SuplidoresBLL{

        public static List<Suplidores> GetSuplidores()
        {
            List<Suplidores> suplidores = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                suplidores = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return suplidores;
        }




    }
 
}