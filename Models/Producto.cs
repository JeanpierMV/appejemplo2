using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//agregado
using System.ComponentModel.DataAnnotations.Schema;

namespace appejemplo2.Models
{
    [Table("t_producto")]
    public class Producto
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
        public int Id {get;set;}
    [Column("Name")]
        public string Name { get; set; }
    [Column("Precio")]
        public Decimal Precio { get; set; }
    [Column("Descripcion")]
        public string Descripcion { get; set; }
    [Column("PDescuento")]
         public Decimal PDescuento { get; set; }
    [Column("ImagenName")]
         public string ImagenName { get; set; }
    [Column("Status")]
         public string Status { get; set; }

    }
}