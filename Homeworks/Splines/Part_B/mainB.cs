using System;
using static System.Math;
using System.Linq;
using static System.Console;

public class main{
    public static void Main(){
        double[] xlist =new double[] {-3,-2,-1,0,1,2,3};
        double[] ylist =new double[] {-3,-2,-1,0,1,2,3};
        qspline spline1 = new qspline(xlist,ylist);
        //for(int i = 0; i<=spline1.c.Length-1;i++)
        //WriteLine($"{spline1.c[i]} {spline1.b[i]}");
    }
}