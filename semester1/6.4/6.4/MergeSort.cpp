#include "pch.h"
#include "MergeSort.h"

Node *merge(Node *&first, Node *&second, char choose);

Node *sort(Node *&list, char choose)
{
	Node *firstListHead = list;
	Node *secondListHead = list;
	for (int i = 0; i < (getLength(list) / 2) - 1; ++i)
	{
		secondListHead = secondListHead->next;
	}
	Node *temp = secondListHead;
	secondListHead = secondListHead->next;
	temp->next = nullptr;
	if (firstListHead->next != nullptr)
	{
		firstListHead = sort(firstListHead, choose);
	}
	if (secondListHead->next != nullptr)
	{
		secondListHead = sort(secondListHead, choose);
	}
	return merge(firstListHead, secondListHead, choose);
}

Node *merge(Node *&first, Node *&second, char choose)
{
	if (first == nullptr)
	{
		return second;
	}
	if (second == nullptr)
	{
		return first;
	}
	if (choose == '1')
	{
		if (first->name < second->name)
		{
			first->next = merge(first->next, second, choose);
			return first;
		}
		else
		{
			second->next = merge(first, second->next, choose);
			return second;
		}
	}
	if (choose == '2')
	{
		if (first->number < second->number)
		{
			first->next = merge(first->next, second, choose);
			return first;
		}
		else
		{
			second->next = merge(first, second->next, choose);
			return second;
		}
	}
}

