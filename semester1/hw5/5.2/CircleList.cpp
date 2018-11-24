#include "CircleList.h"
#include "pch.h"

struct Node
{
	int number = 0;
	Node* next = nullptr;
};

Node *circleList(int number)
{
	Node *head = new Node;
	head->number = 1;
	Node *current = head;
	for (int i = 1; i < number; i++)
	{
		current->next = new Node;
		current->next->number = i + 1;
		current = current->next;
	}
	current->next = head;
	return head;
}

int deleteNode(Node **head, int stepsCounter)
{
	Node *current = *head;
	Node *parent = current;
	while (parent->next != current)
	{
		parent = parent->next;
	}
	while (current->next != parent)
	{
		for (int i = 1; i < stepsCounter; i++)
		{
			parent = current;
			current = current->next;
		}
		if (current == *head)
		{
			*head = current->next;
		}
		parent->next = current->next;
		delete current;
		current = parent->next;
	}
	if (stepsCounter % 2 == 0)
	{
		if (*head == current)
		{
			*head = current;
		}
		delete parent;
		return current->number;
	}
	else
	{
		if (*head == parent)
		{
			*head = parent;
		}
		delete current;
		return parent->number;
	}
}