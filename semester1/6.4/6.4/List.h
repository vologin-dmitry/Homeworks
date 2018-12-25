#pragma once
#include "pch.h"
#include <string>

struct Node;

void addNode(Node *&head, const std::string  &name, const std::string  &number);
void printList(Node const *head);
int getLength(Node const *head);
void clear(Node *head);
Node *createList();
std::string getName(Node const *current);
std::string getNumber(Node const *current);
Node *getNext(Node *current);
void setNext(Node *parent, Node *value);