#include "pch.h"
#include "PriorityQueue.h"
#include <iostream>

#define _CRT_SECURE_NO_WARNINGS



struct Element
{
	int priority = -1;
	std::string data = " ";
	Element *next = nullptr;
};

void clear(PriorityQueue *&queue)
{
	if (queue->head != nullptr)
	{
		Element *&pointer = queue->head;
		Element *following = pointer->next;
		while (following != nullptr)
		{
			delete pointer;
			pointer = following;
			following = following->next;
		}
		delete pointer;
	}
}


void enqueue(PriorityQueue *&queue, const int priority, const std::string data)
{
	Element *&head = queue->head;
	auto *node = new Element{ priority, data, nullptr };
	if (head == nullptr)
	{
		head = node;
		return;
	}
	if (node->priority > head->priority)
	{
		node->next = head;
		head = node;
		return;
	}
	Element *pointer = head;
	while (pointer->next != nullptr && (pointer->next)->priority > node->priority)
	{
		pointer = pointer->next;
	}
	if (pointer->next == nullptr)
	{
		pointer->next = node;
		return;
	}
	if ((pointer->next)->priority <= node->priority)
	{
		node->next = pointer->next;
		pointer->next = node;
		return;
	}
}

std::string dequeue(PriorityQueue *&queue)
{
	Element *&head = queue->head;
	if (head == nullptr)
	{
		return "-1";
	}
	Element *temp = head;
	std::string toReturn = temp->data;
	head = head->next;
	delete temp;
	return toReturn;
}