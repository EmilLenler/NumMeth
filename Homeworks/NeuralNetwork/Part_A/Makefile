plot.png : output.txt Interpolated_DATA.txt Makefile
	echo "\
	set terminal png \n\
	set output 'plot.png' \n\
	set xlabel '$$ x$$' \n\
	set ylabel '$$ f(x)$$' \n\
	set xrange [-1:1] \n\
	set title ' $$ f(x) = cos(5x-1)*e^{(-x^2)}$$ ' \n\
	set key top left \n\
	plot 'output.txt' using 1:2 with color colors.red lines title 'Analytic values' ,\ \n\
	'Interpolated_DATA.txt' with color colors.green lines title 'Network values' \n\
	" |tee log.gpi |pyxplot

output.txt : main.exe 
	mono main.exe > output.txt
	cat output.txt

main.exe : main.cs math.dll 
	mcs main.cs -reference:math.dll

math.dll : minimization.cs network.cs vector.cs matrix.cs
	mcs minimization.cs network.cs vector.cs matrix.cs -target:library -out:math.dll