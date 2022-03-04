erf_int_calc.png: Out.txt erf_Out.txt Makefile
	cat Out.txt
	cat erf_Out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$ z $ ' \n\
	set key top left \n\
	set title 'Error Function'\n\
	set ylabel 'erf(z)' \n\
	plot 'erf_Out.txt' using 1:2 with lines title 'Error Function' \n\
	"| tee log.gpi | pyxplot

erf_Out.txt : erfcalc.exe
	mono erfcalc.exe > erf_Out.txt

erfcalc.exe : erfcalc.cs matlib.dll
	mcs erfcalc.cs -reference:matlib.dll

Out.txt : main.exe
	mono main.exe >Out.txt

main.exe : main.cs matlib.dll
	mcs main.cs -reference:matlib.dll

matlib.dll : integrate.cs
	mcs -target:library -out:./matlib.dll integrate.cs

clean : 
	rm matlib.dll main.exe Out.txt

#This is a git workaro