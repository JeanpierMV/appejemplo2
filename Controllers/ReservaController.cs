using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using appejemplo2.Data;
using appejemplo2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Http;

namespace appejemplo2.Controllers
{
   public class ReservaController: Controller
    {
        private readonly ILogger<ReservaController> _logger;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservaController (ApplicationDbContext context, ILogger<ReservaController> logger,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager= userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }

          [HttpPost]
       public IActionResult Create(Reserva objReserva){        
          
            _context.Add(objReserva);
            _context.SaveChanges();    
            ViewData["Message"] = "Se reservo la su mesa";
            return View("Index");
            
        }
    }
}