using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Gastos.Context;
using Gastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    public class ItemController: Controller
    {


            private readonly GastosContext _context;

            public ItemController(GastosContext context){

                        _context = context;


            }

          

            public IActionResult Index(){

                       var itens = _context.Itens.ToList();

                        return View(itens);
                      
            }

             public IActionResult Criar(){
 

                           string codigo =  Guid.NewGuid().ToString();   

                           ViewBag.codigo = codigo; 

                            var despesas = _context.Despesas.ToList();

                            ViewBag.Despesas = despesas;

                            var catalogos = _context.Catalogos.ToList();

                            ViewBag.Catalogos = catalogos;

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Item item){

                    if(ModelState.IsValid){

                        _context.Itens.Add(item);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(item);

            }

            public IActionResult Editar (string Codigo){


                var item = _context.Itens.Find(Codigo);

                // Despesas

                ViewBag.CodigoDespesa = item.CodigoDespesa;

                var despesas= _context.Despesas.ToList();

                ViewBag.despesas = despesas;


                 // Catálogos

                ViewBag.CodigoCatalogo = item.CodigoCatalogo;

                var catalogos= _context.Catalogos.ToList();

                ViewBag.catalogos = catalogos;

                if(item == null)

                        return RedirectToAction(nameof (Index));

                    return View(item);  

              
             }

            

            [HttpPost]
              public IActionResult Editar(Item item) 
             {
                
                    var ItemBanco= _context.Itens.Find(item.Codigo);

                    ItemBanco.Codigo = item.Codigo;

                    ItemBanco.CodigoDespesa = item.CodigoDespesa;

                    ItemBanco.CodigoCatalogo = item.CodigoCatalogo;

                    ItemBanco.Quantidade= item.Quantidade;

                    ItemBanco.Total = item.Total;

                    _context.Itens.Update(ItemBanco);

                    _context.SaveChanges();

                    return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string Codigo){

                       var item = _context.Itens.Find(Codigo);

                       if (item == null)

                            return RedirectToAction(nameof (Index));

                        return View(item);

            }

            public IActionResult Deletar(string Codigo){


                    var item= _context.Itens.Find (Codigo);

                    if (item== null)

                            return RedirectToAction(nameof (Index));

                    return View(item);

            }

          

             
             
                [HttpPost]
                public IActionResult Deletar( Item item){

                      

                        var ItemBanco = _context.Itens.Find(item.Codigo);

                        _context.Itens.Remove(ItemBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

                }

             

           



        
    }
}