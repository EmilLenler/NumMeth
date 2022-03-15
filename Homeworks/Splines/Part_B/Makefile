OutB.txt : mainB.exe
	mono mainB.exe

mainB.exe : mainB.cs qspline.dll
	mcs mainB.cs -target:exe -reference:qspline.dll

qspline.dll : qspline.cs
	mcs $< -target:library

#clean :
#rm -rf *.exe *.dll