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
	
	public Point() : this(0,0){
		
	}
	
	public Point(Point autrePoint): this(autrePoint.X, autrePoint.Y){
	}
	
	public Point(double posX, double posY){
		this.X = posX;
		this.Y = posY;
	}
	
	public static double DistanceEntreDeuxPoints(Point a, Point b){
		return Math.Sqrt(Math.Pow(a.x-b.x,2)+Math.Pow(a.y-b.y,2));
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
		Point p1 = new Point(0,0);
		Point p2 = new Point(12,15);
		double distance = Point.DistanceEntreDeuxPoints(p1,p2);
		
		Disque monPremierDisque = new Disque();
		monPremierDisque.rayon = 3.0;
		
		double aireDuDisque = monPremierDisque.GetArea();
		double perimetre = monPremierDisque.GetPerimeter();
		
		Console.WriteLine("Aire = "+aireDuDisque+" et périmètre = "+ perimetre);
	}
}
