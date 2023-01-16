using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    public class FornecedorController : Controller
    {


            private readonly GastosContext _context;

            public FornecedorController(GastosContext context){

                        _context = context;


            }

          

            public IActionResult Index(){

                       var fornecedores = _context.Fornecedores.ToList();

                        return View(fornecedores);
                      
            }

             public IActionResult Criar(){

                           string codigo =  Guid.NewGuid().ToString();   

                           ViewBag.codigo = codigo; 

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Fornecedor fornecedor){

                    if(ModelState.IsValid){

                        _context.Fornecedores.Add(fornecedor);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(fornecedor);

            }

            public IActionResult Editar (string Codigo){


                    var fornecedor = _context.Fornecedores.Find(Codigo);

                  

                    if(fornecedor == null)

                        return RedirectToAction(nameof (Index));

                    return View(fornecedor);  

                    

                    //Console.WriteLine(Codigo); // Vindo 0

                  


             }

            

            [HttpPost]
              public IActionResult Editar(Fornecedor fornecedor) 
             {
                
                      var fornecedorBanco = _context.Fornecedores.Find(fornecedor.Codigo);

                       fornecedorBanco.Codigo = fornecedor.Codigo;

                        fornecedorBanco.Descricao = fornecedor.Descricao;

                       fornecedorBanco.Local= fornecedor.Local;


                        _context.Fornecedores.Update(fornecedorBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string Codigo){

                       var fornecedor = _context.Fornecedores.Find(Codigo);

                       if (fornecedor == null)

                            return RedirectToAction(nameof (Index));

                        return View(fornecedor);

            }

            public IActionResult Deletar(string Codigo){


                       var fornecedor= _context.Fornecedores.Find (Codigo);

                     //  Console.WriteLine("Código do fornecedor:" + fornecedor.Codigo);

                       if (fornecedor == null)

                            return RedirectToAction(nameof (Index));

                        return View(fornecedor);

            }

          

             
             
                [HttpPost]
                public IActionResult Deletar( Fornecedor fornecedor){

                      

                        var fornecedorBanco = _context.Fornecedores.Find(fornecedor.Codigo);

                        _context.Fornecedores.Remove(fornecedorBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

                }

             

           



        
    }
}