timeplot.png : TimeData.txt Makefile out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Matrix size' \n\
	set key top left \n\
	set title 'Error Function'\n\
	set ylabel 'Time spent / ms' \n\
	plot '$<' using 2:1 with points title 'Computation Time for SVD' \n\
	"| tee log.gpi | pyxplot

out.txt TimeData.txt : main.exe
	mono main.exe > out.txt
	cat out.txt

main.exe : main.cs SVD.dll
	mcs main.cs -reference:SVD.dll

SVD.dll : vector.cs matrix.cs SVD_TWO_JACOBI.cs
	mcs -target:library -out:$@ $^

clean : 
	rm -rf *.exe out.txt *.gpi *.dll *.png TimeData.txt