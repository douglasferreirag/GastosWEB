using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gastos.Models
{
    public class Fornecedor
    {

            [Key]

             public string Codigo { get; set; }

            [Required]
            public string Descricao { get; set; }

            [Required]
            public string Local { get; set; }

    }
}