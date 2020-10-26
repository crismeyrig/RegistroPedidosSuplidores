using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RegistroPedidosSuplidores.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int OrdenDetalle { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int SuplidorId { get; set; }
       // public double Costo { get; set; }

        [ForeignKey("ProductoId")]
        public Productos productos { get; set; } = new Productos();
    }
}
