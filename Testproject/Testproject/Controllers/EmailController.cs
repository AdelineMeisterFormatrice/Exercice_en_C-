using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Testproject.Models;
using System.Net;
using System.Net.Mail;


namespace Testproject.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            var emailModel = new EmailModel()
            {
                Name = "Damien",
                Email = "damien.meistertzheim@neuf.fr",
                SendersEmail = "simpoll.songage@gmail.com",
                SendersPassword = "Simpoll68@",
            };
           

            var email = new MailMessage();
            {
                email.Body = "Email";
                email.IsBodyHtml = true;
                email.Subject = "test";

            }
            email.To.Add(new MailAddress(emailModel.Email, emailModel.Name));

            var smtpClient = new SmtpClient
            {
                Host = "smtp.sfr.fr",
                Port = 25,
               
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailModel.SendersEmail,emailModel.SendersPassword),

            };

            smtpClient.Send(email);
            return View();
        }
    }
}