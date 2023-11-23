using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPPlusOuMoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int valeurATrouver = new Random().Next(0, 100);
            int nombreDeCoups = 0;
            bool trouve = false;
            Console.WriteLine("Veuillez saisir un nombre compris entre 0 et 100 (exclu)");
            while(!trouve)
            {
                string saisie = Console.ReadLine();
                int valeursaisie;
                if (int.TryParse(saisie, out valeursaisie))
                {
                    if (valeursaisie == valeurATrouver)
                        trouve = true;
                    else
                    {
                        if (valeursaisie < valeurATrouver)
                            Console.WriteLine("Trop petit ...");
                        else
                            Console.WriteLine("Trop grand ...");
                    }
                    nombreDeCoups++;
                }
                else
                    Console.WriteLine("la valeur saisie est incorrecte, veuillez recommencer ...");
            }
            Console.WriteLine("Vous avez trouvé en " + nombreDeCoups + " coup(s)");
        }
    }
}
