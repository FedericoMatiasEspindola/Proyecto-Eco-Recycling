﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ecoRecycling.Models;
using System.Net.Mail;
using System.Net;

namespace ecoRecycling.Controllers
{
    public class HomeController : Controller
    {
        public string myMail = "mrmattiaz@gmail.com";
        public string myPassword = "Boludo123";
        private readonly ILogger<HomeController> _logger;


        public string NombreContacto(string nombre)
        {
            return $"Gracias por el mensaje {nombre}";
        }

        [HttpPost]
        public IActionResult EnviarContacto(string nombre, string mail, string mensaje)
        {
            ViewBag.nombre = nombre;
            ViewBag.mail = mail;
            ViewBag.mensaje = mensaje;

            var smtpClient = new SmtpClient("smtp.gmail.com"){
                Port = 587,
                Credentials = new NetworkCredential(myMail, myPassword),
                EnableSsl = true,
            };

            string mensajeMail = $"{nombre}, tu mensaje fue recibido. Nos pondremos en contacto con usted.\n Su mensaje fue: {mensaje}";

            smtpClient.Send(myMail, mail, $"{nombre}, gracias por tu mensaje", mensajeMail);
            smtpClient.Send(myMail, myMail, $"Llego un mail de {mail}", $"{mensaje}");
            
            return View("Saludo");
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reciclaje()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        public IActionResult ReciclajeInfo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
