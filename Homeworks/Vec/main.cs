using static System.Console;

public class illustration{
	static void Main() {
	vec u= new vec(1,2,3);
	u.print("u= ");
	vec v= new vec(4,5,6);
	v.print("v= ");
	(u+v).print("u+v= ");
	(u-v).print("u-v= ");
	(2*u).print("2*u= ");
	(-u).print("-u= ");
	vec.vecprod(u,v).print("Vector product of u and v is ");
	WriteLine($"Dot product of u and v is {vec.dot(u,v)}");
	WriteLine($"Norm of v is {vec.norm(v)}");
	Write("ToString for v: ");
	WriteLine(v);
	WriteLine("Absolute Vector Approximate:");
	Write("Is u ~ v?: ");
	WriteLine(vec.vecabsapprox(u,v));
	Write("is v ~ u?: ");
	WriteLine(vec.vecabsapprox(v,u));
	Write("Is u ~ u?: ");
	WriteLine(vec.vecabsapprox(u,u));
	vec udelta= new vec(1+1e-11,2+1e-11,3+1e-11);
	WriteLine("Define udelta as u + 1e-11*[1 1 1] and check if approximately same");
	WriteLine(vec.vecabsapprox(udelta,u));
	WriteLine("Relative Vector approximate: ");
	Write("is u ~ v?: ");
	WriteLine(vec.vecrelapprox(u,v));
	Write("is v ~ u?: ");
	WriteLine(vec.vecrelapprox(v,u));
	Write("is u ~ udelta?: ");
	WriteLine(vec.vecrelapprox(u,udelta));
	}
}
