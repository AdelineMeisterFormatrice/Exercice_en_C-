using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours2
{
    class Program
    {
        static void Main(string[] args)
        {
            //création d'une liste
            List<string> choixUtilisateur = new List<string>();
            
            string saisieUtilisateur;

            //boucle do while pour remplir la liste
            do
            {
                Console.WriteLine("Veuillez saisir quelque chose :" );
                saisieUtilisateur = Console.ReadLine();
                choixUtilisateur.Add(saisieUtilisateur);
                
            }
            while (saisieUtilisateur != "quit");

            //boucle foreach pour afficher les elements de la liste
            foreach(string element in choixUtilisateur)
            {
                Console.WriteLine(element);
            }
        }
    }
}
