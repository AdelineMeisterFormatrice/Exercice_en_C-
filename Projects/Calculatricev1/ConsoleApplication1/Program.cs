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
            int valeurOperandeGauche = DemanderOperandeALutilisateur("Merci de saisir le 1er nombre :");
            int valeurOperandeDroite = DemanderOperandeALutilisateur("Merci de saisir le 2eme nombre :");
            operateur choixOpe = DemanderOperateurALutilisateur("Choisissez un operateur +,-,*,/ :");

            if(valeurOperandeGauche == 0 && valeurOperandeDroite == 0)
            {
                Console.WriteLine("Pas de calcul possible avec les valeurs 0 !!!");
            }
            else
            {
                switch(choixOpe)
                {
                    case operateur.Addition:
                        int addition = valeurOperandeGauche + valeurOperandeDroite;
                        Console.WriteLine("Le resultat de l'addition est : " + addition);
                        break;
                    case operateur.Soustraction:
                        int soustraction = valeurOperandeGauche - valeurOperandeDroite;
                        Console.WriteLine("Le resultat de la soustraction est :" + soustraction);
                        break;
                    case operateur.Multiplication:
                        int multiplication = valeurOperandeGauche * valeurOperandeDroite;
                        Console.WriteLine("Le resultat de la multiplication est :" + multiplication);
                        break;
                    case operateur.Division:
                        if (valeurOperandeDroite == 0)
                        {
                            Console.WriteLine("On ne peut pas diviser par 0 !!");

                        }
                        else
                        {
                            int division = valeurOperandeGauche / valeurOperandeDroite;
                            Console.WriteLine("Le resultat de la division est : " + division);
                        }
                        break;
                    case operateur.OperateurNonReconnu:
                        Console.WriteLine("Ce n'est pas un operateur valable !!!");
                        break;

                }
   
            }
            
        }
    }
}
