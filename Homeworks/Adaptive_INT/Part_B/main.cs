using static System.Math;
using static System.Console;
using System;
using System.IO;
public class main{
    public static void Main(){
        int i = 0; int j = 0; int n = 0; int m = 0;
        Func<double, double> f1 = delegate(double x){
            i++;
            return 1.0/Sqrt(x);};
        Func<double, double> f12 = delegate(double x){
        j++;
        return 1.0/Sqrt(x);};
        //Func<double, double> f2 = delegate(double x){return Log(x)/Sqrt(x);};
        Func<double, double> f2 = delegate(double x){
            n++;
            return Log(x)/Sqrt(x);
        };
        Func<double,double> f22= delegate(double x){
            m++;
            return Log(x)/Sqrt(x);
        };
        double a= 0;
        double b = 1;
        double int1 = integrator.intCC(f1,a,b);
        double int12 = integrator.integrate(f12,a,b);
        double int2 = integrator.intCC(f2,a,b);
        double int22= integrator.integrate(f22,a,b);
        //double int2 = integrator.intCC(f2,a,b);
        WriteLine($"Functions to be integrated from 0 to 1 and their values:");
        WriteLine($"INT(1/sqrt(x)) = 2, INT(ln(x)/sqrt(x)) = -4");
        WriteLine($"First integral gives values {int1} and {int12} with {i} and {j} evaluations for transformed and untransformed integrals respectively");
        WriteLine($"Second integral gives values {int2} and {int22} with {n} and {m} evaluations for transformed and untransformed integrals respectively");
    }
}