using static System.Math;
using static System.Console;
using System;
class main{
	static complex G(complex z){
	if(cmath.abs(z)<0) return PI/cmath.sin(PI*z)/G(1-z);
	if(cmath.abs(z)<9) return G(z+1)/z;
	complex lngamma = z*cmath.log(z+1/(12*z-1/z/10))-z+cmath.log(2*PI/z)/2;
	//return cmath.sqrt(2*PI/z)*cmath.pow((1/E*(z+1/(12*z-1/10/z))),z);
	return cmath.exp(lngamma);
	}
	public static void Main(){
	for(double R=-4.13;R<=4.13;R+=0.017){
		for(double Ima=-2.13;Ima<=2.13;Ima+=0.017){
		complex z = new complex(R,Ima);
			WriteLine($"{R} {Ima} {cmath.abs(G(z))}");
			}
	}
	}
}
