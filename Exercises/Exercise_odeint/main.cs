using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
class main{
    public static void Main(){
        double b = 0.25;
        double c = 5.0;
        Func <double,vector,vector> oscillator = delegate(double t, vector y){
            double theta = y[0], omega = y[1];
            return new vector(omega, -b*omega-c*Sin(theta));
        };
        double start_t = 0;
        double end_t = 10;
        vector y_start = new vector(PI-0.1,0.1);
        var xlist = new List<double>();
        var ylist = new List<vector>();
        vector ystop = ode.ivp(oscillator,start_t,y_start,end_t,xlist,ylist);
        for(int i = 0; i<xlist.Count; i++){
            WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
        }

    }
}