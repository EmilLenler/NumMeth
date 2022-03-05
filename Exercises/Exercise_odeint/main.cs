using System;
using static System.Console;
using static System.Math;
class main{

    public static double DiffEq(double x){
        Func<double,vector,vector> F = delegate(double t, vector y){
        double dydt0 = y[1];
        double dydt1 = -0.25*y[1]-5.0*Sin(y[0]);
        return new vector(dydt0,dydt1);
        };

        double a=0;
        double b=x;
        vector ya = new vector(0,PI-0.1);
        var xlist = new List<double>();
        var ylist = new List<vector>();
        vector result = ode.ivp(F,a,ya,b,xlist,ylist);
        return result;
        }
public static void Main(){
    WriteLine($"{PI/2} {DiffEq(PI/2)}");
}
}