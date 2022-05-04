using System;
using static System.Math;
using static System.Console;

public static class minimization{
    public static vector qnewton(Func<vector,double> f, vector xstart,double eps = 1e-2, double alpha=1e-4,double eps_vec = 1e-2){
    matrix B = matrix.id(xstart.size);
    vector x = xstart;
    do{
        vector dx =-B*grad(f,x);
        dx.print("dx is ");
        double lambda = 1.0;
        vector s = lambda*dx;
        while(f(x+s)>f(x)+alpha*s%grad(f,x) && lambda >1.0/32){
            lambda/=2;
            WriteLine($"Lambda = {lambda}");
            s = lambda*dx;
        }
        s.print($"Updating x with s = ");
        x+=s;
        x.print($" x = ");
        if(lambda>1.0/32){
            vector y = grad(f,x+s);
            vector u = s-B*y;
            if(Abs(u%y)>eps_vec){
            WriteLine($"u dot y is non-zero");
            B.update(u,u,1.0/(u%y));
            WriteLine($"Updating B");
            B.print($" B = ");
            }
        }
        else{
            B = matrix.id(xstart.size);
            WriteLine($"Resetting B");

        }
    }while(grad(f,x).norm()>eps);
    return x;
    }
    public static vector grad(Func<vector,double> f, vector x){
    vector deltax = x*Pow(2,-26);
    //Construct gradient
    vector grad = new vector(x.size);
    for(int i=0; i<x.size; i++){
        vector xnew = new vector(x.size);
            xnew[i] = deltax[i];
            xnew.print($"xnew is");
            vector xprime = x+xnew;
            double df = f(xprime)-f(x);
            grad[i] = df/deltax[i];
        }
        grad.print($"Gradient of f(x) at {x[0]}, {x[1]} is:");
        return grad;
    }

}