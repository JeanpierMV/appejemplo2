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
        public async Task<IActionResult> Index(){
            
            var productos = from o in _context.DataProducto select o;
            return View(await productos.ToListAsync());
        }
    }
}