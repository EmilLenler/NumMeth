plot.png : erfout.txt erftable.txt
		echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ z$$' \n\
	set key bottom right \n\
	set title 'Error Function'\n\
	set ylabel '$$ erf(z)$$' \n\
	plot '$<' using 1:2 with lines title 'Numerical integration' ,\ \n\
	'erftable.txt' using 1:2 with points title 'Tabulated Values' \n\
	"| tee log.gpi | pyxplot
	cat Out.txt
Out.txt erfout.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs int.dll Makefile
	mcs $(addprefix -reference:,$(filter %.dll,$^)) $(filter %.cs,$^)

int.dll : int.cs
	mcs int.cs -target:library

clean : 
	rm *.png *.gpi *.dll *.exe erfout.txt Out.txt