#include "pch.h"
#include "List.h"

void addNode(List *&list, int value)
{
	if (list->head == nullptr)
	{
		list->head = new Node;
		list->head->value = value;
		list->tail = list->head;
		list->head->mark = 1;
		return;
	}
	Node *temp = list->tail;
	list->tail->rightPointer = new Node;
	list->tail = list->tail->rightPointer;
	list->tail->leftPointer = temp;
	list->tail->value = value;
	list->tail->mark = list->tail->leftPointer->mark + 1;
}

void deleteList(List *&list)
{
	Node *current = list->head;
	Node *temp = list->head;
	while (current != list->tail)
	{
		temp = current;
		current = current->rightPointer;
		delete temp;
	}
	delete current;
	list->head = nullptr;
	list->tail = nullptr;
}
