using System;
using static System.Console;
public class genlist<T>{
	public T[] data;
	public int size {get{return data.length;}} //Property for size
	public genlist(){ data = new T[0]; }
	public void push(T item){//Adds item to the list
		T[] newdata = new T[size+1];
		for(int i=0; i<size; i++)newdata[i]=data[i];
		newdata[size]=item;
		data=newdata;
	}
}
public class main{
public static void Main(){
	var list = new genlist<double[] >
	char[] delimiter = {' ', '\t'};
	var options = StringSplitOptions.RemoveEmptyEntries;
	for(string line =ReadLine(); line!=null; line=ReadLine());{
		var words =line.Split(delimiters,options);
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0; i<n; i++;) numbers[i]= double.Parse(words[i]);
		list.push(numbers);
		}
	for(int i=0; i<list.size; i++){
		var numbers = list.data[i];
		foreach(var number in numbers)WriteLine($"{number:e} ");
		}
	
	}
}
