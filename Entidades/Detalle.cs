using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidosSuplidores.Entidades
{
    public class Detalle
    {
        [Key]
        public int Id {get; set;}
        public int ventaId {get; set;}
        public string Servicio {get; set;}
        public double precio {get; set;}

        [ForeignKey("ventaId")]
        public Ventas ventas {get; set;}= new Ventas ();

    }
}