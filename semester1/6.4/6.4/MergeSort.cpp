#include "pch.h"
#include "MergeSort.h"

Node *merge(Node *&first, Node *&second, char choose);

Node *mergeSort(Node *&list, char choose)
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
		firstListHead = mergeSort(firstListHead, choose);
	}
	if (secondListHead->next != nullptr)
	{
		secondListHead = mergeSort(secondListHead, choose);
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

void sort(List *list, char choose)
{
	if (list->head != nullptr)
	{
		list->head = mergeSort(list->head, choose);
	}
}