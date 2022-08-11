using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//agregado
using appejemplo2.Models;
using appejemplo2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace appejemplo2.Controllers
{
    public class CatalogoController: Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context,ILogger<CatalogoController> logger,UserManager<IdentityUser> userManager){
            _context = context;
            _logger = logger;
            _userManager= userManager;
        }  
        public async Task<IActionResult> Index(string? searchString){
            
            var producto = from o in _context.DataProducto select o;

            if(!String.IsNullOrEmpty(searchString)){

                producto =producto.Where( s => s.Name.Contains(searchString));
            }

             producto =producto.Where( s => s.Status.Contains("A"));

            

            return View(await producto.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id){
            Producto objProduct = await _context.DataProducto.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] ="Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return View("Index",productos);
            }else{
                var producto = await _context.DataProducto.FindAsync(id);
                Proforma proforma =new Proforma();                
                proforma.Producto = producto;
                proforma.Precio=producto.Precio;
                proforma.Cantidad=1;
                proforma.UserID=userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }







    }
}