using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class OperationController : Controller
    {
        private const string SqlConnectionString = @"Server=.\SQLExpress;initial catalog = Operation ; Trusted_connection = Yes";
        public ActionResult Index()
        {
            return View();
        }

        // GET: Operation
        public ActionResult Addition(double OperandeDroite, double OperandeGauche)
        {
            Operation monOperation = new Operation(TypeOperateur.Addition, OperandeDroite, OperandeGauche , 0);
            InsererOperationEnBDD(monOperation);
            return View ("Operations",monOperation);
        }

        private string CalculOperation(TypeOperateur typeOperateur, double operandeGauche, double operandeDroite)
        {
            Operation operationSaisie = new Operation(typeOperateur, operandeDroite, operandeGauche, 0);
            if (operationSaisie.IsValide())
            {
                InsererOperationEnBDD(operationSaisie);
                string representation = operationSaisie.GetRepresentationTextuelle();
                return representation;
            }
            else
            {
                return "Calcul invalide";
            }
        }

        public ActionResult Soustraction(double OperandeDroite, double OperandeGauche)
        {
            Operation monOperation = new Operation(TypeOperateur.Soustraction, OperandeDroite, OperandeGauche, 0);
            InsererOperationEnBDD(monOperation);
            return View ("Operations",monOperation);
        }

        public ActionResult Multiplication(double OperandeDroite, double OperandeGauche)
        {
            Operation monOperation = new Operation(TypeOperateur.Multiplication, OperandeDroite, OperandeGauche, 0);
            InsererOperationEnBDD(monOperation);
            return View("Operations", monOperation);
        }

        public ActionResult Division(double OperandeDroite, double OperandeGauche)
        {
            Operation monOperation = new Operation(TypeOperateur.Division, OperandeDroite, OperandeGauche, 0);
            InsererOperationEnBDD(monOperation);
            return View("Operations", monOperation);
        }

        public ActionResult Puissance(double OperandeDroite, double OperandeGauche)
        {
            Operation monOperation = new Operation(TypeOperateur.Puissance, OperandeDroite, OperandeGauche, 0);
            InsererOperationEnBDD(monOperation);
            return View("Operations", monOperation);
        }

       
        private static void InsererOperationEnBDD(Operation uneOperation)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            SqlCommand firstInsert =
                new SqlCommand("INSERT INTO Operation(OperandeGauche, OperandeDroite, Operateur) VALUES ( @valeurGauche, @valeurDroite, @operateur )", connection);
            var valeurGaucheParameter = new SqlParameter("@valeurGauche", uneOperation.OperandeGauche);
            var valeurDroiteParameter = new SqlParameter("@valeurDroite", uneOperation.OperandeDroite);
            var operateurParameter = new SqlParameter("@operateur", TraduireTypeOperateurEnOperateurBDD(uneOperation.Operateur) );
            firstInsert.Parameters.Add(valeurGaucheParameter);
            firstInsert.Parameters.Add(valeurDroiteParameter);
            firstInsert.Parameters.Add(operateurParameter);
            firstInsert.ExecuteNonQuery();

            connection.Close();
        }

       
         public ActionResult HistoriqueOperation (int IdOperation)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            SqlCommand Historique = new SqlCommand("SELECT * FROM Operation WHERE id_operation = @IdOperation ", connection);
            SqlParameter IdOperationSql = new SqlParameter("@IdOperation",IdOperation);
            Historique.Parameters.Add(IdOperationSql);
            SqlDataReader reader = Historique.ExecuteReader();
            reader.Read();

            string operateur=reader.GetString(3);
            double droiteBdd = reader.GetInt32(2);
            double gaucheBdd = reader.GetInt32(1);
            int IdOperateur = reader.GetInt32(0);

            Operation operationLue = new Operation(TraduireChaineDeCaractèreEnTypeOperateur(operateur), droiteBdd, gaucheBdd, IdOperateur);

            connection.Close();

            return View("Operations", operationLue);
        }

        public ActionResult  ToutesLesOperation()
        {
            List<Operation> resultats = new List<Operation>();

            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Operation", connexion);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string operateurBdd = reader.GetString(3);
                double droiteBdd = reader.GetInt32(2);
                double gaucheBdd = reader.GetInt32(1);
                int IdOperateur = reader.GetInt32(0);

                TypeOperateur operateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurBdd);

                Operation operationLue = new Operation(operateur, droiteBdd, gaucheBdd, IdOperateur);
                resultats.Add(operationLue);
            }

            connexion.Close();
            return View("Historique", resultats);
        }

        static TypeOperateur TraduireChaineDeCaractèreEnTypeOperateur(string saisieUtilisateur)
        {
            switch (saisieUtilisateur)
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