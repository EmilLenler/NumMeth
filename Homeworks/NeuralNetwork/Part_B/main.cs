using static System.Math;
using System;
using static System.Console;
using System.IO;

public static class main{
    public static void Main(){
        Func<double,double> activation = delegate(double x){
            return x*Exp(-x*x);
        };
        Func<double, double> model = delegate(double x){
            return Cos(5*x-1)*Exp(-x*x);
        };
        Func<double,double> dfdx = delegate(double x){
            return Exp(-x*x)*(-5*Sin(5*x-1)-2*x*Cos(5*x-1));
        };
        int number_neurons = 3;
        var ann = new ANN(number_neurons,activation);
        int npoints = 100;
        double a = -1;
        double b = 1;
        double[] xs = new double[npoints];
        double[] ys = new double[npoints];
        for(int i = 0; i<npoints; i++){
            xs[i] = a+(b-a)*i/(npoints-1);
            ys[i] = model(xs[i]);
            WriteLine($"{xs[i]} {ys[i]}");
        }
        vector xs_v = new vector(xs);
        vector ys_v = new vector(ys);
        for(int i = 0; i<ann.n; i++){
            ann.p[3*i]=a+(b-a)*i/(ann.n-1);
            ann.p[3*i+1]=1;
            ann.p[3*i+2]=1;
        }
        ann.train(xs_v,ys_v);
        ann.p.print($"final parameters after training are:");
        var interp= new StreamWriter("Interpolated_DATA.txt");
        for(double z =a; z<b; z+=1.0/64){
            interp.WriteLine($"{z} {ann.response(z)} {dfdx(z)} {ann.GWavelet_Derivative(z)} {ann.GWavelet_Integral(z)} ");
        }
        interp.Close();
    }
}