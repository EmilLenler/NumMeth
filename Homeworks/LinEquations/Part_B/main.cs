using static System.Math;
using static System.Console;
using System;

public class main{
    public static void Main(){
        int n = 6;
        matrix A = new matrix(n,n);
        Random rnd = new Random();
        for(int j=0; j<A.size1; j++){
            for(int i =0; i<A.size2; i++){
                A[j,i] = rnd.Next(1,11); //Make random matrix with values in range [1,10].
            }
        }
        A.print($"A is :");
        QRGS QR = new QRGS(A);
        matrix B = QR.inverse();
        B.print("inverse of A is:");
        matrix I_check1 = B*A;
        matrix I_check2 = A*B;
        matrix Identity = matrix.id(6);
        I_check1.print("Is B*A=I?");
        WriteLine($"{I_check1.approx(Identity)}");
        I_check2.print("Is A*B=I?");
        WriteLine($"{I_check2.approx(Identity)}");

    }
    
}