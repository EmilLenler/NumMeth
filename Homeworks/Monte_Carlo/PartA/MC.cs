using System;
using static System.Math;
using static System.Console;
public class MC{
    public static double[] plainmc(Func<vector,double> f, vector a, vector b, int N)
    {int dim = a.size; double V = 1; for(int i=0; i<dim;i++)V*=b[i]-a[i];
    double sum = 0,sum2=0;
    vector x = new vector(dim);
    Random rnd01 = new Random();
    for(int i =0; i<N; i++){
        for(int k=0; k<dim;k++)x[k]=a[k]+rnd01.NextDouble()*(b[k]-a[k]);
        double fx=f(x); sum+=fx; sum2+=fx*fx;
    }
    double mean = sum/N, sigma = Sqrt(sum2/N-mean*mean);
    double[] result = new double[] {mean*V,sigma*V/Sqrt(N)};
    return result;
    } 
}