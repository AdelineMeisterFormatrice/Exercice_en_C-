using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace WebApplication3.Models
{
    public class Mail_Message
    {
      
        public string ReceiversAddress { get; private set; }
       
        public string Subject { get; private set; }
        public string HtmlBody { get; private set; }

        public Mail_Message( string receiverAdresse, string subject, string htmlBody)
        {
            
            this.ReceiversAddress = receiverAdresse;
            
            this.Subject = subject;
            this.HtmlBody = htmlBody;
        }

       
    }
    public class Authentification
    {
        public string SendersAdress { get; private set; }
        public string SendersPassword { get; private set; }

        public Authentification(string sendersAdress, string sendersPassword)
        {

            this.SendersAdress = sendersAdress;
            this.SendersPassword = sendersPassword;
        }
    }
}