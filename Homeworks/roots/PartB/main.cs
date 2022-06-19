using System;
using static System.Console;
using static System.Math;
public static class main{
    public static void Main(){
        double rmax = 8;
        Func<vector,vector> dfdtdt = delegate(vector v){
            double e = v[0];
            double frmax = hydrogen_solver.vals(e,rmax);
            return new vector(frmax);
        };
        vector start = new vector(-1.0);
        vector root = roots.Newton(dfdtdt,start,eps:1e-4);
        double energy = root[0];
        WriteLine($"# Energy is {energy}");
        WriteLine($"# r, ODE solution, Real Solution, ODE/Real");
        for(double r = 0; r<=rmax; r+=rmax/64){
            WriteLine($"{r} {hydrogen_solver.vals(energy,r)} {r*Exp(-r)} {hydrogen_solver.vals(energy,r)/(r*Exp(-r))}");
        }
    }
}