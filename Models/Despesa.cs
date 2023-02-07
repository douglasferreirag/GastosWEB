using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gastos.Models
{
    public class Despesa
    {
        
            [Key]
            public string Codigo { get; set; }


             [Required]
            public string Descricao { get; set; }

            [Required]
            public double  Valor{ get; set; }

            [Required]
            public double Desconto {get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public  DateTime Data { get; set; }    

            [ForeignKey("Pessoa"), Column(Order = 1)]
            [Required]
            public string CodigoPessoa{ get; set; }
            public virtual Pessoa pessoa{ get; set; }


    }
}