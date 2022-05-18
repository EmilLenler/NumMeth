using static System.Math;
using static System.Console;
using System;
using System.IO;

public class main{
    public static void Main(){
        double a = 0;
        vector ya = new vector(PI-0.1,0.0);
        ya.print("Initial values oscilattor are [theta, omega]");
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
        Func<double,vector,vector> harmonic =delegate(double dummy, vector y)
        {
            double y0 = y[1]; //This is u
            double y1 = -y[0]; //This is u'
            vector yprime = new vector(y0,y1);
            return yprime;
        };
        var Writer1 = new StreamWriter("OutputFile1.txt");
        for(int i =0;i<=100;i++){
            double b = i*1.0/10;
            vector sol = RK12.driver(dydtdt,a,ya,b);
            Writer1.WriteLine($"{b} {sol[0]} {sol[1]}");
        }
        Writer1.Close();
        var Writer2 = new StreamWriter("OutputFile2.txt");
        vector ya2 = new vector(0,1);
        for(int i = 0; i<=100; i++){
            double t = i*2*PI/100;
            vector sol = RK12.driver(harmonic,a,ya2,t);
            Writer2.WriteLine($"{t} {sol[0]} {sol[1]}");
        }
        Writer2.Close();
        ya2.print("Initial values of u'' = -u are set to [u,du/dt] (0,1) should produce cosine.");
        //vector sol = RK12.driver(f,a,ya,b);
    }
}