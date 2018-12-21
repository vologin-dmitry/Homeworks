#pragma once
#include "pch.h"
#include <string>

struct Node
{
	std::string value = "";
	int count = 1;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

void addNode(List *list, std::string value);
int getLength(Node *current);
void clear(Node *&head);
bool isEmpty(List list);