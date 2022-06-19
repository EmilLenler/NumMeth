using static System.Math;
using static System.Console;
using System.Diagnostics;
using System;
using System.IO;
public class exam{
    public static void Main(){
        //Create random square n x n matrix, values are ints between 1 and 30.
        int n = 5;
        matrix A = new matrix(n,n);
        Random rnd = new Random();
        for(int i=0;i<A.size1;i++){
            for(int j=0;j<A.size2;j++){
                A[i,j]=(rnd.NextDouble()-0.5)*60;// Random number magic here. Generate number between 0 and 1 randoly. Subtract 0.5 to allow for negative numbers
                //Multiply by 60 to get range of -30 to 30.
            }
        }
        WriteLine($"Emil Lenler-Eriksen. Student ID: 201708315");
        WriteLine($"15 mod 23 = 15");
        A.print("Randomly generated matrix A is:");

        TJSVD SVD = new TJSVD(A);
        WriteLine($"Performed two-sided Jacobi algorithm in {SVD.sweeps} sweeps on matrix A of size {A.size1}.");
        matrix prod = SVD.U*SVD.D*SVD.V.T;
        prod.print($"Is U*D*V^T = A?");
        WriteLine($"{A.approx(prod)}");
        SVD.D.print($"Diagonalized matrix is:");
        SVD.U.print($"U is ");
        SVD.V.print($"V is ");
        matrix U_Ort = SVD.U*SVD.U.T;
        matrix V_Ort = SVD.V*SVD.V.T;
        U_Ort.print($"Check for orthogonality of U. U*U^T = ");
        V_Ort.print($"Check for orthogonality of V. V*V^T = ");

        //Performing time testing for larger and larger matrices.
        int N_tests = 25;
        var watch = new Stopwatch();
        var writer = new StreamWriter("TimeData.txt");
        for(int i = 1; i<=N_tests; i++){
        int matsize = 10*i;
        matrix A_test = new matrix(matsize,matsize);
        Random rnd_test = new Random();
        for(int m=0;m<A.size1;m++){
            for(int j=0;j<A.size2;j++){
                A_test[m,j]=(rnd.NextDouble()-0.5)*60;// Random number magic here. Generate number between 0 and 1 randoly. Subtract 0.5 to allow for negative numbers
                //Multiply by 60 to get range of -30 to 30.
            }
        }
        watch.Restart();
        TJSVD testSVD = new TJSVD(A_test);
        watch.Stop();
        writer.WriteLine($"{watch.ElapsedMilliseconds} {matsize}");
        }
        writer.Close();
    }
}