using static System.Math;
using System;
using static System.Console;
public class QRGS{
    public matrix Q,R;
    public QRGS(matrix A){
    //Here comes Gram Schmidt
	int size1=A.size1;
	int size2=A.size2;
	Q=A.copy();
	//WriteLine(1);
	R=new matrix(size2,size2);
	//WriteLine(2);
	for(int i=0;i<size2;i++){
		R[i,i]=Q[i].norm();
		Q[i]/=R[i,i];
		//WriteLine($"{i}");
		for(int j =i+1; j<size2; j++){
			R[i,j]=Q[i].dot(Q[j]);
			Q[j]-=Q[i]*R[i,j];
			//WriteLine($"{j}");
		}
		}
	}
	public vector solve(vector b){
		int m= R.size1;
		double[] ys =new double[m];
		vector to_solve = Q.T*b;
		for(int i=m-1; i>=0; i--){
			double sum=0;
			for(int k=i+1; k<=to_solve.size-1; k++){
				sum+=R[i,k]*ys[k];
			}
			ys[i]=(to_solve[i]-sum)/R[i,i];
		}
		vector a = new vector(ys);
		return a;
	}
}
