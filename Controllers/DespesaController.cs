using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    public class DespesaController: Controller
    {


            private readonly GastosContext _context;

            public DespesaController(GastosContext context){

                        _context = context;


            }

          

            public IActionResult Index(){

                       var Despesa= _context.Despesas.ToList();

                        return View(Despesa);
                      
            }

             public IActionResult Criar(){
 

                           string codigo =  Guid.NewGuid().ToString();   

                           ViewBag.codigo = codigo; 

                            var pessoas = _context.Pessoas.ToList();

                            ViewBag.pessoas = pessoas;

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Despesa despesa){

                    if(ModelState.IsValid){

                        _context.Despesas.Add(despesa);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(despesa);

            }

            public IActionResult Editar (string Codigo){


                    var despesa = _context.Despesas.Find(Codigo);

                    ViewBag.CodigoPessoa = despesa.CodigoPessoa;

                   var pessoas = _context.Pessoas.ToList();

                    ViewBag.pessoas =pessoas;

                    if(despesa == null)

                        return RedirectToAction(nameof (Index));

                    return View(despesa);  

              
             }

            

            [HttpPost]
              public IActionResult Editar(Despesa despesa) 
             {
                
                    var despesaBanco = _context.Despesas.Find(despesa.Codigo);

                    despesaBanco.Codigo = despesa.Codigo;

                    despesaBanco.Descricao = despesa.Descricao;

                    despesaBanco.Valor = despesa.Valor;

                    despesaBanco.Desconto = despesa.Desconto;

                    despesaBanco.CodigoPessoa = despesa.CodigoPessoa;

                    despesaBanco.Data = despesa.Data;

                    _context.Despesas.Update(despesaBanco);

                    _context.SaveChanges();

                    return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string Codigo){

                       var despesa = _context.Despesas.Find(Codigo);

                       if (despesa == null)

                            return RedirectToAction(nameof (Index));

                        return View(despesa);

            }

            public IActionResult Deletar(string Codigo){


                    var despesa= _context.Despesas.Find (Codigo);

                     //  

                    if (despesa== null)

                            return RedirectToAction(nameof (Index));

                    return View(despesa);

            }

          

             
             
                [HttpPost]
                public IActionResult Deletar( Despesa despesa){

                      

                        var despesaBanco = _context.Despesas.Find(despesa.Codigo);

                        _context.Despesas.Remove(despesaBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

                }

             

           



        
    }
}