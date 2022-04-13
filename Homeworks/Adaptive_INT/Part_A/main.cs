using static System.Math;
using static System.Console;
using System;
using System.IO;
public class main{
    public static void Main(){
        Func<double, double> f1 = delegate(double x){return Sqrt(x);};
        Func<double,double> f2 = delegate(double x){return 1.0/Sqrt(x);};
        Func<double,double> f3 = delegate(double x){return 4*Sqrt(1-x*x);};
        Func<double, double> f4 = delegate(double x){return Log(x)/Sqrt(x);};
        double a= 0;
        double b = 1;
        double int1 = integrator.integrate(f1,a,b);
        double int2 = integrator.integrate(f2,a,b);
        double int3 = integrator.integrate(f3,a,b);
        double int4= integrator.integrate(f4,a,b);
        WriteLine($"Functions to be integrated from 0 to 1 and their values:");
        WriteLine($"INT(sqrt(x)) = 2/3, INT(1/sqrt(x)) = 2, INT(4*sqrt(1-x^2)) = pi,  INT(ln(x)/sqrt(x)) = -4");
        WriteLine($"Calculated values {int1} {int2} {int3} {int4}");
        var writer = new StreamWriter("erfout.txt");
        for(int i = 0; i<=100; i++)
        {
            double z = i*10.0/100;
            writer.WriteLine($"{z} {integrator.erf(z)}");
        }
        writer.Close();
    }
}