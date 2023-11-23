using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MonApplication.Models;

namespace MonApplication.Controllers
{
    //Pour info : Script de création de la table Utilisateurs :
/*
CREATE TABLE [dbo].[Utilisateurs](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Login] [nvarchar](255) NOT NULL,
[Password] [nvarchar](255) NOT NULL,
[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
*/
public class HomeController : Controller
{
// GET: Home
public ActionResult Index()
{
    //Models.PageIndexModel model = new Models.PageIndexModel();

    //int compteurTotalOperations = GetCompteurTotalOperationsEnBDD();
    //model.CompteurTotalOperations = compteurTotalOperations;

    //List<Models.PageIndexSousCompteurModel> sousCompteurs = GetSousCompteursFromBDD();
    //model.SousCompteurs = sousCompteurs;

    PageIndexModel model = new PageIndexModel();
    model.CompteurUtilisateurs = RecupererNombreUtilisateursDepuisBDD();
    //model.Utilisateurs = RecupererListeUtilisateursDepuisBDD();


    return View(model);
}

private const string SqlConnectionString =
   @"Server=.\SQLExpress;Initial Catalog=MaPremiereBDD; Trusted_Connection=Yes";

private int RecupererNombreUtilisateursDepuisBDD()
{
    SqlConnection connexion = new SqlConnection(SqlConnectionString);
    connexion.Open();

    SqlCommand recuperationNombreUtilisateurs =
        new SqlCommand("SELECT COUNT(*) FROM Utilisateurs", connexion);

    int nombreUtilisateurs = (int)recuperationNombreUtilisateurs.ExecuteScalar();

    connexion.Close();

    return nombreUtilisateurs;
}

//private List<PageIndexUtilisateurModel>
private int GetCompteurTotalOperationsEnBDD()
{
    SqlConnection connexion = new SqlConnection(SqlConnectionString);
    connexion.Open();

    SqlCommand recuperationCompteurTotal =
        new SqlCommand("SELECT COUNT(*) FROM Operation", connexion);

    int compteurTotal = (int)recuperationCompteurTotal.ExecuteScalar();

    connexion.Close();

    return compteurTotal;
}

//private List<PageIndexSousCompteurModel> GetSousCompteursFromBDD()
//{
//    SqlConnection connexion = new SqlConnection(SqlConnectionString);
//    connexion.Open();

//    SqlCommand recuperationSousCompteurs =
//        new SqlCommand("SELECT Operateur, Count(*) FROM Operation GROUP BY Operateur", connexion);
//    SqlDataReader reader = recuperationSousCompteurs.ExecuteReader();

//    List<PageIndexSousCompteurModel> resultats = new List<PageIndexSousCompteurModel>();
//    while (reader.Read())
//    {
//        string typeOperateurBDD = reader.GetString(0);
//        int nombreOperationsBDD = reader.GetInt32(1);

//        PageIndexSousCompteurModel sousCompteurCourant = new PageIndexSousCompteurModel();
//        sousCompteurCourant.NombreOperations = nombreOperationsBDD;
//        sousCompteurCourant.Operateur = typeOperateurBDD;
//    }

//    connexion.Close();
//}

//private Models.PageIndexModel RecupererPageIndexDepuisBDD()
//{
//    SqlConnection connexion = new SqlConnection(SqlConnectionString);
//    connexion.Open();

//    SqlCommand recuperationNombreOperations = 
//        new SqlCommand("SELECT COUNT(*) FROM Operation", connexion);
//    int nombreOperations = (int)recuperationNombreOperations.ExecuteScalar();

//    SqlCommand recuperationNombreAdditions = 
//        new SqlCommand("SELECT COUNT(*) FROM Operation WHERE [Operateur] = '+'", connexion);
//    int nombreAdditions = (int)recuperationNombreAdditions.ExecuteScalar();


//    connexion.Close();

//    Models.PageIndexModel model = new Models.PageIndexModel();
//    model.NombreAdditions = nombreAdditions;
//    model.NombreOperations = nombreOperations;
//    return model;
//}
public ActionResult AutreChose()
{
    return View();
}
}
}
 