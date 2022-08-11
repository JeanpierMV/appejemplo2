using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//agregado
using appejemplo2.Models;
using appejemplo2.Data;
using appejemplo2.Integration.Sengrid;


namespace appejemplo2.Controllers
{
    public class ContactoController: Controller
    {   
        private readonly ILogger<ContactoController> _logger;
        private readonly SendMailIntegration _sendgrid;

        private readonly ApplicationDbContext _context;
        public ContactoController(ApplicationDbContext context,ILogger<ContactoController> logger, SendMailIntegration sendgrid){
            _context = context;
            _logger = logger;
            _sendgrid = sendgrid;
        }

         public IActionResult Index(){

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contacto objContacto){

            _context.Add(objContacto);
            _context.SaveChanges();
            
            await _sendgrid.SendMail(objContacto.Email,
            objContacto.Nombre,
            "Hola Bienvenido al PB",
            "Revisaremos tu consulta",
            SendMailIntegration.SEND_SENDGRID);

             await _sendgrid.SendMail(objContacto.Email,
                objContacto.Nombre,
                "Bienvenido al e-comerce",
                "Revisaremos su consulta en breves momentos y le responderemos",
                SendMailIntegration.SEND_REST);


            ViewData["Message"]= "Gracias por contactarnos";  
        
            return View("Index");
        }

    }
}