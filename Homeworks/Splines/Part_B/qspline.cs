using System;
using static System.Math;
using System.Linq;
using static System.Console;
public class qspline{
        public double[] x,y,b,c;
    //Generate spline coefficients as defined in note on splines.
    public qspline(double[] xs, double[] ys){
        x = xs;
        y = ys;
	int n=xs.Length;
        double[] p = new double[n-1];
        double[] dx = new double[n-1];
        b = new double[n-1];
        c = new double[n-1];
        double[] cup = new double[n-1];
        double[] cdown = new double[n-1];
        cup[0]=0.0;
        for(int i = 0; i<x.Length-1; i++){
            dx[i] = x[i+1]-x[i];
            p[i] = (y[i+1]-y[i])/dx[i];
        }
        for(int i = 0; i<n-2; i++){
            cup[i+1]=1/dx[i+1]*(p[i+1]-p[i]-c[i]*dx[i]);
        }
        cdown[n-2] = 0;
        for(int i=n-3; i>=0; i--){
                cdown[i] = 1/dx[i]*(p[i+1]-p[i]-c[i+1]*dx[i+1]);
        }
        for(int i = 0; i<n-1; i++){
                c[i]=(cdown[i]+cup[i])/2;
        }
        for(int i = 0; i<n-1; i++){
            b[i]=p[i]-c[i]*dx[i];
        }
    }
    //Define binsearch needed for finding the correct intervals.
    public static int binsearch(double[] x, double z)
    {
    if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch:  bad z");
    int i=0, j=x.Length-1;
    while(j-i>1)
        {
        int mid=(i+j)/2;
        if(z>x[mid]) i =mid; else   j=mid;
        }
    return i;
    }
    //Evaluate the spline in some point z.
    public double spline(double z){
            int i = binsearch(x,z);
            return y[i]+b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2);
    }
    //Evaluate the derivative of the spline in some point z.
    public double derivative(double z){
            int i = binsearch(x,z);
            return b[i]+2*c[i]*(z-x[i]);
    }
    public double integrator(double z){
            int i = binsearch(x,z);
            double sum = 0;
            double[] dx =new double[x.Length-1];
            for(int j = 0; j<i;){
                dx[j] = x[j+1]-x[j];
                double part_int = dx[j]*y[j]+b[j]*0.5*Pow(dx[j],2)+1.0/3*c[j]*Pow(dx[j],3);
                sum+=part_int;
                }
            return sum+y[i]*(z-x[i])+0.5*b[i]*Pow(z-x[i],2)+1.0/3*c[i]*Pow(z-x[i],3);
    }
}
