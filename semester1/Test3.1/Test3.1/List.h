#pragma once

struct Node
{
	Node *next = nullptr;
	int value = -1;
};

struct List
{
	Node *head = nullptr;
};

void addNode(List *&list, int value);
void deleteList(List *&list);
void listRotate(List *&list);