#pragma once
#include <string>

struct Element;

struct PriorityQueue
{
	Element *head = nullptr;
};

void enqueue(PriorityQueue *&queue, const int priority, const std::string data);
std::string dequeue(PriorityQueue *&queue);
void clear(PriorityQueue *&queue);