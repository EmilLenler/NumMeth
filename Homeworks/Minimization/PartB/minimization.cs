using System;
using static System.Math;
using static System.Console;

public static class minimization{
    public static (vector,int) qnewton(Func<vector,double> f, vector xstart,double eps = 1e-6, double alpha=1e-4,double eps_vec = 1e-2){
    matrix B = matrix.id(xstart.size);
    vector x = xstart.copy();
    vector gradient_x =grad(f,xstart);
    int nsteps = 0;
    while(nsteps<999999){
        nsteps++;
        vector dx =-B*gradient_x;
        //dx.print("dx is "); //DEBUG LINE
        if(dx.norm()<Pow(2,-26)){break;}; //Stop looping if step taken is too small.
        if(gradient_x.norm()<eps){break;} // Stop looping if gradient is already very low. 
        double lambda = 1;
        vector s;
        while(true){
            s = dx*lambda;
            double fnew = f(x+s);
            if(fnew<f(x)){break;} //Moving correct way!
            if(lambda<Pow(2,-26)){ //Lambda got too small.
                B.setid();
                break;}
                lambda/=2; // Divide lambda by 2 to try with smaller step.
            }//end of while(true)
        vector grad_new = grad(f,x+s);
        vector y =grad_new-gradient_x;
        vector u = s-B*y;
        double udoty = u.dot(y);

        if(Abs(udoty)>1e-6){B.update(u,u,1/udoty);};//Update B so long as we do not risk division with small number udoty.
        x+=s;
        gradient_x = grad_new;
        }
        if(nsteps == 999999){WriteLine($"WARNING: MAXIMUM NUMBER OF STEPS USED. CONVERGENCE NOT GUARANTEED.");}
        return(x,nsteps);
        }//end of qnewton
    public static vector grad(Func<vector,double> f, vector x){
    vector deltax = x*Pow(2,-26);
    //Construct gradient
    vector grad = new vector(x.size);
    for(int i=0; i<x.size; i++){
        vector xnew = new vector(x.size);
            if(Abs(deltax[i])<Pow(2,-26)) deltax[i]=Pow(2,-26);
            xnew[i] = deltax[i];
            //xnew.print($"xnew is"); //DEBUG LINE
            vector xprime = x+xnew;
            double df = f(xprime)-f(x);
            grad[i] = df/deltax[i];
        }
        //grad.print($"Gradient of f(x) at {x[0]}, {x[1]} is:"); //DEBUG LINE
        return grad;
    }

}