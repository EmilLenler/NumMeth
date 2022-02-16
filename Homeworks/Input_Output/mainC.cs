using static System.Console;
using System;
using static System.Math;
using System.IO;
class inputreader{
	public static int Main(string[] args){
		string infile=null, outfile=null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-input")infile=words[1];
			else if(words[0]=="-output")outfile=words[1];
			else { Error.WriteLine("wrong argument"); return 1;}
		}
	var instream =new System.IO.StreamReader(infile);
	var outstream =new System.IO.StreamWriter(outfile);
	outstream.WriteLine("This is output C");
	for(string line =instream.ReadLine();line!=null;line=instream.ReadLine()){
		double x = double.Parse(line);
		outstream.WriteLine($" x = {x} , sin(x) = {Sin(x)} , cos(x) = {Cos(x)}");
	}
	instream.Close();
	outstream.Close();
	return 0;
	}
}
