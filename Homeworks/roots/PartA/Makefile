Out.txt : main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe : main.cs math.dll
	mcs main.cs -reference:math.dll

math.dll : matrix.cs vector.cs roots.cs qrgs.cs
	mcs matrix.cs vector.cs roots.cs qrgs.cs -target:library -out:math.dll

clean : 
	rm -rf *.dll *.exe *.txt