using static System.Console;
using static System.Math;
class main{
	static void Main(){
		int i = 1;
		while (i<i+1)
			i++;
		Write("Max. integer is {0}\n",i);
		int l =1;
		while (l>l-1)
			l--;
		Write("Min. integer is {0}\n",l);

		double x = 1; while(1+x!=1){x/=2;}x*=2;
		float y=1F; while((float)(1F+y) !=1F){y/=2F;}y*=2F;
		WriteLine($"Double machine epsilon is {x}, float machine epsilon is {y}");

		int n = (int)1e6;
		double eps = Pow(2,-52);
		double tiny = eps/2;
		double sumA = 0; double sumB = 0;
		sumA+=1; for(int j =0; j<n; j++){sumA+=tiny;};
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
		for(int j = 0; j<n; j++){sumB+=tiny;} sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
		WriteLine($"Is 4 approx 4+1e-9? (Should be true)");
		bool t1 = approx(4, 4+1e-9);
		bool t2 = approx(4,5);
		WriteLine($"{t1}");
		WriteLine($"Is 4 approx 5? (Should be false)");
		WriteLine($"{t2}");

	}
	public static bool approx(double a, double b, double tau = 1e-9, double eps = 1e-9){
		if(Abs(a-b)<tau){return true;}
		else if(Abs(a-b)/(Abs(a)+Abs(b))<eps){return true;}
		else return false;
	}
}
