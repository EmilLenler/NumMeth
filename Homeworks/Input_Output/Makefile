all: outA.txt outB.txt outC.txt
	cat outA.txt
	cat outB.txt
	cat outC.txt

outA.txt outB.txt outC.txt : mainA.exe mainB.exe mainC.exe input.txt
	echo 1 2 3 4 5 | mono mainA.exe > outA.txt
	mono mainB.exe 1 2 3 4 5 > outB.txt
	mono mainC.exe -input:input.txt -output:outC.txt

mainA.exe : mainA.cs
	mcs mainA.cs

mainB.exe : mainB.cs
	mcs mainB.cs

mainC.exe : mainC.cs
	mcs mainC.cs

clean:
	rm -rf [Oo]ut* *.exe
