plot.png : Out.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ t $$' \n\
	set key bottom right \n\
	set title 'Oscillator'\n\
	plot 'Out.txt' using 1:2 with lines title '$$ \Theta (t) $$' ,\ \n\
	'Out.txt' using 1:3 with lines title '$$ \omega (t) $$' \n\
	"| tee log.gpi | pyxplot

Out.txt:main.exe
	mono main.exe > Out.txt

main.exe : main.cs matlib.dll
	mcs main.cs -reference:matlib.dll

matlib.dll : ode.cs vector.cs
	mcs ode.cs vector.cs -target:library -out:matlib.dll

clean : 
	rm -rf *.txt *.exe dll