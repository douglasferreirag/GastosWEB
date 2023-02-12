using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gastos.Models
{
    public class Item
    {
        
          
     
            [Key]
            public string Codigo{ get; set; }

            [ForeignKey("CodigoDespesa"), Column(Order = 0)]
            [Required]
            public string CodigoDespesa{ get; set; }
            public virtual Despesa despesa{ get; set; } 

           
            [ForeignKey("CodigoCatalogo"), Column(Order = 1)]
            [Required]
            public string CodigoCatalogo{ get; set; }
            public virtual Catalogo catalogo{ get; set; } 


            [Required]
            public double  Quantidade{ get; set; }

            [Required]
            public double  Total{ get; set; }

    }
}