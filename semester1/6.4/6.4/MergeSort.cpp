#include "pch.h"
#include "MergeSort.h"


Node *merge(Node *first, Node *second, char choose);

Node *mergeSort(Node *list, char choose)
{
	Node *firstListHead = list;
	Node *secondListHead = list;
	for (int i = 0; i < (getLength(list) / 2) - 1; ++i)
	{
		secondListHead = getNext(secondListHead);
	}
	Node *temp = secondListHead;
	secondListHead = getNext(secondListHead);
	setNext(temp, nullptr);
	if (getNext(firstListHead) != nullptr)
	{
		firstListHead = mergeSort(firstListHead, choose);
	}
	if (getNext(secondListHead) != nullptr)
	{
		secondListHead = mergeSort(secondListHead, choose);
	}
	return merge(firstListHead, secondListHead, choose);
}

Node *merge(Node *first, Node *second, char choose)
{
	if (first == nullptr)
	{
		return second;
	}
	if (second == nullptr)
	{
		return first;
	}
	if (!compare(first, second, choose))
	{
		setNext(first, merge(getNext(first), second, choose));
		return first;
	}
	else
	{
		setNext(second, merge(first, getNext(second), choose));
		return second;
	}
}

void sort(Node *&head, char choose)
{
	if (head != nullptr)
	{
		head = mergeSort(head, choose);
	}
}

bool compare(Node *first, Node *second, char choose)
{
	if (choose == '1')
	{
		return getName(first) >= getName(second);
	}
	if (choose == '2')
	{
		return getNumber(first) >= getNumber(second);
	}
}