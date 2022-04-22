comparison.png : out.txt Makefile
	echo "\
	set terminal png \n\
	set output 'comparison.png' \n\
	set xlabel 'r' \n\
	set ylabel '$$ \psi (r)$$' \n\
	set xrange [0:8] \n\
	set yrange [0:0.5] \n\
	set title 'Wave Function Comparison' \n\
	set key top right \n\
	plot '$<' using 1:2 with color colors.red lines  title 'ODE Solution' ,\ \n\
	'$<' using 1:3 with color colors.green lines linetype 2 title 'Exact Solution' \n\
	" |tee logA.gpi |pyxplot

out.txt : main.exe
	mono main.exe > out.txt
	cat out.txt

main.exe : main.cs matrix.dll
	mcs main.cs -reference:matrix.dll

matrix.dll : vector.cs matrix.cs qrgs.cs rkode.cs H.cs roots.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe *.gpi *.png *.txt
