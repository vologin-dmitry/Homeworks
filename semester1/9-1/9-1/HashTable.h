#pragma once
#include <vector>
#include <string>
#include "List.h"

struct HashTable
{
	std::vector<List> buckets;
};

void constructor(HashTable &table);
Node *findNode(HashTable &table, std::string const & str);
void add(HashTable &table, std::string const & toAdd);
void clearTable(HashTable &table);