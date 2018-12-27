#pragma once
#include <vector>
#include <utility>
#include <list>
#include <queue>
#include <string>

struct Graph;

Graph *getGraph(const int size);
std::string searchMST(Graph *graph);
void addCell(Graph *&graph, const int i, const int j, const int key);
void deleteGraph(Graph *&graph);