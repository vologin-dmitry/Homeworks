#pragma once
#include "pch.h"
#include <string>

struct Node
{
	std::string name = "";
	std::string number = "";
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

void addNode(List *list, std::string name, std::string number);
void printList(List list);
int getLength(Node *current);
void clear(Node *&head);