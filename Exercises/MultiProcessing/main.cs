using System;
using System.Threading;
using static System.Console;
class main{
    public class data {public int a,b; public double sum;}

    public static void harm(object obj){
        data d =(data)obj;
        WriteLine($"harm: summing from {(float)d.a} to {(float)d.b} ...");
        d.sum = 0; for(int i =d.a; i<d.b; i++)d.sum+=1.0/i;
        WriteLine($"The harmonic sum from {(float)d.a} to {(float)d.b} gives {d.sum}");
    }

    public static void Main(string[] args){
        int N =(int)1e8;
        WriteLine($"Doing harmonic sum over four threads up to N = {(float)N}");
        data x = new data();
        data y = new data();
        data z = new data();
        data u = new data();
        x.a =1; x.b = N/4;
        y.a = N/4; y.b = 2*N/4;
        z.a = 2*N/4; z.b =3*N/4;
        u.a = 3*N/4; u.b =N+1;
        Thread t1 = new Thread(harm);
        Thread t2 = new Thread(harm);
        Thread t3 = new Thread(harm);
        Thread t4 = new Thread(harm);

        t1.Start(x);
        t2.Start(y);
        t3.Start(z);
        t4.Start(u);

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        WriteLine($"The harmonic sum from 1 to {(float)N} is {x.sum+y.sum+z.sum+u.sum}");
    }
}