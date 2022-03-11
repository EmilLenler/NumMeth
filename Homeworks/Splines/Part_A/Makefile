1_plot.png x_plot.png x_square_plot.png : OutA.txt Makefile
	echo "\
	set terminal png \n\
	set output '1_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = 1'\n\
	set ylabel 'y' \n\
	set yrange [0:2] \n\
	plot '$<' using 1:2 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt' using 1:2 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee log1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'x_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = x'\n\
	set ylabel 'y' \n\
	set yrange [0:6] \n\
	plot '$<' using 1:3 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt' using 1:3 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee logx.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'x_square_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = x^^2'\n\
	set ylabel 'y' \n\
	set yrange [0:30] \n\
	plot '$<' using 1:4 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt' using 1:4 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee log1.gpi | pyxplot


OutA.txt TableVals.txt : mainA.exe
	mono mainA.exe > OutA.txt

mainA.exe : mainA.cs
	mcs mainA.cs

clean :
	rm -rf *.txt *.png *.exe *.gpi