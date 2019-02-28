all: result

result: 6.1.o pch.o Stack.o
	g++ 6.1.o pch.o Stack.o -o result

6.1.o: 6.1.cpp
	g++ -c 6.1.cpp

pch.o: pch.cpp pch.h
	g++ -c pch.cpp

Stack.o: Stack.cpp Stack.h
	g++ -c Stack.cpp