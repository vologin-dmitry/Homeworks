#include "pch.h"
#include "List.h"
#include <iostream>

void deleteNode(Node *parent);

void addNode(List *list, std::string data)
{
	Node * newElement = new Node{ data, nullptr };
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
		std::cout << "\n" << current->data;
		current = current->next;
	}
}

bool nodeExists(List list, Node *toSearch)
{
	Node *current = list.head;
	while (current != nullptr)
	{
		if (current->data == toSearch->data)
		{
			return true;
		}
		current = current->next;
	}
	return false;
}

void deleteRepeating(List *list)
{
	List wasThere;
	Node *current = list->head;
	if (current == nullptr)
	{
		return;
	}
	addNode(&wasThere, list->head->data);
	while (current->next != nullptr)
	{
		if (!nodeExists(wasThere, current->next))
		{
			addNode(&wasThere, current->next->data);
			current = current->next;
		}
		else
		{
			deleteNode(current);
		}
	}
	clear(wasThere.head);
}

void deleteNode(Node *parent)
{
	if (parent->next == nullptr)
	{
		delete parent->next;
		parent->next == nullptr;
		return;
	}
	Node *temp = parent->next;
	parent->next = temp->next;
	delete temp;
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