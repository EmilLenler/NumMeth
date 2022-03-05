using System;
using static System.Console;
using static System.Math;
class main{
	public static double gamma(double x){
		if(x<0) return PI/Sin(PI*x)/gamma(1-x);
		if (x<9) return gamma(x+1)/x;
		double lngamma = x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}
	public static double loggamma(double x){
		return x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	}
	
	//Below solution is fairly hacky. obviously ln(gamma(x)) is only defined for positive x. Since ln(x) only is defined for positive numbers.
	//Thus the code is set to simply set 0's in the loggamma entries if x gamma(x) < 0.
	public static void Main(){
		for(double x=-5.17;x<=5.23;x+=0.003){
			if(Double.IsNaN(loggamma(x))){
			WriteLine($"{x} {gamma(x)} {0} {0}");
			}
			else
			{WriteLine($"{x} {gamma(x)} {loggamma(x)} {Exp(loggamma(x))}");}
			}
			}
		
		}
