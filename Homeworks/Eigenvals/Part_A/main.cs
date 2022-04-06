using System;
using static System.Math;
using System.IO;
using static System.Console;

public class main{
    public static void Main(){
        int n = 5;
        matrix V = new matrix(n,n);
        for(int i=0; i<n; i++){
            V[i,i]=1;
        }
        Random rnd = new Random();
        matrix A = new matrix(n,n);
        for(int p=0; p<n;p++)
        for(int q=p; q<n; q++){
            A[p,q]=rnd.Next(1,30);
            A[q,p]=A[p,q];
        }
        A.print("Symmetric matrix A is");
        matrix D = A.copy();
        diagonalization.JacobiDiag(D,V);
        D.print("D should be diagonalized:");
        var check1 = V.T*A*V;
        var check2 = V*D*V.T;
        var check3 = V.T*V;
        var check4 = V*V.T;
        check1.print($"V.T*A*V = ");
        WriteLine($"Is V.T*A*V = D? {check1.approx(D)}");
        check2.print($"V*D*V.T = (Should be A)");
        WriteLine($"Is V*D*V.T = A? {check2.approx(A)}");
        check3.print($"V.T*V = (Should be Id)");
        check4.print($"V*V.T = (Should be Id)");
    }
}