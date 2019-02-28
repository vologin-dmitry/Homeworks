#pragma once
#include "pch.h"
#include <string>

struct Node
{
	std::string data = "";
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

void addNode(List *list, std::string data);
void printList(List list);
void deleteRepeating(List *list);
void clear(Node *&head);