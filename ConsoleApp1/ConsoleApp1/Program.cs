using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp1


{
    
    class Program
    {
        static void Main(string[] args)
        {
            string SendersAddress = "simpoll.sondage@gmail.com";
            string ReceiversAddress = "damien.meistertzheim@neuf.fr";
            string SendersPassword = "Simpoll68@";
            string subject = "Test Envoie Mail ";

             string htmlBody = @"<!doctype html><html><headers><img src=""https://image.noelshack.com/fichiers/2018/04/6/1517067469-simpoll.png ""  alt=""Logo Simpoll""/></headers>
                                 <h1>Merci d'avoir choisi Simpoll pour créer votre sondage</h1><br /><h2>Voici vos 3 liens :</h2><br />";                                                                                                                                
           
            
           
            SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.sfr.fr",
                    Port = 25,
                   
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                    
                };

                MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, htmlBody);
            message.IsBodyHtml = true;
           


            smtp.Send(message);
            Console.WriteLine("message envoyé");
            Console.ReadKey();
            
           
            
        }
    }
}
