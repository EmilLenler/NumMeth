plot.png : out.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x ' \n\
	set key top left \n\
	set title 'Exponential function'\n\
	set ylabel '$$ e^x$$' \n\
	plot '$<' using 1:2 with lines title 'Approximation of expontential function' ,\ \n\
	'$<' using 1:3 with lines lt 2 title 'Csharp implementation' \n\
	"| tee log.gpi | pyxplot

out.txt : main.exe
	mono main.exe > out.txt
	cat out.txt

main.exe : main.cs
	mcs main.cs

clean : 
	rm -rf *.txt *.exe