out.txt : main.exe
	mono main.exe > out.txt
	cat out.txt

main.exe : main.cs math.dll
	mcs main.cs -reference:math.dll

math.dll : minimization.cs vector.cs matrix.cs
	mcs minimization.cs vector.cs matrix.cs -target:library -out:math.dll