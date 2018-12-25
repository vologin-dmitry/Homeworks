#include "pch.h"
#include "List.h"
#include <iostream>

struct Node
{
	std::string name = "";
	std::string number = "";
	Node *next = nullptr;
};


void addNode(Node *&head, const std::string &name, const std::string  &number)
{
	Node * newElement = new Node{ name, number, nullptr };
	if (head == nullptr)
	{
		head = newElement;
		return;
	}
	Node *current = head;
	while (current->next != nullptr)
	{
		current = current->next;
	}
	current->next = newElement;
}

void printList(Node const *head)
{
	const Node *current = head;
	while (current != nullptr)
	{
		std::cout << "\n" << current->name << "\t" << current->number;
		current = current->next;
	}
}

int getLength(Node const *head)
{
	const Node *current = head;
	int count = 0;
	while (current != nullptr)
	{
		++count;
		current = current->next;
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

Node *createList()
{
	return nullptr;
}

std::string getName(Node const *current)
{
	return current->name;
}

std::string getNumber(Node const *current)
{
	return current->number;
}

Node *getNext(Node *current)
{
	if (current != nullptr)
	{
		return current->next;
	}
}

void setNext(Node *parent, Node *value)
{
	if (parent != nullptr)
	{
		parent->next = value;
	}
}