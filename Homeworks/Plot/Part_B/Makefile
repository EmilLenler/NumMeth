gamma.pyxplot.png : gamma.txt tablevals.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'gamma(x)' \n\
	set title 'Gamma Function' \n\
	plot '$<' using 1:2 with lines title 'Gamma Fct' ,\ \n\
	'tablevals.txt' with pointtype 3 title 'tablevals' \n\
	" |tee logB.gpi |pyxplot

gamma.txt : mainB.exe
	mono mainB.exe > $@

mainB.exe : mainB.cs
	mcs mainB.cs
