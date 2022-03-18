out.txt : main.exe
	mono main.exe

main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll

matrix.dll : qrgs.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean :
	rm -rf *.dll *.exe
