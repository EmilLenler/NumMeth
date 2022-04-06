wfplot.png : DataOut.txt out.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'r' \n\
	set key top right \n\
	set title 'Wave Function'\n\
	set ylabel 'Wave function value' \n\
	plot '$<' using 1:2 with lines title 'Ground state' ,\ \n\
	'$<' using 1:3 with linespoints title 'GS +1' ,\ \n\
	'$<' using 1:4 with lines title 'GS +2' \n\
	"| tee log.gpi | pyxplot
	cat out.txt

out.txt DataOut.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll

matrix.dll : qrgs.cs matrix.cs vector.cs diagonalization.cs
	mcs -target:library -out:$@ $^

clean :
	rm -rf *.dll *.exe *.txt *.png *.gpi