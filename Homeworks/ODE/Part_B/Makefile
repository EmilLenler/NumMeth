plot1.png plot2.png : out.txt OutputFile1.txt OutputFile2.txt Makefile
	echo "\
	set terminal png \n\
	set output 'plot1.png' \n\
	set xlabel '$$ t$$' \n\
	set key top right \n\
	set title '$$ \omega (t)$$ and $$ \Theta (t)$$' \n\
	plot 'OutputFile1.txt' using 1:2 with lines title '$$ \Theta (t)$$' ,\ \n\
	'OutputFile1.txt' using 1:3 with lines title '$$ \omega (t)$$' \n\
	"| tee log.gpi | pyxplot
	echo "\
	set terminal png \n\
	set output 'plot2.png' \n\
	set xlabel '$$ t$$' \n\
	set ylabel '$$ u(t)$$' \n\
	set key top right \n\
	set title 'Harmonic differential equation solution' \n\
	plot 'OutputFile2.txt' using 1:2 with lines title '$$ u(t)$$' \n\
	"| tee log.gpi | pyxplot
	cat out.txt

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs matrix.dll
	mcs $(addprefix -reference:,$(filter %.dll,$^)) $(filter %.cs,$^)

matrix.dll : vector.cs matrix.cs qrgs.cs rkode.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe *.gpi *.png *.txt
