out.txt : main.exe
	mono main.exe > out.txt
	cat out.txt
main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^

clean : 
	rm -rf *.txt *.exe *.dll