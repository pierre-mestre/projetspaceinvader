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

    	public Vecteur2D(){
    		this.x = 0;
    		this.y = 0;
    	}

    	public Vecteur2D(double x, double y){
    		this.x = x;
    		this.y = y;
    	}

    	public double norme(){
    		return Math.Sqrt(((this.x)*(this.x))+((this.y)*(this.y)));
    	}
    	public static Vecteur2D operator +(Vecteur2D a, Vecteur2D b){
    		return new Vecteur2D(a.x+b.x,a.y+b.y);
    	}
    	public static Vecteur2D operator -(Vecteur2D a, Vecteur2D b){
    		return new Vecteur2D(a.x-b.x,a.y-b.y);
    	}
    	public static Vecteur2D operator -(Vecteur2D a){
    		return new Vecteur2D(-a.x, -a.y);
    	}
    	public static Vecteur2D operator *(Vecteur2D a, double k){
    		return new Vecteur2D(k*a.x,k*a.y);
    	}
    	public static Vecteur2D operator *(double k, Vecteur2D a){
    		return new Vecteur2D(k*a.x,k*a.y);
    	}
    	public static Vecteur2D operator /(Vecteur2D a, double k){
    		return new Vecteur2D(a.x/k,a.y/k);
    	}
    }
}
