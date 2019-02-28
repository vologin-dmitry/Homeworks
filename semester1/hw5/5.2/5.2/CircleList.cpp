#include "pch.h"
#include "CircleList.h"

Node *createSquad(int number)
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