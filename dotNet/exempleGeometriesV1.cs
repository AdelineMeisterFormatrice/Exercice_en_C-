class Disque{
	public double rayon;
	public double GetArea(){
		return Math.Pi * this.rayon * this.rayon;
	}
	public double GetPerimeter(){
		double diametre = 2.0*this.rayon;
		return  Math.Pi * diametre;
	}
}

class Point{
	public double X;
	public double Y;
	
	public Point(){
		this.X = 0;
		this.Y = 0;
	}
	
	public Point(double posX, double posY){
		this.X = posX;
		this.Y = posY;
	}
}

class rectangle
{

    public double largeur;
    public double longueur;

    public double GetArea()
    {

        return 

    }


}

class Program{
	public static void Main(string[] args){
		Disque monPremierDisque = new Disque();
		monPremierDisque.rayon = 3.0;
		
		double aireDuDisque = monPremierDisque.GetArea();
		double perimetre = monPremierDisque.GetPerimeter();
		
		Console.WriteLine("Aire = "+aireDuDisque+" et périmètre = "+ perimetre);
	}
}