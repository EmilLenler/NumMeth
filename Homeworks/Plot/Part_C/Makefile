gammacomp.pyxplot.png : gammacomp.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Re(z)' \n\
	set ylabel 'Im(z)' \n\
	set zlabel 'Abs(Gamma(z))' \n\
	set zrange [0:10] \n\
	set xrange[-4:4] \n\
	set key below \n\
	set size 8 square \n\
	set grid \n\
	set view -30,30 \n\
	plot 3d '$<' using 1:2:3 with surface col black fillcol blue notitle \n\
	" | tee logC.gpi | pyxplot

gammacomp.txt : mainC.exe
	mono mainC.exe >gammacomp.txt

mainC.exe : mainC.cs
	mcs -reference:cmath.dll mainC.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^
