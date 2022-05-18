Out.txt : main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe : main.cs math.dll
	mcs main.cs -reference:math.dll

math.dll : MC.cs vector.cs
	mcs MC.cs vector.cs -target:library -out:math.dll

clean :
	rm -rf *.exe *.dll *.txt