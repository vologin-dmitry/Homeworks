#pragma once
#include "pch.h"
#include <string>

struct List;

void addToList(List *list, const std::string &value);
int getLength(List *list);
void clear(List *list);
bool isEmpty(List *list);
std::string listToString(List *list);
List* createList();