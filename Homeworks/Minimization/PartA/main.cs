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
        vector xstart = new vector(1.5,0.5);
        xstart.print($"Starting point for guessing minimum of Rosenbrock function is:");
        var (V1,steps1) = minimization.qnewton(RosBrock,xstart);
        V1.print($"Minimum of Rosenbrock function is found in point:");
        WriteLine($"Value of Rosenbrock function in this point is {RosBrock(V1)}");
        WriteLine($"Took {steps1} steps to find minimum of Rosenbrock fct.");
        Func<vector,double> Himmel = delegate(vector v){
            double x =v[0];
            double y= v[1];
            return Pow(x*x+y-11,2)+Pow(x+y*y-7,2);
        };
        vector Himmel1 = new vector(3.5,1.5);
        vector Himmel2 = new vector(-3,4);
        vector Himmel3 = new vector(-3.5,-4);
        vector Himmel4 = new vector(3,-1);
        var (H1,stepsH1) =minimization.qnewton(Himmel,Himmel1);
        var (H2,stepsH2) = minimization.qnewton(Himmel,Himmel2);
        var (H3,stepsH3) = minimization.qnewton(Himmel,Himmel3);
        var (H4,stepsH4) = minimization.qnewton(Himmel,Himmel4);
        H1.print("Found first minimum H1 of Himmelblau fct in: ");
        H2.print("Found second minimum H2 of Himmelblau fct in: ");
        H3.print("Found third minimum H3 of Himmelblau fct in: ");
        H4.print("Found fourth minimum H4 of Himmelblau fct in: ");
        WriteLine($"Himmelblau function evaluated in these points respectively is: {Himmel(H1)} {Himmel(H2)} {Himmel(H3)} {Himmel(H4)}");
        WriteLine($"Finding each minimum took respective numbers of steps: {stepsH1} {stepsH2} {stepsH3} {stepsH4}");
        Himmel1.print($"Guess for H1 was: ");
        Himmel2.print($"Guess for H2 was: ");
        Himmel3.print($"Guess for H3 was: ");
        Himmel4.print($"Guess for H4 was: ");
    }
    
}