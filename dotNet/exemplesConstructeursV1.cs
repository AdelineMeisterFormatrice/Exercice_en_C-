class Disque{
	public Point centre;
	public Point GetCentre(){
		return this.centre;
	}
	public double GetCentreX(){
		return this.centre.X;
	}
}

class Triangle{
	public Point pA;
	public Point pB;
	public Point pC;
	
	public Triangle(){
		this.pA = new Point();
		this.pB = new Point();
		this.pC = new Point();
	}
	
	public Triangle(Point premierPoint, Point secondPoint, Point troisiemePoint){
		this.pA = premierPoint;
		this.pB = secondPoint;
		this.pC = troisiemePoint;
	}
	
	public Triangle(int paX,int paY, int pbX, int pbY, int pcX, int pcY ){
		this.pA = new Point(paX, paY);
		this.pB = new Point(pbX, pbY);
		this.pC = new Point(pCX, pCY);
	}
}

class Program{
	public static void Main(string[] args)
	{
		
		Triangle tri = new Triangle();
		
		tri.pA.X = 0;
		tri.pA.Y = 0;
		tri.pB.X = 1;
		tri.pB.Y = 1;
		
		
		Point p1 = new Point(2,3);
		Point p1prime = new Point();
		Point p2 = new Point(4,5);
		Point p3 = new Point(0,0);
		Triangle nouveauTriangle = new Triangle(p1,p2,p3);
		//ou
		
		Triangle nouveauTriangle = new Triangle(new Point(2,3),p2,new Point(0,0));
		
		
		tri.pA = p1;
		
		
		p2.X = 4;
		p2.Y = 5;
		tri.pB = p2;
		
		
		
		
		
		
		
		
		
		
		
		
		tri.pB.X = 12;
	
	
	
	
	
		Disque d = new Disque();
		
		d.centre = new Point();
		d.centre.X = 3;
		
		double centreX = d.GetCentreX();
		d.centre.X = 5;
		
			
	}
}
