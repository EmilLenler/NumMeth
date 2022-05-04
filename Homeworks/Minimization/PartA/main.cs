using System;
using static System.Math;
using static System.Console;

public class main{
    public static void Main(){
        Func<vector, double> RosBrock = delegate(vector v){
            double x= v[0];
            double y=v[1];
            double res = (1-x)*(1-x)+100*(y-x*x)*(y-x*x);
            return res;
        };
        vector xstart = new vector(1.1,1.1);
        vector oneone = new vector(1,1);
        vector V1 = minimization.qnewton(RosBrock,xstart);
        V1.print($"Minimum for Rosenbrock Function (1-x)^2+100*(y-x^2)^2 is: ");
        WriteLine($"Rosenbrock function evaluated in this point is {RosBrock(V1)}");

    }
    
}