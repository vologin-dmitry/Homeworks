#pragma once
#include <vector>
#include <list>

struct Graph
{
	std::vector<std::list<int>> edges{};
};

void addCell(Graph *&graph, const int from, const int to)
{
	graph->edges[from].push_back(to);
}