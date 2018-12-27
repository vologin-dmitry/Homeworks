#include "pch.h"
#include <iostream>
#include "Graph.h"
#include <fstream>
#include <locale.h>

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Ошибка ! Что то пошло не так !";
		return 1;
	}
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Ошибка ! Добавьте файл";
		return 1;
	}
	int size = -1;
	file >> size;
	Graph *graph = getGraph(size);
	for (int i = 0; i < size * size; ++i)
	{
		int temp = -1;
		file >> temp;
		if (temp > 0)
		{
			addCell(graph, i % size, i / size, temp);
		}
	}
	cout << "Рёбра остовного дерева :\n";
	cout << searchMST(graph);
	deleteGraph(graph);
	delete graph;
}

bool tests()
{
	Graph *graph = getGraph(5);
	addCell(graph, 0, 1, 1);
	addCell(graph, 1, 2, 3);
	addCell(graph, 2, 3, 2);
	addCell(graph, 0, 4, 3);
	addCell(graph, 1, 4, 6);
	addCell(graph, 2, 4, 2);
	addCell(graph, 3, 4, 1);
	addCell(graph, 0, 3, 13);
	string answer = searchMST(graph);
	if (searchMST(graph) != "1 0\n2 1\n3 2\n4 3\n")
	{
		deleteGraph(graph);
		return true;
	}
	deleteGraph(graph);
	return false;
}