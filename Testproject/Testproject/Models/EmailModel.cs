using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Testproject.Models
{
    public class EmailModel 
    {
        // GET: EmailModel
        public string Name { get; set; }
        public string Email { get; set; }
        public string SendersEmail { get; set; }

        public string SendersPassword { get; set; }
    }
}