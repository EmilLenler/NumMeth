erf.pyxplot.png : erf.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'Error Function'\n\
	set ylabel 'erf(x)' \n\
	plot '$<' using 1:2 with lines title 'Error Function' ,\ \n\
	'erf.table.txt' with pointtyp 3 title 'table' \n\
	"| tee log.gpi | pyxplot

erf.txt : main.exe
	mono main.exe > erf.txt

main.exe : main.cs
	mcs main.cs
