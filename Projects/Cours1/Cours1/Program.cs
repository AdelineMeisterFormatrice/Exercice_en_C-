using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1
{
    enum JourDeLaSemaine
    {
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
        Dimanche
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool isVrai = true;
            short nombreMois = 12;
            int nombreDeJourDansLannee = 365;
            long monNombreLong = 0L;
            float piPasPrecis = 3.14f;
            double piPlusPrecis = 3.14159265359d;
            decimal billetCinquanteEuros = 50.00m;
            string monNom = "Meistertzheim";
            string monPrenomEtMonAge = @"Damien
                                                39 ans";
            string vide = "";

            Console.WriteLine("Bonjour !");
            JourDeLaSemaine jourActuel = JourDeLaSemaine.Mercredi;
            Console.WriteLine("Nous sommes " + jourActuel);
            Console.WriteLine("Je m'appelle " + monNom);
            Console.WriteLine(" " + monPrenomEtMonAge);
            Console.ReadKey();




        }
    }
}
