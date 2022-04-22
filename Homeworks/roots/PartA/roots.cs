using static System.Math;
using System;
using static System.Console;
public static class roots{
    public static matrix Jacobi(vector x, Func<vector,vector> f){
        vector deltax = new vector(x.size);
        double deltacoeff = Pow(2,-26);
        for(int i=0; i<x.size;i++){
            deltax[i] = x[i]*deltacoeff;
        }
        int n = f(x).size;
        int m = deltax.size;
        matrix J = new matrix(n,m);
        for(int i=0; i<n;i++){
            for(int k=0;k<m;k++){
                vector xnew = new vector(deltax.size);
                xnew[k] = deltax[k];
                vector xprime = x+xnew;
                vector df = f(xprime)-f(x);
                J[i,k] = df[i]/deltax[k];
            }
        }
        return J;
    }
    public static vector Newton(Func<vector,vector> f, vector x0, double eps = 1e-6){
        vector x = x0;
        WriteLine($"Finding roots with tolerance of {eps}");
        do{
            matrix J = Jacobi(x,f);
            QRGS JQ = new QRGS(J);
            vector delta = JQ.solve(-f(x));
            double lambda = 1;
            while(f(x+lambda*delta).norm()>(1/2-lambda/2)*f(x).norm() && lambda>1.0/32){
                lambda /=2;
            }
            x+=lambda*delta;
        }while(f(x).norm()>eps);
        return x;
    }
}