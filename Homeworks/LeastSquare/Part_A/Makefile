dataplot.png : out.txt Makefile
	cat out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'time ' \n\
	set key top right \n\
	set title 'Activity'\n\
	set ylabel 'ln(Activity)' \n\
	set xrange[0:20] \n\
	set yrange[1:5] \n\
	plot 'DataOut.txt' using 1:2:3 with yerrorbars title 'Data' ,\ \n\
	'FitOut.txt' using 1:2 with lines title 'Fitted Curve' \n\
	"| tee log.gpi | pyxplot
out.txt CleanData.txt DataOut.txt : main.exe data.txt
	mono main.exe > out.txt

main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll

matrix.dll : qrgs.cs matrix.cs vector.cs fit.cs
	mcs -target:library -out:$@ $^

clean :
	rm -rf *.dll *.exe CleanData.txt *.gpi *.png DataOut.txt FitOut.txt out.txt