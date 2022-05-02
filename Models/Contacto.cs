using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace appejemplo2.Models
{
   [Table("t_contacto")]

    public class Contacto
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Column("id")]
       public int id { get; set; }


       [Column("Email")]
        public string Email {get;set;}
        [Column("Name")]
        public string Nombre {get;set;}
        [Column("subjet")]
        public string subjet {get;set;}
        [Column("comment")]
        public string comment {get;set;}

    }
}