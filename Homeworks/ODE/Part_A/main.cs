using static System.Math;
using static System.Console;
using System;
using System.IO;

public class main{
    public static void Main(){
        double a = 0;
        vector ya = new vector(PI-0.1,0.0);
        ya.print("Initial values of [theta, omega]");
        Func<double,vector,vector> dydtdt = delegate(double dummy, vector y)
            {
            double omega = y[1];
            double theta = y[0];
            double y0= y[1];
            double bf =0.25;
            double cf = 5.0;
            double y1 = -bf*omega - cf*Sin(theta);
            vector yprime = new vector(y0,y1);
            return yprime;};
        var Writer = new StreamWriter("OutputFile.txt");
        for(int i =0;i<=100;i++){
            double b = i*1.0/10;
            vector sol = RK12.driver(dydtdt,a,ya,b);
            Writer.WriteLine($"{b} {sol[0]} {sol[1]}");
        }
        Writer.Close();
        //vector sol = RK12.driver(f,a,ya,b);
    }
}