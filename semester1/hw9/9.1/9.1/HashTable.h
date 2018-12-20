#pragma once
#include <vector>
#include <string>

struct Node
{
	int count = 1;
	std::string value = "";
};

struct HashTable
{
	std::vector<std::list<Node>> buckets;
};

void constructor(HashTable &table);
Node *findNode(HashTable &table, std::string const & str);
void add(HashTable &table, std::string const & toAdd);