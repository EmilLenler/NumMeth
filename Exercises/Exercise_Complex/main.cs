using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		complex sqrt1 = cmath.sqrt(-1);
		WriteLine($"Sqrt(-1) = 	{sqrt1}");
		complex sqrti = cmath.sqrt(cmath.I);
		WriteLine($"Sqrt(i) = {sqrti}");
		complex etoi = cmath.pow(E,cmath.I);
		WriteLine($"e^i = {etoi}");
		complex etoipi = cmath.pow(E,PI*cmath.I);
		WriteLine($"e^(i*pi) = {etoipi}");
		complex itoi = cmath.pow(cmath.I,cmath.I);
		WriteLine($"i^i = {itoi}");
		complex lni = cmath.log(cmath.I);
		WriteLine($"ln(i) = {lni}");
		complex sinipi = cmath.sin(cmath.I*PI);
		WriteLine($"sin(i*pi) = {sinipi}");
}
}
