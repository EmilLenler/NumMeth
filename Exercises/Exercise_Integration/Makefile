all: Out.txt
	cat Out.txt

Out.txt : main.exe
	mono main.exe >Out.txt

main.exe : main.cs matlib.dll
	mcs main.cs -reference:matlib.dll

matlib.dll : integrate.cs
	mcs -target:library -out:./matlib.dll integrate.cs

clean : 
	rm matlib.dll main.exe Out.txt

#This is a git workaro