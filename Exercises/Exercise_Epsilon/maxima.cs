using static System.Console;
class hello{
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
	}
}
