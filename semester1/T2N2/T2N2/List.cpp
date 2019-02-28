#include "pch.h"
#include "List.h"
#include <iostream>

using namespace std;

void addNode(List *list, int value, int number)
{
	if (number > list->size)
	{
		cout << "Error !";
		return;
	}
	if (number == 0)
	{
		Node *newElement = new Node;
		newElement->rightPointer = list->head;
		if (list->head != nullptr)
		{
			list->head->leftPointer = newElement;
		}
		else
		{
			list->tail = newElement;
		}
		list->head = newElement;
		newElement->value = value;
	}
	else if (number == list->size)
	{
		list->tail->rightPointer = new Node;
		list->tail->rightPointer->leftPointer = list->tail;
		list->tail = list->tail->rightPointer;
		list->tail->value = value;
	}
	else
	{
		Node *current = list->head;
		int i = 0;
		while (i < number)
		{
			current = current->rightPointer;
			++i;
		}
		Node *newElement = new Node;
		newElement->leftPointer = current->leftPointer;
		newElement->rightPointer = current;
		newElement->leftPointer->rightPointer = newElement;
		newElement->rightPointer->leftPointer = newElement;
		newElement->value = value;
	}
	++list->size;
}

void deleteNode(List *list, int number)
{
	if (number > list->size - 1)
	{
		cout << "Error !";
		return;
	}
	else if (number == 0)
	{
		if (list->size == 1)
		{
			delete list->head;
			list->head = nullptr;
			list->tail = nullptr;
		}
		else
		{
			Node *temp = list->head;
			list->head = temp->rightPointer;
			list->head->leftPointer = nullptr;
			delete temp;
		}
	}
	else if (number == list->size - 1)
	{
		list->tail = list->tail->leftPointer;
		delete list->tail->rightPointer;
		list->tail->rightPointer = nullptr;
	}
	else
	{
		Node *current = list->head;
		int i = 0;
		while (i < number)
		{
			current = current->rightPointer;
			++i;
		}
		current->leftPointer->rightPointer = current->rightPointer;
		current->rightPointer->leftPointer = current->leftPointer;
		delete current;
	}
	--list->size;
}

void deleteList(List *list)
{
	Node *current = list->head;
	Node *temp = list->head;
	while (current != nullptr)
	{
		temp = current;
		current = current->rightPointer;
		delete temp;
	}
	list->head = nullptr;
	list->tail = nullptr;
}

void printList(List &list)
{
	Node *current = list.head;
	while (current != nullptr)
	{
		cout << current->value << " ";
		current = current->rightPointer;
	}
	cout << endl;
}