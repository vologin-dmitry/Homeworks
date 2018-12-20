#include "pch.h"
#include "List.h"
#include <iostream>
#include "List.h"

void addNode(List *list, std::string value)
{
	Node * newElement = new Node{ value, nullptr };
	if (list->head == nullptr)
	{
		list->head = newElement;
		return;
	}
	Node *current = list->head;
	while (current->next != nullptr)
	{
		current = current->next;
	}
	current->next = newElement;
}

void printList(List list)
{
	Node *current = list.head;
	while (current != nullptr)
	{
		std::cout << "\n" << current->name << "\t" << current->number;
		current = current->next;
	}
}

int getLength(Node current)
{
	int count = 0;
	while (current != nullptr)
	{
		++count;
		current = current.next;
	}
	return count;
}

void clear(Node *&head)
{
	if (head != nullptr)
	{
		Node *temp = head;
		while (head != nullptr)
		{
			temp = head;
			head = head->next;
			delete temp;
		}
	}
}

bool isEmpty(List list)
{
	return list.head == nullptr;
}