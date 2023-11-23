using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonApplication.Models;
using System.Data.SqlClient;

namespace MonApplication.Controllers
{
    public class OperationController : Controller
    {
        public ActionResult FormulaireSaisieOperation()
        {
            return View("FormulaireSaisie");
        }

        public ActionResult EnvoiFormulaireOperation(float operandeGauche, float operandeDroite,string operateurInput)
        {
            TypeOperateur typeOperateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurInput);
            return CalculOperation(typeOperateur, operandeGauche, operandeDroite);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addition(double operandeGauche, double operandeDroite)
        {
            return CalculOperation(TypeOperateur.Addition, operandeGauche, operandeDroite);
        }

        private ActionResult CalculOperation(TypeOperateur typeOperateur, double operandeGauche, double operandeDroite) 
        {
            Operation operationSaisie = new Operation(typeOperateur, operandeDroite, operandeGauche);
            if (operationSaisie.IsValide())
            {
                SauvegarderBdd(operationSaisie);
                return View("Operation",operationSaisie);
            }
            else
            {
                //TODO : gestion de l'erreur
                return View("ErreurPendantCalculOperation", operationSaisie);
            }
        }

        public ActionResult Soustraction(double operandeGauche, double operandeDroite)
        {
            return CalculOperation(TypeOperateur.Soustraction, operandeGauche, operandeDroite);
        }


        public ActionResult Multiplication(double operandeGauche, double operandeDroite)
        {
            return CalculOperation(TypeOperateur.Multiplication, operandeGauche, operandeDroite);
        }

        public ActionResult Division(double operandeGauche, double operandeDroite)
        {
            return CalculOperation(TypeOperateur.Division, operandeGauche, operandeDroite);
        }

        public ActionResult Puissance(double operandeGauche, double operandeDroite)
        {
            return CalculOperation(TypeOperateur.Puissance, operandeGauche, operandeDroite);
        }

        public ActionResult Historique(int clePrimaireOperation)
        {
            Operation operationEnBDD = TryRecupererOperationEnBDD(clePrimaireOperation);
            if (operationEnBDD != null)
            {
                return View("Operation", operationEnBDD);
            }
            else
            {
                return View("OperationNonTrouvee");
            }
        }

        public ActionResult Toutes()
        {
            List<Operation> operationsEnBDD = RecupererToutesLesOperationsEnBDD();
            return View("ToutesLesOperations", operationsEnBDD);
        }

        private const string SqlConnectionString =
            @"Server=.\SQLExpress;Initial Catalog=MaPremiereBDD; Trusted_Connection=Yes";

        static List<Operation> RecupererToutesLesOperationsEnBDD()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand commandeRecuperation = new SqlCommand(
                "SELECT numOperation, Operateur, OperandeDroite, OperandeGauche FROM Operation"
                , connexion);

            SqlDataReader reader= commandeRecuperation.ExecuteReader();

            List<Operation> resultats = new List<Operation>();

            while (reader.Read())
            {
                int numOperationBdd = (int)reader["numOperation"];
                float operandeDroiteBdd = (float)reader["OperandeDroite"];// reader.GetFloat(1);
                float operandeGaucheBdd = (float)reader["OperandeGauche"];
                string operateurBdd = (string)reader["Operateur"];

                TypeOperateur operateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurBdd);

                Operation operation = new Operation(
                    numOperationBdd, operateur, operandeDroiteBdd, operandeGaucheBdd);
                resultats.Add(operation);
            }

            connexion.Close();

            return resultats;
        }

        /// <summary>
        /// Retourne l'opération chargée en BDD
        /// Si l'opération n'existe pas, retourne null
        /// </summary>
        /// <param name="operationId"></param>
        /// <returns></returns>
        static Operation TryRecupererOperationEnBDD(int operationId)
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand commandeRecuperation = new SqlCommand(
                "SELECT numOperation, Operateur, OperandeDroite, OperandeGauche FROM Operation WHERE numOperation = @idParam"
                , connexion);
            commandeRecuperation.Parameters.AddWithValue("@idParam", operationId);

            SqlDataReader reader= commandeRecuperation.ExecuteReader();

            if (reader.Read())
            {
                int numOperationBdd = (int)reader["numOperation"];
                float operandeDroiteBdd = (float)reader["OperandeDroite"];// reader.GetFloat(1);
                float operandeGaucheBdd = (float)reader["OperandeGauche"];
                string operateurBdd = (string)reader["Operateur"];

                TypeOperateur operateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurBdd);

                connexion.Close();

                Operation resultat = new Operation(
                    numOperationBdd,operateur, operandeDroiteBdd, operandeGaucheBdd);
                return resultat;
            }
            else
            {
                return null;
            }
        }

        static void SauvegarderBdd(Operation operationASauvegarder)
        {
            if (operationASauvegarder != null)
            {
                SqlConnection connexion = new SqlConnection(SqlConnectionString);
                connexion.Open();

                SqlCommand command = new SqlCommand(
                    @"INSERT INTO Operation(Operateur, OperandeDroite, OperandeGauche) VALUES (@operateur, @droite, @gauche)"
                    , connexion);
                command.Parameters.AddWithValue("@operateur", TraduireTypeOperateurEnOperateurBDD(operationASauvegarder.Operateur));
                command.Parameters.AddWithValue("@droite", operationASauvegarder.OperandeDroite);
                command.Parameters.AddWithValue("@gauche", operationASauvegarder.OperandeGauche);
                command.ExecuteNonQuery();
                connexion.Close();
            }
        }

        static TypeOperateur TraduireChaineDeCaractèreEnTypeOperateur(string operateurEnBDD)
        {
            switch (operateurEnBDD)
            {
                case "+":
                    return TypeOperateur.Addition;
                case "-":
                    return TypeOperateur.Soustraction;
                case "*":
                    return TypeOperateur.Multiplication;
                case "/":
                    return TypeOperateur.Division;
                case "^":
                    return TypeOperateur.Puissance;
                default:
                    return TypeOperateur.Inconnu;
            }
        }
        static char TraduireTypeOperateurEnOperateurBDD(TypeOperateur typeOperateur)
        {
            switch (typeOperateur)
            {
                case TypeOperateur.Multiplication:
                    return '*';
                case TypeOperateur.Addition:
                    return '+';
                case TypeOperateur.Soustraction:
                    return '-';
                case TypeOperateur.Division:
                    return '/';
                case TypeOperateur.Puissance:
                    return '^';
                default:
                    return ' ';
            }
        }
    }
}