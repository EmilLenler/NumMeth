using static System.Math;

public class TJSVD{
    public matrix U;
    public matrix V;
    public matrix D;
    public double sweeps;
    //Multiply from right with jacobian in order O(n)
    public static void timesJ(matrix A, int p, int q, double theta){
        double c=Cos(theta); double s=Sin(theta);
        for(int i=0; i<A.size1; i++){
            double aip =A[i,p]; double aiq=A[i,q];
            A[i,p]=c*aip-s*aiq;
            A[i,q]=s*aip+c*aiq;
        }
    }
    //Multiply from left with jacobian in order O(n)
    public static void Jtimes(matrix A, int p, int q, double theta){
        double c=Cos(theta); double s=Sin(theta);
        for(int j=0; j<A.size1; j++){
            double apj = A[p,j]; double aqj = A[q,j];
            A[p,j]=c*apj+s*aqj;
            A[q,j]=-s*apj+c*aqj;
        }
    }
    public TJSVD(matrix A){
        int n = A.size1;
        //Create V and U, both as identity matrices initially
        V = matrix.id(n);
        U = matrix.id(n);
        sweeps = 0;
        bool changed;
        D=A.copy();
        do{
            sweeps ++;
            changed = false;
            //Loop over upper triangle!
            for(int p =0;p<n-1;p++){
                for(int q = p+1;q<n;q++){
            //Store values of App and Apq etc. for comparison.
            double o_apq=matrix.get(D,p,q);
            double o_aqq=matrix.get(D,q,q);
            double o_app=matrix.get(D,p,p);
            double o_aqp=matrix.get(D,q,p);

            double apq = o_apq;
            double aqp = o_aqp;
            double app = o_app;
            double aqq= o_aqq;            
            //Calculate Givens angle;
            double theta_givens = Atan2(apq-aqp,app+aqq);
            //Symmetrize off-diagonal
            Jtimes(D,p,q,-theta_givens);
            
            apq=matrix.get(D,p,q);
            app=matrix.get(D,p,p);
            aqq=matrix.get(D,q,q);
            //Eliminate off_diag.
            double theta_jacobi = 0.5*Atan2(2*apq,aqq-app);
            timesJ(D,p,q,theta_jacobi);
            Jtimes(D,p,q,-theta_jacobi);

            //Update U and V!
            timesJ(V,p,q,theta_jacobi);
            timesJ(U,p,q,theta_givens);
            timesJ(U,p,q,theta_jacobi);
            //Diagonal elements not allowed to change:
            double new_app=matrix.get(D,p,p);
            double new_aqq=matrix.get(D,q,q);
            if(o_app!=new_app || o_aqq!=new_aqq){
            changed = true;
            }

        }
        }
    }while(changed);
    //Check for negative diagonal elements. Fix if necessary
    for(int i =0; i<n; i++){
        double diag =matrix.get(D,i,i);
        if(diag<0){
            for(int j =0; j<n;j++){
                U[j,i]*=-1;
            }
        D[i,i]*=-1;
        }
    }
}
}