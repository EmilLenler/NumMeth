using System;
public class hydrogen_solver{
    public static double vals(double e, double r,double rmin=1e-3){

    if(r<rmin) return r-r*r;
    Func<double,vector,vector> swave = (x,y)=>new vector(y[1], 2*(-1/x-e)*y[0]);
    vector yrmin = new vector(rmin-rmin*rmin, 1-2*rmin);
    vector yrmax = RK12.driver(swave,rmin,yrmin,r,acc:1e-3,eps:1e-3,h:1e-2);
    return yrmax[0];
    }
}