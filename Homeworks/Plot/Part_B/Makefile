#lngamma.pyxplot.png : gamma.txt
#	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'ln(gamma(x))' \n\
	set xrange [-5:5] \n\
	set yrange [-5:5] \n\
	set title 'log of gamma Function' \n\
	set key bottom right \n\
	plot '$<' using 1:3 with color colors.red lines  title 'Gamma Fct' ,\ \n\
	0 notitle with color colors.black \n\
	" |tee logBln.gpi |pyxplot
gamma.pyxplot.png lngamma.pyxplot.png : gamma.txt tablevals.txt Makefile
	echo "\
	set terminal png \n\
	set output 'gamma.pyxplot.png' \n\
	set xlabel 'x' \n\
	set ylabel 'gamma(x)' \n\
	set xrange [-5:5] \n\
	set yrange [-5:5] \n\
	set title 'Gamma Function' \n\
	set key bottom right \n\
	plot '$<' using 1:2 with color colors.red lines  title 'Gamma Fct' ,\ \n\
	'tablevals.txt' with pointtype 3 title 'Tabulated Values' ,\ \n\
	0 notitle with color colors.black \n\
	" |tee logB.gpi |pyxplot
	echo "\
	set terminal png \n\
	set output 'lngamma.pyxplot.png' \n\
	set xlabel 'x' \n\
	set ylabel 'ln(gamma(x))' \n\
	set xrange [0.1:5] \n\
	set yrange [-1:5] \n\
	set title 'log of gamma Function' \n\
	set key top left \n\
	plot '$<' using 1:3 with color colors.red lines  title 'log of gamma function' \n\
	" |tee logBln.gpi |pyxplot

gamma.txt : mainB.exe
	mono mainB.exe > $@

mainB.exe : mainB.cs
	mcs mainB.cs

clean :
	rm -rf gamma.txt *.png *.gpi *.exe	