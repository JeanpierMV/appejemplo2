using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appejemplo2.Models
{
       [Table("t_reserva")]
    public class Reserva
    {      
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Column("id")]

       public int id { get; set; }
      
         [Column("Correo")]
        public String Correo { get; set; }
         [Column("Telefono")]
        public String Telefono { get; set; }
          [Column("Fecha")]
        public String Fecha{ get; set;}
          [Column("Horario")]
        public String Horario{ get; set;}
         [Column("Cantidad")]
        public int Cantidad { get; set; }

    
}
}