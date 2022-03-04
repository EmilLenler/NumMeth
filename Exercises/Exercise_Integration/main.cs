using static System.Math;
using static System.Console;
using System;
class main{
    public static void Main(){
        WriteLine("Integral of ln(x)/sqrt(x) from 0 to 1 is");
        Func<double,double> f = delegate(double x){return Log(x)/Sqrt(x);};
        double Result = integrate.quad(f,a:0,b:1,acc:1e-6,eps:1e-6);
        WriteLine($"{Result}");
    }
}