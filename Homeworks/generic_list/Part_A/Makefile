all : OutA.txt
	cat OutA.txt

OutA.txt : Main_A.exe input.txt
	cat input.txt | mono Main_A.exe > OutA.txt

Main_A.exe : Main_A.cs
	mcs Main_A.cs

clean : 
	rm -rf Main_A.exe OutA.txt
