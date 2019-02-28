#include "pch.h"
#include <iostream>
#include "Graph.h"
#include <fstream>

using namespace std;

int main()
{
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Error ! There's no input file";
	}
	int nodes = -1;
	int edges = -1;
	file >> nodes;
	file >> edges;
	Graph *graph = new Graph;
	int temp = -1;
	int in = -1;
	int out = -1;
	for (int i = 0; i < edges; ++i)
	{
		for (int j = 0; j < nodes; j++)
		{
			file >> temp;
			if (temp > 0)
			{
				out = temp;
			}
			if (temp < 0)
			{
				in = temp;
			}
		}
		addCell(graph, out, in);
	}
	bool *ourArrays = new bool[nodes]{ true };
	bool *good = new bool[nodes]{ false };
	for (int i = 0; i < nodes; ++i)
	{
		fromEverywhere(*graph, i, good);
		for (int j = 0; j < nodes; ++j)
		{
			if (good[j] != true)
			{
				ourArrays[i] = false;
			}
		}
	}
	for (int i = 0; i < nodes; ++i)
	{
		if (ourArrays[i] == true)
		{
			cout << i + 1 << "\t";
		}
	}
	delete[] good;
	delete[] ourArrays;
	delete graph;
}

void fromEverywhere(Graph graph, int column, bool good[])
{
	for (auto iter = graph.edges[column].begin(); iter != graph.edges[column].end(); ++iter)
	{
		good[column] = true;
		fromEverywhere(graph, *iter, good);
	}
	return;
}