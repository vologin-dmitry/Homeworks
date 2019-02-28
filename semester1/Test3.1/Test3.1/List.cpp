#include "pch.h"
#include "List.h"

void addNode(List *&list, int value)
{
	if (list->head == nullptr)
	{
		list->head = new Node;
		list->head->value = value;
		return;
	}
	Node *current = list->head;
	while (current->next != nullptr)
	{
		current = current->next;
	}
	current->next = new Node;
	current->next->value = value;
	return;
}

void deleteList(List *&list)
{
	Node *current = list->head;
	Node *temp = list->head;
	while (current->next != nullptr)
	{
		temp = current;
		current = current->next;
		delete temp;
	}
	delete current->next;
	list->head = nullptr;
}

void listRotate(List *&list)
{
	if (list->head == nullptr || list->head->next == nullptr)
	{
		return;
	}
	if (list->head->next->next == nullptr)
	{
		Node *left = list->head;
		Node *right = list->head->next;
		right->next = left;
		list->head = right;
		left->next = nullptr;
		return;
	}
	Node *left = list->head;
	Node *center = left->next;
	Node *right = center->next;
	left->next = nullptr;
	while (right->next != nullptr)
	{
		center->next = left;
		left = center;
		center = right;
		right = right->next;
	}
	center->next = left;
	right->next = center;
	list->head = right;
}