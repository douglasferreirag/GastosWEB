using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    public class PessoaController: Controller
    {


            private readonly GastosContext _context;

            public PessoaController(GastosContext context){

                        _context = context;


            }

          

            public IActionResult Index(){

                       var pessoa = _context.Pessoas.ToList();

                        return View(pessoa);
                      
            }

             public IActionResult Criar(){

                           string codigo =  Guid.NewGuid().ToString();   

                           ViewBag.codigo = codigo; 

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Pessoa pessoa){

                    if(ModelState.IsValid){

                        _context.Pessoas.Add(pessoa);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(pessoa);

            }

            public IActionResult Editar (string Codigo){


                    var pessoa= _context.Pessoas.Find(Codigo);

                  

                    if(pessoa== null)

                        return RedirectToAction(nameof (Index));

                    return View(pessoa);  

                    

                  

                  


             }

            

            [HttpPost]
              public IActionResult Editar(Pessoa pessoa) 
             {
                
                      var pessoaBanco = _context.Pessoas.Find(pessoa.Codigo);

                       pessoaBanco.Codigo = pessoa.Codigo;

                        pessoaBanco.Nome = pessoa.Nome;

                       pessoaBanco.Sobrenome= pessoa.Sobrenome;


                        _context.Pessoas.Update(pessoaBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string Codigo){

                       var pessoa= _context.Pessoas.Find(Codigo);

                       if (pessoa == null)

                            return RedirectToAction(nameof (Index));

                        return View(pessoa);

            }

            public IActionResult Deletar(string Codigo){


                       var pessoa= _context.Pessoas.Find (Codigo);

                     //  

                       if (pessoa == null)

                            return RedirectToAction(nameof (Index));

                        return View(pessoa);

            }

          

             
             
                [HttpPost]
                public IActionResult Deletar( Pessoa pessoa){

                      

                        var pessoaBanco = _context.Pessoas.Find(pessoa.Codigo);

                        _context.Pessoas.Remove(pessoaBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

                }

             

           



        
    }
}