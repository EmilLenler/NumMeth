plot.png plotDerivative.png plotInt.png : output.txt Interpolated_DATA.txt Makefile
	echo "\
	set terminal png \n\
	set output 'plotInt.png' \n\
	set xlabel '$$ x$$' \n\
	set ylabel '$$ \int f(x) dx$$' \n\
	set xrange [-1:1] \n\
	set title 'Plot of integral' \n\
	set key top left \n\
	plot 'Interpolated_DATA.txt' using 1:5 with color colors.green lines title 'Network Integral' \n\
	" |tee logI.gpi |pyxplot
	
	echo "\
	set terminal png \n\
	set output 'plotDerivative.png' \n\
	set xlabel '$$ x$$' \n\
	set ylabel '$$ df/dx$$' \n\
	set xrange [-1:1] \n\
	set title 'Plot of derivative' \n\
	set key top left \n\
	plot 'Interpolated_DATA.txt' using 1:3 with color colors.green lines title 'Analytic values' ,\ \n\
	'Interpolated_DATA.txt' using 1:4 with color colors.red lines linetype 2 title 'Network values' \n\
	" |tee logD.gpi |pyxplot

	
	
	echo "\
	set terminal png \n\
	set output 'plot.png' \n\
	set xlabel '$$ x$$' \n\
	set ylabel '$$ f(x)$$' \n\
	set xrange [-1:1] \n\
	set title ' $$ f(x) = cos(5x-1)*e^{(-x^2)}$$ ' \n\
	set key top left \n\
	plot 'output.txt' using 1:2 with color colors.green lines title 'Analytic values' ,\ \n\
	'Interpolated_DATA.txt' with color colors.red lines linetype 2 title 'Network values' \n\
	" |tee log.gpi |pyxplot

output.txt : main.exe 
	mono main.exe > output.txt
	cat output.txt

main.exe : main.cs math.dll 
	mcs main.cs -reference:math.dll

math.dll : minimization.cs network.cs vector.cs matrix.cs
	mcs minimization.cs network.cs vector.cs matrix.cs -target:library -out:math.dll

clean : 
	rm -rf *.dll *.exe *.gpi *.txt *.png