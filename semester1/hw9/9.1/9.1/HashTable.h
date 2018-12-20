#pragma once
#include <vector>
#include <string>
#include "List.h"

struct Node
{
	int count = 1;
	std::string value = "";
};

struct HashTable
{
	std::vector<List> buckets;
};

void constructor(HashTable &table);
Node *findNode(HashTable &table, std::string const & str);
void add(HashTable &table, std::string const & toAdd);