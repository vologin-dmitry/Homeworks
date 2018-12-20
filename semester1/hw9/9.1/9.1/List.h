#pragma once
#include "pch.h"
#include <string>

struct Node
{
	std::string value = "";
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

void addNode(List *value, std::string number);
void printList(List list);
int getLength(Node *current);
void clear(Node *&head);
bool isEmpty(List list);