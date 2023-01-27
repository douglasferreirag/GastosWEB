using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gastos.Models;


namespace Gastos.Context
{
   public class GastosContext: DbContext
    {

            public GastosContext(DbContextOptions <GastosContext> options) : base(options) {



            }

         public DbSet<Fornecedor> Fornecedores{ get; set; }

          public DbSet<Pessoa> Pessoas{ get; set; }

          public DbSet<Catalogo> Catalogo{ get; set; }

    }
}