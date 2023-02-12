using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gastos.Models
{
    public class Catalogo
    {

            [Key]
            public string Codigo { get; set; }

            [Required]
            public string Descricao { get; set; }

            [Required]
            public double  ValorUnitario{ get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public  DateTime Data { get; set; }


             [ForeignKey("Fornecedor"), Column(Order = 1)]
            [Required]
            public string CodigoFornecedor{ get; set; }
            public virtual Fornecedor fornecedor{ get; set; }    
        
    }
}