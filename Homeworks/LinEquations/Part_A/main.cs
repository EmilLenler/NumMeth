using static System.Math;
using static System.Console;
using System;

public class main{
    public static void Main(){
        matrix A = new matrix(5,4);
        Random rnd = new Random();
        int A_size1 = A.size1;
        int A_size2 = A.size2;
        for(int j=0; j<A_size1; j++){
            for(int i =0; i<A_size2; i++){
                A[j,i] = rnd.Next(1,11); //Make random matrix with values in range [1,10].
            }
        }
        double[] sol_data = new double[A_size1];
        for(int j=0; j<A_size1; j++){
            sol_data[j]=rnd.Next(1,37); //Set j'th element of the vector to some int between (and including) 0 and 36.
        }
        vector b = new vector(sol_data);
        WriteLine($"Length of b vector is {b.size}");
	A.print("A=");
    QRGS SOL = new QRGS(A);
    SOL.R.print("Is R upper triangular?");
	SOL.Q.print("Q=");
	var tmp = SOL.Q.T*SOL.Q;
	tmp.print("QT*Q = 1?");
	var s = SOL.solve(b);
    b.print("b is:");
    s.print($"Solution is ");
    var o = A*s;
    o.print("Is Ax = b?");
    WriteLine($"{o.approx(b)}");
    var c1 =SOL.Q*SOL.R;
    c1.print("Is Q*R = A?");
    WriteLine($"{c1.approx(A)}");
    }
}