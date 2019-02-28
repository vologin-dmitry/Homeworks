#pragma once

struct Node
{
	Node *leftPointer = nullptr;
	Node *rightPointer = nullptr;
	int value = -1;
};

struct List
{
	Node *head = nullptr;
	Node *tail = nullptr;
	int size = 0;
};

void addNode(List *list, int value, int mark);
void deleteNode(List *list, int number);
void deleteList(List *list);
void printList(List &list);