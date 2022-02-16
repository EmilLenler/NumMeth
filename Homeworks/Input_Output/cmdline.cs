using static System.Console;
using System;
using static System.Math;
class cmdline{
	public static void Main(string[] args){
	foreach(var arg in args){
		double x = double.Parse(arg);
		WriteLine($" x = {x} , sin(x) = {Sin(x)} , cos(x) = {Cos(x)} ");
	}
}
}
