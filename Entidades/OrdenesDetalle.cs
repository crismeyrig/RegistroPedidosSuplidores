using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidosSuplidores.Entidades
{
    public class OrdenesDetalle
    {
        public int Id {get; set;}
        public int OrdenId {get; set;}
        public Decimal Cantidad {get; set;}
        public Decimal Costo {get; set;}
        //public int ProductoId {get; set;}

    }
}