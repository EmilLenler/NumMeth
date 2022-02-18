using static System.Math;
using static System.Console;
public class main{
	public static void Main(){
		double k = 1;
		System.Func<double,double> sink = delegate(double x){return Sin(k*x);};
		WriteLine("List of values for sin(k*x) Here k=1. Data format is x sin(kx)");
		maketable.make_table(sink,0,PI,0.1);
		WriteLine("k = 2 now");
		k=2;
		maketable.make_table(sink,0,PI,0.1);
		WriteLine("k = 3 now");
		k=3;
		maketable.make_table(sink,0,PI,0.1);
	}
}
