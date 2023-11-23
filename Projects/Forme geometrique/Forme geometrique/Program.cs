using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme_geometrique
{
    class Disque
    {
        public double _rayon;

        public Disque(double rayon)
        {
            _rayon = rayon;
        }

        public double GetArea()
        {
           return _rayon*_rayon*Math.PI;
        }

        public double GetPerimeter()
        {
            return _rayon * 2 * Math.PI;
        }
    }

    class Rectangle
    {
        public double _largeur;
        public double _hauteur;

        public Rectangle (double largeur , double hauteur)
        {
            _largeur = largeur;
            _hauteur = hauteur;
        }

        public double GetArea()
        {
            return _largeur * _hauteur;
        }

        public double GetPerimeter()
        {
            return (_largeur + _hauteur) * 2;
        }
    }

    class RectangleV2
    {

    public Point _pA;
    public Point _pB;

    public RectangleV2(Point pA,Point pB)
        {
            _pA = pA;
            _pB = pB;
        }

    public double GetLargeur()
    {
        return Math.Abs(_pA.X - _pB.X);
    }

    public double GetHauteur()
    {
        return Math.Abs(_pA.Y - _pB.Y);
    }

    public double GetArea()
    {
        return this.GetLargeur() * this.GetHauteur();
    }

    public double GetPerimeter()
    {
        return (this.GetLargeur() + this.GetHauteur()) * 2.0;
    }
}


class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double DistanceEntreDeuxPoints(Point a,Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }

    class Triangle
    {
        public Point _pA;
        public Point _pB;
        public Point _pC;

        public Triangle(Point pA, Point pB, Point pC)
        {
            _pA = pA;
            _pB = pB;
            _pC = pC;
        }

        public double GetPerimeter()
        {
            return Point.DistanceEntreDeuxPoints(_pA, _pB) +
                    Point.DistanceEntreDeuxPoints(_pB, _pC) +
                    Point.DistanceEntreDeuxPoints(_pA, _pC);
        }

        public double GetArea()
        {
            return 0.5 * (Math.Abs(_pB.X - _pA.X) * (_pC.Y - _pA.Y) - (_pC.X - _pA.X) * (_pB.Y - _pA.Y));
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Disque monPremierDisque = new Disque(3);
                // monPremierDisque._rayon = 3;

                double aireDuDisque = monPremierDisque.GetArea();
                double perimetreDuDisque = monPremierDisque.GetPerimeter();

                Console.WriteLine("Aire du disque = " + aireDuDisque + " et périmètre du disque = " + perimetreDuDisque);
                Console.ReadKey();

                Rectangle monPremierRectangle = new Rectangle(2, 5);
                // monPremierRectangle._hauteur = 2;
                // monPremierRectangle._largeur = 5;

                double aireDuRectangle = monPremierRectangle.GetArea();
                double perimetreDuRectangle = monPremierRectangle.GetPerimeter();

                Console.WriteLine("Aire du rectangle = " + aireDuRectangle + " et périmètre du rectangle = " + perimetreDuRectangle);
                Console.ReadKey();

                Point _premierPoint = new Point(10, 15);
                Point _secondPoint = new Point(5, 25);

                RectangleV2 secondRectangle = new RectangleV2(_premierPoint, _secondPoint);

                //premierPoint.X = 10;
                //premierPoint.Y = 15;
                //secondRectangle.pA = premierPoint;


                //secondPoint.X = 10;
                //secondPoint.Y = 15;
                //secondRectangle.pB = secondPoint;

                double aireDuRectangle2 = secondRectangle.GetArea();
                double perimetreDuRectangle2 = secondRectangle.GetPerimeter();

                Console.WriteLine("Aire du rectangleV2 = " + aireDuRectangle2 + " Périmètre du rectangleV2 = " + perimetreDuRectangle2);
                Console.ReadKey();

                Point premierPoint = new Point(0, 0);
                Point secondPoint = new Point(10, 15);
                Point troisiemePoint = new Point(5, 25);

                Triangle premierTriangle = new Triangle(premierPoint, secondPoint, troisiemePoint);

                Console.WriteLine("Perimetre du triangle = " + premierTriangle.GetPerimeter()+" Aire du triangle = " +premierTriangle.GetArea());
                Console.ReadKey();

            }
        }
    }
