using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gastos.Models
{
    public class Pessoa
    {
        

            [Key]
             public string Codigo { get; set; }

            [Required]
            public string Nome { get; set; }

            [Required]
            public string  Sobrenome { get; set; }


    }
}