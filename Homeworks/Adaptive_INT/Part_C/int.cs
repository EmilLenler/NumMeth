using static System.Math;
using static System.Console;
using System;
public class integrator{
    //Open quadrature integrator.
    public static double integrate(Func<double, double> f, double a, double b, double delta = 0.001, double eps = 0.001,
    double f2 = Double.NaN, double f3= Double.NaN)
    {
        if(Double.IsNegativeInfinity(a) && Double.IsInfinity(b)){
            WriteLine("Entered integration with infinite a and infinite b");
            Func<double,double> Inf2Int = delegate(double t){return (f((1-t)/t)+f(-(1-t)/t))/(t*t);};
            double aprime = 0;
            double bprime = 1;
            return intCC(Inf2Int,aprime,bprime,delta,eps);
        }
        else if(Double.IsNegativeInfinity(a) && !Double.IsInfinity(b)){
            WriteLine("Entered integration with infinite a and finite b");
            double bprime = 1;
            double aprime = 0;
            Func<double,double> InfAInt = delegate(double t){return f(b-(1-t)/t)*1/(t*t);};
            return intCC(InfAInt,aprime,bprime,delta,eps);
        }
        else if(!Double.IsNegativeInfinity(a) && Double.IsInfinity(b)){
            WriteLine("Entered integration with finite a and infinite b");
            double bprime = 1;
            double aprime = 0;
            Func<double,double> InfBInt = delegate(double t){return f(a+(1-t)/t)*1/(t*t);};
            return intCC(InfBInt,aprime,bprime,delta,eps);
        }
        double h = b-a;
        if(Double.IsNaN(f2)){f2 = f(a+2*h/6); f3 = f(a+4*h/6);} // first call
        double f1 = f(a+h/6), f4 = f(a+5*h/6);
        double Q = (2*f1+f2+f3+2*f4)/6*(b-a); //Higher order
        double q = (f1+f2+f3+f4)/4*(b-a); // Lower order
        double err = Abs(Q-q);
        if(err<= delta+eps*Abs(Q)) return Q;
        else{; return integrate(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2)+integrate(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);}
    }
    public static double erf(double z)
    {
        Func<double, double> f = delegate(double x){return 2/Sqrt(PI)*Exp(-x*x);};
        return integrate(f,0,z);
    }
    public static double intCC(Func<double, double> f, double a, double b, double delta = 0.001, double eps = 0.001,
    double f2 = Double.NaN, double f3= Double.NaN)
    {
        Func<double,double> fCC = delegate(double theta){return f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;};
        return integrate(fCC,0,PI);
    }
}