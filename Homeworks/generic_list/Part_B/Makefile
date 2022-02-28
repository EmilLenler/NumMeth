all : OutB.txt
	cat OutB.txt

OutB.txt : Main_B.exe input.txt
	cat input.txt | mono Main_B.exe > OutB.txt

Main_B.exe : Main_B.cs
	mcs Main_B.cs

clean : 
	rm -rf Main_B.exe OutB.txt
