1_plot.png x_plot.png xsq_plot.png 1_deriv.png x_deriv.png xsq_deriv.png : OutB.txt TableVals.txt AnaDerivs.txt Makefile
	echo "\
	set terminal png \n\
	set output '1_deriv.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'Derivative of y = 1'\n\
	set ylabel 'y' \n\
	set yrange [-1:1] \n\
	plot 'SplineDeriv.txt' using 1:2 with lines title 'Derivative of Interpolation' ,\ \n\
	'AnaDerivs.txt'using 1:2 with points pointtyp 3 title 'Analytical Derivatives' \n\
	"| tee logD1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'x_deriv.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'Derivative of y = x'\n\
	set ylabel 'y' \n\
	set yrange [0:7] \n\
	plot 'SplineDeriv.txt' using 1:3 with lines title 'Derivative of Interpolation' ,\ \n\
	'AnaDerivs.txt'using 1:3 with points pointtyp 3 title 'Analytical Derivatives' \n\
	"| tee logDx.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'xsq_deriv.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'Derivative of $$ y = x^2$$'\n\
	set ylabel 'y' \n\
	set yrange [0:11] \n\
	plot 'SplineDeriv.txt' using 1:4 with lines title 'Derivative of Interpolation' ,\ \n\
	'AnaDerivs.txt'using 1:4 with points pointtyp 3 title 'Analytical Derivatives' \n\
	"| tee logDxsq.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output '1_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = 1'\n\
	set ylabel 'y' \n\
	set yrange [0:2] \n\
	plot '$<' using 1:2 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt'using 1:2 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee log1.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'x_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = x'\n\
	set ylabel 'y' \n\
	set yrange [0:6] \n\
	plot '$<' using 1:3 with lines title 'Interpolation' ,\  \n\
	'TableVals.txt'using 1:3 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee logx.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'xsq_plot.png' \n\
	set xlabel 'x' \n\
	set key top left \n\
	set title 'y = $$ x^2$$'\n\
	set ylabel 'y' \n\
	set yrange [0:26] \n\
	plot '$<' using 1:4 with lines title 'Interpolation' ,\ \n\
	'TableVals.txt'using 1:4 with points pointtyp 3 title 'Tabulated Values' \n\
	"| tee logxsq.gpi | pyxplot


OutB.txt SplineDeriv.txt TableVals.txt DeriVals.txt SplineInt.txt : mainB.exe
	mono mainB.exe > OutB.txt

mainB.exe : mainB.cs qspline.dll
	mcs mainB.cs -target:exe -reference:qspline.dll

qspline.dll : qspline.cs
	mcs $< -target:library

clean :
	rm -rf *.exe *.dll *.png *.gpi *.txt