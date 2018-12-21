#include "pch.h"
#include "Graph.h"

struct Graph
{
	std::vector<std::list<std::pair<int, int>>> edges{};
};

Graph *getGraph(const int size)
{
	Graph *graph = new Graph;
	graph->edges.resize(size);
	return graph;
}

void prims(Graph *graph, std::vector<int> &previous, std::vector<int> &keys)
{
	const int SIZE = graph->edges.size();
	const int INF = INT_MAX;
	previous.resize(SIZE);
	std::vector <bool> alreadyWas;
	alreadyWas.resize(SIZE);
	keys.resize(SIZE);
	for (int i = 0; i < SIZE; ++i)
	{
		previous[i] = -1;
		alreadyWas[i] = false;
		keys[i] = INF;
	}
	alreadyWas[0] = true;
	keys[0] = 0;
	std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>>  queue;
	queue.push(std::make_pair(0,0));
	while (!queue.empty())
	{
		int current = queue.top().second;
		queue.pop();
		alreadyWas[current] = true;
		for (auto iter = graph->edges[current].begin(); iter != graph->edges[current].end(); ++iter)
		{
			if (!alreadyWas[iter->second] && iter->first < keys[iter->second])
			{
				keys[iter->second] = iter->first;
				queue.push(std::make_pair(iter->first, iter->second));
				previous[iter->second] = current;
			}
		}
	}
}

std::string searchMST(Graph *graph)
{
	std::vector<int> previous;
	std::vector<int> keys;
	prims(graph, previous, keys);
	std::string answer = "";
	for (int i = 1; i < graph->edges.size(); ++i)
	{
		answer += std::to_string(i) + " " + std::to_string(previous[i]) + '\n';
	}
	return answer;
}

void addCell(Graph *&graph, const int i, const int j, const int key)
{
	graph->edges[i].push_back(std::make_pair(key, j));
}

void deleteGraph(Graph *&graph)
{
	int size = graph->edges.size();
	for (int i = 0; i < size; ++i)
	{
		graph->edges[i].clear();
	}
}