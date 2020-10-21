using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  RegistroPedidosSuplidores.Entidades
{
    public class Ordenes
    {
        [Key]

        public int OrdenId {get; set;}

        public DateTime Fecha {get; set;} =DateTime.Now;

       // public int SuplidorId {get; set;}

        public Decimal Monto {get; set;}

    }
    
}
