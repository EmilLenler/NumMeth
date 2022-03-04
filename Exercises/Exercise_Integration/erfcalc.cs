     using System;
     using static System.Math;
     using static System.Console;
     class main{
        static void Main(){
        Func <double,double> integrand = delegate(double t){return Exp(-t*t);};
        for (double x=-5; x<=5; x+=0.01){
        WriteLine($"{x} {integrate.quad(integrand,a:0,b:x)}");
        }
        }
    }