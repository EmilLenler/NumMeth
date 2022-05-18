using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		complex sqrt1 = cmath.sqrt(-1);
		WriteLine($"Sqrt(-1) = 	{sqrt1} should be 1i");
		complex sqrti = cmath.sqrt(cmath.I);
		WriteLine($"Sqrt(i) = {sqrti} should be 0.707+0.707i");
		complex etoi = cmath.pow(E,cmath.I);
		WriteLine($"e^i = {etoi} should be 0.54 +0.84i");
		complex etoipi = cmath.pow(E,PI*cmath.I);
		WriteLine($"e^(i*pi) = {etoipi} should be -1");
		complex itoi = cmath.pow(cmath.I,cmath.I);
		WriteLine($"i^i = {itoi} should be 0.208");
		complex lni = cmath.log(cmath.I);
		WriteLine($"ln(i) = {lni} should be 1.57i");
		complex sinipi = cmath.sin(cmath.I*PI);
		WriteLine($"sin(i*pi) = {sinipi} should be 11.5i");
}
}
