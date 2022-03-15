using System;
using static System.Math;
using System.Linq;
using static System.Console;
public class qspline{
        public double[] x,y,b,c;
    public qspline(double[] xs, double[] ys){
        x = xs;
        y = ys;
        c[0]=0.0;
        double[] p = new double[x.Length-1];
        double[] dx = new double[x.Length-1];
        for(int i = 0; i<=x.Length-1; i++){
            dx[i] = x[i+1]-x[i];
            p[i] = (y[i+1]-y[i])/dx[i];
        }
        for(int i = 0; i<=x.Length-1; i++){
            c[i+1]=1/dx[i+1]*(p[i+1]-p[i]-c[i]*dx[i]);
        }
        for(int i = 0; i<=x.Length-1; i++){
            b[i]=p[i]-c[i]*dx[i];
        }
    }

}
