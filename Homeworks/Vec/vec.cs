using static System.Console;
using static System.Math;
public class vec{
	// Constructors Come Here
	public double x,y,z;
	public vec(){x=y=z=0;}
	public vec(double a, double b, double c){ x=a; y=b; z=c; }
	// Redefine Operators::
	public static vec operator*(vec v, double c){return new vec(c*v.x, c*v.y, c*v.z);}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x, u.y+v.y, u.z+v.z);}
	public static vec operator-(vec u, vec v){return new vec(u.x-v.x, u.y-v.y, u.z-v.z);}
	public static vec operator-(vec v){return -1*v;}
	//Some methods come here:
	//Prints commands:
	public void print (string s){Write(s); WriteLine($"[{x} {y} {z}]");}
	public void print (){this.print("");}
	//Methods for dot-product, vector-product and norm
	public static vec vecprod(vec v , vec u){return new vec(v.x*u.x, v.y*u.y, v.z*u.z);}
	public static double dot(vec v, vec u){return v.x*u.x+v.y*u.y+v.z*u.z ;}
	public static double norm(vec v){return Sqrt(Pow(v.x,2)+Pow(v.y,2)+Pow(v.z,2));}
	public override string ToString(){
			return $"3D Euclidian vector x={x} y={y} z={z}";
			}
	//Methods for absolute and relative approximation
	public static bool absapprox(double a, double b,double tau=1e-9){
		if (Abs(a-b)<tau){return true;}
		else {return false;}
	}
	public static bool relapprox(double a, double b,double eps=1e-9){
		if (Abs(a-b)/(Abs(a)+Abs(b))<eps){return true;}
		else {return false;}
	}
	public static bool vecabsapprox(vec v, vec u){
		if (!absapprox(v.x,u.x))
		{return false;}
		if (!absapprox(v.y,u.y))
		{return false;}
		if (!absapprox(v.z,u.z))
		{return false;}
		{return true;}
	}
	public static bool vecrelapprox(vec v, vec u){
		if (!relapprox(v.x,u.x))
		{return false;}
		if (!relapprox(v.y,u.y))
		{return false;}
		if (!relapprox(v.z,u.z))
		{return false;}
		{return true;}
	}
}
