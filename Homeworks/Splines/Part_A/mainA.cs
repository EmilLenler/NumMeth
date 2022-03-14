using static System.Math;
using static System.Console;
using System;
using System.IO;
using System.Linq;
public class LinSpline{
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
    public static double linterp(double[] x, double[] y, double z)
    {
        int i=binsearch(x,z);
        double dx =x[i+1]-x[i]; if(!(dx>0)) throw new Exception("linterp: dx negative");
        double dy = y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
    }
    public static double linInt(double[] x, double[] y, double z)
    {
        int i = binsearch(x,z);
        double[] IntSum = new double [x.Length-1];
        double dx =x[i+1]-x[i]; if (!(dx>0)) throw new Exception("Bad integral, dx negative");
        double dy =y[i+1]-y[i];
        for(int j=0;j<i;j++){
            IntSum [j] =y[j]*(x[j+1]-x[j])+1.0/2*(y[j+1]-y[j])*(x[j+1]-x[j]);
        }
        double Sum = IntSum.Sum();
        return Sum + y[i]*(z-x[i])+1.0/2*dy/dx*(z-x[i]);
    }
    public static void Main()
    {
        double[] xlist = {0,1,2,3,4,5};
        double[] ylist1 = {1,1,1,1,1,1};
        double[] ylistx = {0,1,2,3,4,5};
        double[] ylistxsq ={0,1,4,9,16,25};
        for(double x=0; x<=5; x+=0.1){
            WriteLine($"{x} {linterp(xlist,ylist1,x)} {linterp(xlist,ylistx,x)} {linterp(xlist,ylistxsq,x)}");
        }
        var tablenums = new StreamWriter("TableVals.txt");
        for(int i=0; i<=xlist.Length-1; i++){
            tablenums.WriteLine($"{xlist[i]} {ylist1[i]} {ylistx[i]}  {ylistxsq[i]}");
        }
        tablenums.Close();
        var integralnums = new StreamWriter("IntVals.txt");
        for(double x=0; x<=5; x+=0.1){
            integralnums.WriteLine($"{x} {linInt(xlist,ylist1,x)} {linInt(xlist,ylistx,x)} {linInt(xlist,ylistxsq,x)}");
        }
        integralnums.Close();

    }
}