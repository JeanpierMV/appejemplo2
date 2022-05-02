using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//agregado
using appejemplo2.Models;
using appejemplo2.Data;
using Microsoft.EntityFrameworkCore;

namespace appejemplo2.Controllers
{
    public class CatalogoController: Controller
    {
      private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;
        public CatalogoController(ApplicationDbContext context,ILogger<CatalogoController> logger){
            _context = context;
            _logger = logger;
        }  
        public async Task<IActionResult> Index(string? searchString){
            
            var producto = from o in _context.DataProducto select o;

            if(!String.IsNullOrEmpty(searchString)){

                producto =producto.Where( s => s.Name.Contains(searchString));
            }

            return View(await producto.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id){
            Producto objProduct = await _context.DataProducto.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }
    }
}