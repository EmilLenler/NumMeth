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
    public static double corput(int n,int bas){
        double q = 0;
        double bk = 1.0/bas;
        while(n>0){
            q+=(n % bas)*bk;
            n/=bas;
            bk/=bas;
        }
            return q;
        }
    public static double[] haltonseq(int n, int dim, int offset = 0){
        int[] bas = {2,3,5,7,11,13,17,19,23,29,31,37,41,47,53,59,61,67};
        if(dim>bas.Length) throw new System.Exception("Dimension is too high!");

        double[] seq = new double[dim];
        for(int i=0; i<dim; i++){
            seq[i] = corput(n,bas[(i+offset)%bas.Length]);
        }
        return seq;
    }
    public static double[] quasimc(Func<vector,double> f, vector a, vector b, int N)
    {int dim = a.size; double V = 1; for(int i=0; i<dim;i++)V*=b[i]-a[i];
    double sum = 0,sum2=0;
    vector x = new vector(dim);
    vector xerrcheck = new vector(dim);
    for(int i =0; i<N; i++){
        double[] Halton = haltonseq(i,dim);
        double[] HaltonErrcheck =haltonseq(i,dim,6); //Set an offset for the choice of base in the halton sequenece.
        for(int k=0; k<dim;k++){
            x[k]=a[k]+Halton[k]*(b[k]-a[k]);
            xerrcheck[k]= a[k]+HaltonErrcheck[k]*(b[k]-a[k]);
        }
        double fx=f(x); 
        double fxerrcheck = f(xerrcheck);
        sum+=fx;
        sum2+=fxerrcheck;
    }
    double mean = sum/N, mean2=sum2/N;
    double[] result = new double[] {mean*V,Abs(mean*V-mean2*V)};
    return result;
    }


}