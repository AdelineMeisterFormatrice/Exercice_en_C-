using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMonstre
{

    public class De
    {
        private Random random;

        public De()
        {
            random = new Random();
        }

        public int LanceLeDe()
        {
            return random.Next(1, 7);
        }
    }

    public class Monstrefacile
    {
        private const int degats = 10;
        protected De de;
        public bool EstVivant { get; private set; }

       public void MonstreFacile()
         {
             de = new De();
             EstVivant = true;
         }

    public virtual void Attaque(Joueur joueur)
    {
        int lanceMonstre = lanceLeDe();
        int lanceJoueur = joueur.lanceLeDe();
        if (lanceMonstre > lanceJoueur)
            joueur.subitDegats(degats);
    }
    
    public void SubitDegats()
    {
        EstVivant = false;
    }

    public int LanceLeDe()
    {
        return de.LanceLeDe();
    }
    }

public class MonstreDifficile : MonstreFacile
{
    private const int degatsSort = 5;

    public override void Attaque(Joueur joueur)
    {
        base.Attaque(joueur);
        joueur.subitDegats(SortMagique());
    }

    private int SortMagique();
    {
    int valeur = de.LanceLeDe();
    if(valeur == 6)
        return 0;
        return degatsSort* valeur;
    }
}

public class Joueur
{
    private De de;
    public int PtsdeVie { get; private set; }
    public bool EstVivant
    {
        get { return PtsdeVie > 0; }
    }

    public Joueur(int points)
    {
        PtsdeVie = points;
        de = new De();
    }

    public void Attaque(MonstreFacile monstre)
    {
        int lanceJoueur = lanceLeDe();
        int lancemonstre = monstre.LanceLeDe();
        if (lanceJoueur >= lancemonstre)
            monstre.Subitdegats();
    }

    public int LanceLeDe()
    {
        return de.LanceLeDe():
    }

    public void SubitDegats(int degats)
    {
        if (!BouclierFonctionne())
            PtsdeVie -= degats;
    }

    private bool BouclierFonctionne()
    {
        return de.LanceLeDe() <= 2;
    }
}

class Program
    {

        private static Random random = new Random();
        static void Main(string[] args)
        {
        Jeu1();
        }

        private static void Jeu1()
    {
        Joueur Damien = new Joueur(150);
        int cptFacile = 0;
        int cptDifficile = 0;
        while (Damien.EstVivant)
        {
            MonstreFacile monstre = FabriqueDeMonstre();
            while (monstre.EstVivant && Damien.EstVivant)
            {
                Damien.Attaque(monstre);
                if (monstre.EstVivant)
                    monstre.Attaque(Damien);
            }

            if(Damien.EstVivant)
            {
                if (monstre is MonstreDifficile)
                    cptDifficile++;
                else
                    cptFacile++;
            }
            else
            {
                Console.WriteLine("Snif, vous êtes mort ...");
                break;
                    }

        }
        Console.WriteLine("Bravo !!! Vous avez tué {0} monstres faciles et {1} monstres difficiles. Vous avez {2} points.", cptFacile, cptDifficile, cptFacile + cptDifficile * 2);
    }

    private static MonstreFacile FabriqueDeMonstre()
    {
        if (random.Next(2) == 0)
            return new MonstreFacile();
        else
            return new MonstreDifficile();

    }

    }
}
