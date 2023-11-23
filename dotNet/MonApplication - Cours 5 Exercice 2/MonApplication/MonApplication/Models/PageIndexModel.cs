using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonApplication.Models
{
    public class PageIndexModel
    {
        //    public int CompteurTotalOperations { get; set; }

        //    public List<PageIndexSousCompteurModel> SousCompteurs { get; set; }

        public int CompteurUtilisateurs { get; set; }

        public List<PageIndexUtilisateurModel> Utilisateurs { get; set; }
    }
}