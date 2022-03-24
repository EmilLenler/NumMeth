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
		vector c = Q.T*b;
		for(int i=m-1; i>=0; i--){
			double sum=0;
			for(int k=i+1; k<=c.size-1; k++){
				sum+=R[i,k]*c[k];
			}
			c[i]=(c[i]-sum)/R[i,i];
		}
		return c;
	}
	public matrix inverse(){
		//WriteLine("Entered Matrix Inversion...");
		matrix A= Q*R;
		int n = A.size1;
		matrix B = new matrix(n,n);
		for(int j= 0; j<n;j++){
			//Make unit vector and set j'th entry to zero.
			double[] units = new double[n];
			units[j]=1;
			vector unitvec= new vector(units);
			//WriteLine($"Writing unit vector no. {j}");
			unitvec.print();

			B[j]=solve(unitvec);
		}
		//WriteLine("...Exiting Matrix Inversion");
		return B;
	}

}
