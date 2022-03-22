using static System.Math;
using static System.Console;
using System;

public class main{
    public static void Main(){
        matrix A_1 = new matrix(7,7);
        matrix A_2 = new matrix(7,5);
        Random rnd = new Random();
        int A1_size1 = A_1.size1;
        int A1_size2 = A_1.size2;
        for(int j=0; j<A1_size1; j++){
            for(int i =0; i<A1_size2; i++){
                A_1[j,i] = rnd.Next(1,11); //Make random matrix with values in range [1,10].
            }
        }
        for(int j=0; j<A_2.size1;j++){
            for(int i=0; i<A_2.size2; i++){
                A_2[j,i]=rnd.Next(1,11);
            }
        }
        double[] sol_data = new double[A1_size1];
        for(int j=0; j<A1_size1; j++){
            sol_data[j]=rnd.Next(1,37); //Set j'th element of the vector to some int between (and including) 0 and 36.
        }
        vector b = new vector(sol_data);
        WriteLine($"Length of b vector is {b.size}");
	WriteLine("Doing Testing of square matrix solution");
    A_1.print("A=");
    QRGS SOL = new QRGS(A_1);
    SOL.R.print("Is R upper triangular?");
	SOL.Q.print("Q=");
	var tmp = SOL.Q.T*SOL.Q;
	tmp.print("QT*Q = 1?");
	var s = SOL.solve(b);
    b.print("b is:");
    s.print($"Solution is ");
    var o = A_1*s;
    o.print("Is Ax = b?");
    WriteLine($"{o.approx(b)}");
    var c1 =SOL.Q*SOL.R;
    c1.print("Is Q*R = A?");
    WriteLine($"{c1.approx(A_1)}");
    WriteLine("Square matrix solution testing over");
    WriteLine("Testing non square matrix now:");
    QRGS Non_Square= new QRGS(A_2);
    Non_Square.R.print("Is R upper triangular?");
    Non_Square.Q.print("Q=");
    var tmp2 = Non_Square.Q.T*Non_Square.Q;
    tmp.print("QT*Q=1?");
    var tmp3 =Non_Square.Q*Non_Square.R;
    tmp3.print("Is QR=A?");
    WriteLine($"{tmp3.approx(A_2)}");
    WriteLine("Non-square matrix testing over!");
    }
    
}