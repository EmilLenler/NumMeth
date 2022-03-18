using System;
using static System.Math;
using System.Linq;
using static System.Console;
using System.IO;
public class main{
    public static void Main(){
        double[] xlist =new double[] {1,2,3,4,5};
        double[] ylist1 =new double[] {1,1,1,1,1};
        double[] ylist2 = new double[] {1,2,3,4,5};
        double[] ylist3 = new double[] {1,4,9,16,25};
        qspline spline1 = new qspline(xlist,ylist1);
        qspline spline2 = new qspline(xlist,ylist2);
        qspline spline3 = new qspline(xlist,ylist3);
        double xnum =1;
        while(xnum<=5){
            WriteLine($"{xnum} {spline1.spline(xnum)} {spline2.spline(xnum)} {spline3.spline(xnum)}");
            xnum+=0.1;
        }
        var tablenums = new StreamWriter("TableVals.txt");
        for(int i=0; i<=xlist.Length-1; i++){
            tablenums.WriteLine($"{xlist[i]} {ylist1[i]} {ylist2[i]}  {ylist3[i]}");
        }
        tablenums.Close();
        var splineDeriv = new StreamWriter("SplineDeriv.txt");
        double x2 = 1.0;
        while(x2<=5){
            splineDeriv.WriteLine($"{x2} {spline1.derivative(x2)} {spline2.derivative(x2)} {spline3.derivative(x2)}");
            x2+=0.1;
        }
        splineDeriv.Close();
        //Analytical values for the derivatives of the three functions y = 1, y = x and y = x^2
        
        var DeriVals = new StreamWriter("AnaDerivs.txt");
        for(int i = 0; i<=xlist.Length-1; i++){
            DeriVals.WriteLine($"{xlist[i]} {0} {1} {2*xlist[i]}");
        }
        DeriVals.Close();

        //StreamWriter Splineint = new StreamWriter("SplineInt.txt");
        for(double j = 1.0; j<5.0; j+=0.1){
            WriteLine($"{j} {spline1.integrator(j)}");
        }
        //Splineint.Close();
    }
}