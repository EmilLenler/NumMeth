using System;
using static System.Console;
using System.Collections;
public class genlist<T>{
	public T[] data;
	public int size {get{return data.Length; }}
	public genlist(){ data = new T[0]; }
	public void push(T item){
		T[] newdata = new T[size+1];
		for(int i=0; i<size; i++)newdata[i]=data[i];
		newdata[size]=item;
		data=newdata;
	}
}

public class main{
	public static void Main(){
		var list = new genlist<double[]>();
		char[] delimiters = {' ', '\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line =ReadLine(); line!=null; line=ReadLine()){
			var words =line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0; i<n; i++) numbers[i]= double.Parse(words[i]);
			list.push(numbers);
			}
		for(int i=0; i<list.size; i++){
			var numbers = list.data[i];
			foreach(var number in numbers)Write($"{number:e} ");
			WriteLine();
			}
	
		}
}
