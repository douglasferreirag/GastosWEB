using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    public class CatalogoController: Controller
    {


            private readonly GastosContext _context;

            public CatalogoController(GastosContext context){

                        _context = context;


            }

          

            public IActionResult Index(){

                       var catalogos = _context.Catalogos.ToList();

                        return View(catalogos);
                      
            }

             public IActionResult Criar(){
 

                           string codigo =  Guid.NewGuid().ToString();   

                           ViewBag.codigo = codigo; 

                            var fornecedores = _context.Fornecedores.ToList();

                            ViewBag.fornecedores = fornecedores;

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Catalogo catalogo){

                    if(ModelState.IsValid){

                        _context.Catalogos.Add(catalogo);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(catalogo);

            }

            public IActionResult Editar (string Codigo){


                    var catalogo = _context.Catalogos.Find(Codigo);

                    ViewBag.CodigoFornecedor = catalogo.CodigoFornecedor;

                   var fornecedores = _context.Fornecedores.ToList();

                    ViewBag.fornecedores = fornecedores;

                    if(catalogo == null)

                        return RedirectToAction(nameof (Index));

                    return View(catalogo);  

              
             }

            

            [HttpPost]
              public IActionResult Editar(Catalogo catalogo) 
             {
                
                    var catalogoBanco = _context.Catalogos.Find(catalogo.Codigo);

                    catalogoBanco.Codigo = catalogo.Codigo;

                    catalogoBanco.Descricao = catalogo.Descricao;

                    catalogoBanco.ValorUnitario= catalogoBanco.ValorUnitario;

                    catalogoBanco.CodigoFornecedor = catalogo.CodigoFornecedor;

                    catalogoBanco.Data = catalogo.Data;

                    _context.Catalogos.Update(catalogoBanco);

                    _context.SaveChanges();

                    return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string Codigo){

                       var catalogo = _context.Catalogos.Find(Codigo);

                       if (catalogo == null)

                            return RedirectToAction(nameof (Index));

                        return View(catalogo);

            }

            public IActionResult Deletar(string Codigo){


                    var catalogo= _context.Catalogos.Find (Codigo);

                     //  

                    if (catalogo== null)

                            return RedirectToAction(nameof (Index));

                    return View(catalogo);

            }

          

             
             
                [HttpPost]
                public IActionResult Deletar( Catalogo catalogo){

                      

                        var catalogoBanco = _context.Catalogos.Find(catalogo.Codigo);

                        _context.Catalogos.Remove(catalogoBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

                }

             

           



        
    }
}