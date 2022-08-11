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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;



namespace appejemplo2.Controllers
{
    public class CrealController: Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CrealController(ApplicationDbContext context,ILogger<CatalogoController> logger,UserManager<IdentityUser> userManager){
            _context = context;
            _logger = logger;
            _userManager= userManager;
        }  

         public async Task<IActionResult> Index(string? searchString){
            var pedidos = from o in _context.DataPedido select o;

            pedidos =pedidos.Where( s => s.Status.Contains("Pendiente"));
            
          

             return View(await pedidos.ToListAsync());
         }

       public async Task<IActionResult> Details(int? id){

            Pedido objProduct = await _context.DataPedido.FindAsync(id);
            DetallePedido objProduct1 = await _context.DataDetallePedido.FindAsync(objProduct.ID);

            var items = from o in _context.DataDetallePedido select o;
            items = items.Include(p => p.Producto).Include(p => p.pedido).Where(w => w.pedido.ID.Equals(objProduct.ID));
            
                 
            var carrito = await items.ToListAsync();
            var total= carrito.Sum(c => c.Cantidad + c.Cantidad);

            dynamic model = new ExpandoObject(); 
            model.montoTotal = total;          
            model.elementosCarrito = carrito;
            
           // var mtoUsuarios = db.AspNetUsers;

            return View(model);

         }

        

      

         




    }
}