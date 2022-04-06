plot.png : out.txt OutputFile.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 't' \n\
	set key top right \n\
	set title 'Omega and theta'\n\
	plot 'OutputFile.txt' using 1:2 with lines title 'Theta' ,\ \n\
	'OutputFile.txt' using 1:3 with lines title 'Omega' \n\
	"| tee log.gpi | pyxplot
	cat out.txt

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs matrix.dll
	mcs $(addprefix -reference:,$(filter %.dll,$^)) $(filter %.cs,$^)

matrix.dll : vector.cs matrix.cs qrgs.cs rkode.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe
