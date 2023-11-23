using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceAmeliore
{
    class Operation
    {
        public int _operandeDroite;
        public int _operandeGauche;
        public string _operateur;

        //Calcul le résultat d'une opération choisi
        public double GetResult()
        {
            switch (_operateur)
            {
                case "+":
                    return Addition();
                case "-":
                    return Soustraction();
                case "*":
                    return Multiplication();
                case "/":                  
                        return Division();
                case "^":
                    return Puissance();
                default:
                    return -1;
            }
        }

        //Permet de retourner la chaine de résultat en fonction de l'opérateur
        public string GetRepresentationVisuelle()
        {
            switch (this._operateur)
            {
                case "+":
                    return (this._operandeGauche + " + " + this._operandeDroite + " = " + this.GetResult());
                case "-":
                    return (this._operandeGauche + " - " + this._operandeDroite + " = " + this.GetResult());
                case "*":
                    return (this._operandeGauche + " x " + this._operandeDroite + " = " + this.GetResult());
                case "/":
                    return (this._operandeGauche + " / " + this._operandeDroite + " = " + this.GetResult());
                case "^":
                    return (this._operandeGauche + " ^ " + this._operandeDroite + " = " + this.GetResult());
                default:
                    return string.Empty;
            }
        }

        //Bloc de méthodes de calcul
        public int Addition()
        {
            return this._operandeGauche + this._operandeDroite;
        }

        public int Soustraction()
        {
            return this._operandeGauche - this._operandeDroite;
        }

        public int Multiplication()
        {
            return this._operandeGauche * this._operandeDroite;
        }

        public double Division()
        {
            return (double)this._operandeGauche / this._operandeDroite;
        }

        public double Puissance()
        {
            return Math.Pow((double)this._operandeGauche, this._operandeDroite);
        }
    }

    class Program
    {   
        //Demande un opérande à l'utilisateur
        static int AskOperande(string message)
        {
            Console.WriteLine(message);
            int operande = Int32.Parse(Console.ReadLine());
            return operande;
        }

        //Demande un opérateur à l'utilisateur
        static string AskOperator(string message)
        {
            Console.WriteLine(message);
            string choix = Console.ReadLine();
            return choix;
        }

        static void Main(string[] args)
        {
            //Création de la liste qui contiendra les opérations
            List<Operation> historique = new List<Operation>();
            
            while(true)
            {
                Operation calcul = new Operation();

                //On stock l'oprérateur choisi
                calcul._operateur = AskOperator(@"Veuillez choisir votre opérateur : + , -, *, /, ^");

                //Si l'opérateur est la chaine vide, on sort de la boucle
                if (calcul._operateur == "")
                {
                    break;
                }

                //On stock les opérandes du calcul
                calcul._operandeGauche = AskOperande("Veuillez saisir le 1er nombre");
                calcul._operandeDroite = AskOperande("Veuillez saisir le 2ème nombre");

                //On remplit la liste avec les opérations
                historique.Add(calcul);

                Console.WriteLine(calcul.GetResult());
            }

            //Pour chaque opération stocké, on affiche la liste de résultats
            foreach(var elements in historique)
            {
                Console.WriteLine(elements.GetRepresentationVisuelle());
            }
            
            Console.ReadKey();
        }
    }
}
