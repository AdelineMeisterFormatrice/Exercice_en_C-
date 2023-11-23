using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum operateur
    {
        Addition,
        Soustraction,
        Multiplication,
        Division,
        OperateurNonReconnu
    }

    class Operation
    {
        public operateur choixOperateur;
        public int valeurOperandeGauche;
        public int valeurOperandeDroite;

        public int GetResult()
        {
            switch (choixOperateur)
            {
                case operateur.Addition:
                    return this.valeurOperandeGauche + this.valeurOperandeDroite;
                case operateur.Soustraction:
                    return this.valeurOperandeGauche - this.valeurOperandeDroite;
                case operateur.Multiplication:
                    return this.valeurOperandeGauche * this.valeurOperandeDroite;
                case operateur.Division:
                    return this.valeurOperandeGauche / this.valeurOperandeDroite;
                case operateur.OperateurNonReconnu:
                    return 0;
                default:
                    return 0;
            }
        }
    }
    class Program
    {
        static int DemanderOperandeALutilisateur(string message)
        {
            Console.WriteLine(message);
            string operandeGauche = Console.ReadLine();
            int valeurOperandeGauche = Int32.Parse(operandeGauche);
            return valeurOperandeGauche;
        }

        static operateur DemanderOperateurALutilisateur(string messageOp)
        {
            Console.WriteLine(messageOp);
            string choixOperateur = Console.ReadLine();

            switch (choixOperateur)
            {
                case "+":
                    return operateur.Addition;

                case "-":
                    return operateur.Soustraction;

                case "*":
                    return operateur.Multiplication;
                case "/":
                    return operateur.Division;

                default:
                    return operateur.OperateurNonReconnu;

            }
        }

        static void Main(string[] args)
        {
            List<Operation> resultats = new List<Operation>();

            Operation Calcul;
            do
            {
                Calcul = new Operation();
                Calcul.valeurOperandeGauche = DemanderOperandeALutilisateur("Merci de saisir le 1er nombre :");
                Calcul.choixOperateur = DemanderOperateurALutilisateur("Choisissez un operateur +,-,*,/ :");
                Calcul.valeurOperandeDroite = DemanderOperandeALutilisateur("Merci de saisir le 2eme nombre :");
                

                if (Calcul.valeurOperandeGauche == 0 && Calcul.valeurOperandeDroite == 0)
                {
                    Console.WriteLine("Pas de calcul possible avec les valeurs 0 !!!");
                }
                else
                {
                    Console.WriteLine("Le resultat est :  " + Calcul.GetResult());

                    resultats.Add(Calcul);

                    if (Calcul.choixOperateur == operateur.Division && Calcul.valeurOperandeDroite == 0)
                    {
                        Console.WriteLine("On ne peut pas diviser par 0 !!");

                    }

                }
               
            }
            while (Calcul.choixOperateur != operateur.OperateurNonReconnu);

            foreach(Operation resultatCourant in resultats)
            {
                Console.WriteLine(resultatCourant.valeurOperandeGauche + " " + resultatCourant.choixOperateur + " " + resultatCourant.valeurOperandeDroite + "=" + resultatCourant.GetResult());
            }
        }
    }
}   

