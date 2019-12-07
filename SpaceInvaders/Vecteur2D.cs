using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Vecteur2D
    {
    	double x = 0;
    	double y = 0;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Vecteur2D(){
    		this.X = 0;
    		this.Y = 0;
    	}

    	public Vecteur2D(double x, double y){
    		this.X = x;
    		this.Y = y;
    	}

    	public double norme(){
    		return Math.Sqrt(((this.X)*(this.X))+((this.Y)*(this.Y)));
    	}
    	public static Vecteur2D operator +(Vecteur2D a, Vecteur2D b){
    		return new Vecteur2D(a.X+b.X,a.Y+b.Y);
    	}
    	public static Vecteur2D operator -(Vecteur2D a, Vecteur2D b){
    		return new Vecteur2D(a.X-b.X,a.Y-b.Y);
    	}
    	public static Vecteur2D operator -(Vecteur2D a){
    		return new Vecteur2D(-a.X, -a.Y);
    	}
    	public static Vecteur2D operator *(Vecteur2D a, double k){
    		return new Vecteur2D(k*a.X,k*a.Y);
    	}
    	public static Vecteur2D operator *(double k, Vecteur2D a){
    		return new Vecteur2D(k*a.X,k*a.Y);
    	}
    	public static Vecteur2D operator /(Vecteur2D a, double k){
    		return new Vecteur2D(a.X/k,a.Y/k);
    	}
    }
}
