using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace MonApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Models.PageIndexModel model = RecupererPageIndexDepuisBDD();
            return View(model);
        }

        private const string SqlConnectionString =
           @"Server=.\SQLExpress;Initial Catalog=MaPremiereBDD; Trusted_Connection=Yes";

        private Models.PageIndexModel RecupererPageIndexDepuisBDD()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand recuperationNombreOperations = 
                new SqlCommand("SELECT COUNT(*) FROM Operation", connexion);
            int nombreOperations = (int)recuperationNombreOperations.ExecuteScalar();

            SqlCommand recuperationNombreAdditions = 
                new SqlCommand("SELECT COUNT(*) FROM Operation WHERE [Operateur] = '+'", connexion);
            int nombreAdditions = (int)recuperationNombreAdditions.ExecuteScalar();


            connexion.Close();

            Models.PageIndexModel model = new Models.PageIndexModel();
            model.NombreAdditions = nombreAdditions;
            model.NombreOperations = nombreOperations;
            return model;
        }
        public ActionResult AutreChose()
        {
            return View();
        }
    }
}