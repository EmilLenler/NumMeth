Out.txt : main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe : main.cs int.dll Makefile
	mcs $(addprefix -reference:,$(filter %.dll,$^)) $(filter %.cs,$^)

int.dll : int.cs
	mcs int.cs -target:library

clean : 
	rm  *.dll *.exe Out.txt