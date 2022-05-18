out.txt : hello.exe
	mono hello.exe>out.txt
	cat out.txt

hello.exe : hello.cs
	mcs hello.cs
clean : 
	rm -rf *.txt *.exe