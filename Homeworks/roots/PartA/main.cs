using static System.Console;
using static System.Math;
using System;
public class main{
    public static void Main(){
        Func<vector,vector> f =delegate(vector v){
            double f1 = v[0]*v[0]*v[1];
            double f2 = 5*v[0]+Sin(v[1]);
            vector res = new vector(f1,f2);
            return res;
        };
        vector x0 = new vector(1,1);
        matrix J = roots.Jacobi(x0,f);
        J.print("Jacobi for f1 = [x^2*y, 5x+sin(y)] at x0 = [1,1] is: ");
        vector guess1 = new vector(1,1);
        vector root1 = roots.Newton(f,guess1);
        root1.print("Root of f1 near the point x0 = [1,1] is: ");
        f(root1).print("f1 evaluated in this point is: ");
        Func<vector,vector> ff =delegate(vector v){
            double f1 = v[0];
            double f2 = 5*v[2];
            double f3 = 4*v[1]*v[1]-2*v[2];
            double f4 = v[2]*Sin(v[0]);
            vector res = new vector(f1,f2,f3,f4);
            return res;
        };
        vector x0_2 = new vector(1,1,1);
        matrix JJ = roots.Jacobi(x0_2,ff);
        JJ.print("Jacobi of function f2(x,y,z) = [x,5*z,4*y^2-2*z,z*sin(x)] evaluated at [x,y,z]=[1,1,1] is: ");
        vector root2 = roots.Newton(ff,x0_2);
        root2.print($"Root of f2 evaluated in the vicinity [1,1,1] is: ");
        ff(root2).print("f2 evaluated in this point is: ");
        Func<vector,vector> rosegrad = delegate(vector v){ //Gradient of Rosenbrock Function
            double f1 = 400*v[0]*v[0]*v[0]-400*v[0]*v[1]+2*v[0]-2;
            double f2 = 200*(v[1]-v[0]*v[0]);
            vector res = new vector(f1,f2);
            return res;
        };
        Func<vector,double> rose = delegate(vector v){//Rosenbrock Function, should have a global minimum in [1,1].
            double x = v[0];
            double y = v[1];
            return (1-x)*(1-x)+100*(y-x*x)*(y-x*x);            
        };
        vector guess3 = new vector(5,5);
        vector r3_1 = roots.Newton(rosegrad,guess3);
        r3_1.print("Rosenbrock function extremum found by searching in vicinity of [5,5]: ");
        WriteLine($"Rosenbruck function evaluated in this point is {rose(r3_1)} ");
    }
}