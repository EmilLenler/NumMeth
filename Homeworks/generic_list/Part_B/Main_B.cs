using System;
using static System.Console;
using System.Collections;
public class genlist<T>{
	public T[] data;
	public int size=0, capacity=8;
	public genlist(){ data = new T[capacity]; }
	public void push(T item){
		if(size==capacity){
			T[] newdata = new T[capacity*2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
		}
		data[size]=item;
		size++;
	}
	public void remove(int i){
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
