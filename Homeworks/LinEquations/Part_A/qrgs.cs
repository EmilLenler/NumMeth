using static System.Math;
using System;
using static System.Console;
public class QRGS{
    public matrix Q,R;
    public QRGS(matrix A){
        //Here comes Gram Schmidt
        //Set 1st column 
	int size1=A.size1;
	int size2=A.size2;
	double sum;
	Q = new matrix(size1,size2);
	R = new matrix(size2,size2);
	for(int i=0;i<size1;i++){
		sum=0;
		for(int k=0;k<size1;k++)sum+=Pow(A[k,i],2);
		R[i,i]=Sqrt(sum);
		for(int k=0;k<size1;k++)Q[k,i]=A[k,i]/R[i,i];
		for(int j=i+1;j<size2;j++){
			sum=0;	
			for(int k=0;k<size1;k++)sum+=Q[k,i]*A[k,j];
			R[i,j]=sum;
			for(int k=0;k<size1;k++)A[k,j]-=Q[k,i]*R[i,j];
		}
	}
    }
}
