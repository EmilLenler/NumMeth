outputmax.txt : maxima.exe
	mono maxima.exe > outputmax.txt
	cat outputmax.txt

maxima.exe : maxima.cs
	mcs maxima.cs

clean : 
	rm -f outputmax.txt maxima.exe
