using static System.Math;
using static System.Console;
class Maths{
	static void Main(){
		double num1=Sqrt(2);
		double num2=Pow(E,PI);
		double num3=Pow(PI,E);
			System.Console.Write("Sqrt of 2 is {0}, e^pi is {1}, pi^e is {2} \n",num1, num2, num3);
		double num11 = num1*num1;
		double num22 = Log(num2);
		WriteLine($"sqrt(2)^2 = {num11} and ln(e^pi) = {num22}");
	}
}
