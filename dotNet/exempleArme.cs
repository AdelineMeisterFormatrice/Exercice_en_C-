class Arme{
	public int pointDeDegatsMax;
	public int durabilite;
	
	public bool IsCassee(){
		return this.durabilite<=0;
	}
	
	public int CalculerPointsDeDegats(){
		if(this.IsCassee()){
			return 0;
		}
		else{
			return new System.Random().Next(this.pointDeDegatsMax+1);
		}
	}
	
	public void Utiliser(){
		this.durabilite = this.durabilite -1;
	}
}

class Personnage{
	public string nom;
	public int pointsDeVie;
	public Arme arme;
	
	public void EquiperUneArme(Arme nouvelleArme){
		this.arme = nouvelleArme;
	}
	
	public void AttaquerAutrePersonne(Personnage autrePersonne){
		int pointsDeDegats = this.arme.CalculerPointsDeDegats();
		autrePersonne.pointsDeVie -= pointsDeDegats;
		this.arme.Utiliser();
	}
	
	public bool IsMort(){
		return this.pointsDeVie<0;
	}
}

class Program{
	public static int Main(string[] args){
		Personnage personnagePrincipal = new Personnage();
		personnagePrincipal.nom = "Toto";
		personnagePrincipal.pointsDeVie = 10;
		
		Arme sonArme = new Arme();
		sonArme.pointDeDegatsMax = 4;
		sonArme.durabilite = 3;
		
		personnagePrincipal.EquiperUneArme(sonArme);
		
		Personnage adversaire = new Personnage();
		adversaire.nom = "Tutu";
		adversaire.pointsDeVie = 3;
		
		Arme couteau = new Arme();
		couteau.pointDeDegatsMax = 1;
		couteau.durabilite = 100;
		adversaire.EquiperUneArme(couteau);
		
		while(!personnagePrincipal.IsMort() || !adversaire.IsMort()){
			personnagePrincipal.AttaquerAutrePersonne(adversaire);
			adversaire.AttaquerAutrePersonne(personnagePrincipal);
		}
		
		return 0;
	}
}