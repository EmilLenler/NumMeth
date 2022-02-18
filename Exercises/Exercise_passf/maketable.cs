using static System.Console;
using System;
using static System.Math;
public class maketable{
	public static void make_table(Func<double,double> f, double a, double b, double dx){
		for(double x=a;x<=b+dx;x+=dx){
		if(x<=b)WriteLine($" {x} {f(x)}");
		else WriteLine($" {b} {f(b)}");}
	}
}
