using static System.Math;
using static System.Console;
using System;
class main{
	static complex G(complex z){
	complex lnG = z*cmath.log(z+1/(12*z-1/z/10))-z+cmath.log(2*PI*z)/2;
       	return cmath.exp(lnG);
	}
	public static void Main(){
	for(double R=-4;R<=4;R+=0.01){
		for(double Ima=-2;Ima<=2;Ima+=0.1)
			WriteLine($"{R} {Ima} {cmath.abs(G(R+cmath.I*Ima))}");
	
	}
	}
}
