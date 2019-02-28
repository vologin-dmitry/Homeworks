#pragma once

struct Node
{
	Node *leftPointer = nullptr;
	Node *rightPointer = nullptr;
	int value = -1;
	int mark = -1;
};

struct List
{
	Node *head = nullptr;
	Node *tail = nullptr;
};

void addNode(List *&list, int value);
void deleteList(List *&list);