using static System.Math;
using System;
using static System.Console;
public class main{
    public static void Main(){
        Func<vector, double> f = delegate(vector v){return v[0]*v[0]*v[1]*v[1];}; //Returns x^2*y^2.
        vector a = new vector(-1,-1);
        vector b = new vector(1,1);
        int N = 1000000;
        WriteLine($"Number of points used for integration: {N}");
        double[] Int1 = MC.plainmc(f,a,b,N);
        WriteLine($"Integral of x^2*y^2 from [-1,-1] to [1,1] is {Int1[0]} should be 0.444... repeating. The estimated error is {Int1[1]}");
        Func<vector,double> f2 = delegate(vector v){return 1/(1-Cos(v[0])*Cos(v[1])*Cos(v[2]))/Pow(PI,3);};
        vector alpha = new vector(0,0,0);
        vector beta = new vector(PI,PI,PI);
        double[] Int2 = MC.plainmc(f2,alpha,beta,N);
        WriteLine($"Integral of 1/pi^3*1/(1-cos(x)*cos(y)*cos(z)) from [0,0,0] to [pi,pi,pi] is {Int2[0]} should be 1.392..  The estimated error is {Int2[1]}");
    
    
    }
}