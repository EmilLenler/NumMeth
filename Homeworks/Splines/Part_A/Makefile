#This is just plotting. Takes up a lot of space, but nothing exciting happening here.
1_plot.png x_plot.png x_square_plot.png 1_int.png x_int.png xsq_int.png: OutA.txt Makefile TableVals.txt IntVals.txt
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
	set title 'y = $$ x^2$$'\n\
	set ylabel 'y' \n\
	set yrange [0:30] \n\
	plot '$<' using 1:4 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt' using 1:4 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee log1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output '1_int.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = Int(y=1)'\n\
	set ylabel 'y' \n\
	set yrange [0:6] \n\
	plot 'IntVals.txt' using 1:2 with lines title 'Integral of y = 1' \n\
	"| tee log1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'x_int.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = Int(y=x)'\n\
	set ylabel 'y' \n\
	set yrange [0:14] \n\
	plot 'IntVals.txt' using 1:3 with lines title 'Integral of y = x' \n\
	"| tee log1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'xsq_int.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = Int(y=$$ x^2$$)'\n\
	set ylabel 'y' \n\
	set yrange [0:45] \n\
	plot 'IntVals.txt' using 1:4 with lines title 'Integral of $$ x^2$$ squared' \n\
	"| tee log1.gpi | pyxplot

OutA.txt TableVals.txt IntVals.txt : mainA.exe
	mono mainA.exe > OutA.txt

mainA.exe : mainA.cs
	mcs mainA.cs

clean :
	rm -rf *.txt *.png *.exe *.gpi