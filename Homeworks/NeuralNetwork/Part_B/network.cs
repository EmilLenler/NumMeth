using System;
using static System.Math;
public class ANN{
    public int n; //No. of neurons
    public Func<double, double> f ; //Activation fct.
    public vector p; //Network Parameters
    public ANN(int n_neuron, Func<double, double> f_activation){//Constructor!
        this.n = n_neuron;
        this.f = f_activation;
        this.p = new vector(3*n);
    }
    public double response(double x){//Response of network to input
        double sum = 0;
        for(int i = 0; i<n; i++){
            //"Encode" parameter vector on form (a1,b1,w1,a2,b2,w2,a3,...)
            double ai = p[3*i];
            double bi = p[3*i+1];
            double wi = p[3*i+2];
            
            sum+=f((x-ai)/bi)*wi;
        }
        return sum;
    }
    public void train(vector x, vector y){//Train the network using table of inputs (x,y)
        Func<vector, double> cost = delegate(vector u){
            double sum=0;
            p = u;
            for(int j = 0; j<x.size; j++){
                sum+=(response(x[j])-y[j])*(response(x[j])-y[j]);
            }
            return sum;
        };
        var (res,nsteps) = minimization.qnewton(cost,p);
        p = res;

    }
    public double GWavelet_Derivative(double x){
        double sum =0;
        Func<double,double> GWave_Derivative = delegate(double y){
            return Exp(-y*y)*(1-2*y*y);
        };
        for(int i = 0; i<n; i++){
            double ai=p[3*i];
            double bi=p[3*i+1];
            double wi=p[3*i+2];

            sum+=1/bi *GWave_Derivative((x-ai)/bi)*wi;
        }
        return sum;
    }
    public double GWavelet_Integral(double x){
        Func<double,double> GWave_Int = delegate(double y){
            return -Exp(-y*y)/2;
        };
        double sum = 0;
        for(int i = 0; i<n; i++){
        double ai=p[3*i];
        double bi = p[3*i+1];
        double wi = p[3*i+2];
        sum+=bi*GWave_Int((x-ai)/bi)*wi;
        }
        return sum;
    }
}