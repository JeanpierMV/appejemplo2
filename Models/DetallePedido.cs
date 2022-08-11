using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace appejemplo2.Models
{
     [Table("t_order_detail")]
    public class DetallePedido
    {    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int ID {get; set;}
        [Column("Producto")]
        public Producto Producto {get; set;}
        [Column("Cantidad")]
        public int Cantidad{get; set;}
        [Column("Precio")]
        public Decimal Precio { get; set; }
        [Column("pedido")]
        public Pedido pedido {get; set;}

        
    }
}