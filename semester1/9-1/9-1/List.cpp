#include "pch.h"
#include "List.h"
#include <iostream>

struct Node
{
	std::string value = "";
	int count = 1;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

void addToList(List *list, const std::string &value)
{
	Node *current = list->head;
	if (current == nullptr)
	{
		list->head = new Node{ value, 1, nullptr };
		return;
	}
	while (current->next != nullptr && current->value != value)
	{
		current = current->next;
	}
	if (current->value == value)
	{
		++current->count;
		return;
	}
	current->next = new Node{ value, 1, nullptr };
	return;
}

int getLength(List *list)
{
	Node *current = list->head;
	int count = 0;
	while (current != nullptr)
	{
		++count;
		current = current->next;
	}
	return count;
}

void clear(List *list)
{
	if (list->head != nullptr)
	{
		Node *current = list->head;
		Node *temp = list->head;
		while (current != nullptr)
		{
			temp = current;
			current = current->next;
			delete temp;
		}
	}
	delete list;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

std::string listToString(List *list)
{
	Node *current = list->head;
	std::string answer = "";
	while (current != nullptr)
	{
		answer += current->value + '\t' + std::to_string(current->count) + '\n';
		current = current->next;
	}
	return answer;
}

List* createList()
{
	return new List{ nullptr };
}