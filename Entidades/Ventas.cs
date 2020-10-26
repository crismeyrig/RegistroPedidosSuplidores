using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidosSuplidores.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId {get; set;}
        public DateTime fecha {get; set;} = DateTime.Now;
        public decimal Monto {get; set;}

        [ForeignKey("ventaId")]
        public virtual List <OrdenesDetalle> Detalle {get; set;} =new List<OrdenesDetalle>();

    }
}