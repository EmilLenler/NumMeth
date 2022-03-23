using static System.Math;
using static System.Console;
using System.IO;
using System;
public static class fit{
public static vector fitter(Func<double,double>[] fs, matrix Data){
    matrix A = new matrix(Data.size2,Data.size1-1);
    for(int i=0; i<A.size1; i++){
        for(int j=0; j<A.size2; j++){
            A[i,j]=Data[j,i];
        }
    }
    A.print("A =");
    //Now construct the matrix without uncertainties by applying functions
    matrix U = new matrix(A.size1,A.size2);
    for(int i =0; i<A.size1; i++){
        for(int j=0; j<A.size2; j++){
            U[i,j] = fs[j](A[i,0]);
        }
    }
    QRGS QR = new QRGS(U);
    double[] bs = new double[A.size1];
    for(int i=0; i<A.size1; i++){
        bs[i] = A[i,1];
    }
    vector b = new vector(bs);
    vector c = QR.solve(b);
    vector debug = new vector(0);
    return c;
}
}