Out.txt:main.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs main.cs -reference:matlib.dll

matlib.dll : ode.cs vector.cs
	mcs -out:./$@ -target:library ode.cs vector.cs