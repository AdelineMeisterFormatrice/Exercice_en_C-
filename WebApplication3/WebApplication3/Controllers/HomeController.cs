using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using WebApplication3.Models;

namespace ConsoleApp1.Controllers


{

   public class ConsoleApp1Controller : Controller
    {
        public ActionResult EnvoieMail()
        {
            Mail_Message newMail  = new Mail_Message( "damien.meistertzheim@neuf.fr",  "Test Envoie Mail ", @"<!doctype html><html><headers><img src=""/Content/simpoll.png ""  alt=""Logo Simpoll""/></headers><h2>Merci d'avoir choisi Simpoll pour créer votre sondage</h2><br /><h2>Voici vos 3 liens :</h2><br />");
           



            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.sfr.fr",
                Port = 25,

                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("simpoll.sondage@gmail.com","Simpoll68@"),

            };

           // Mail_Message message = new Mail_Message(newMail);
           // newMail.IsBodyHtml = true;



            smtp.Send("simpoll.sondage@gmail.com",newMail);
            return View("messageEnvoyé");



        }
    }
}
