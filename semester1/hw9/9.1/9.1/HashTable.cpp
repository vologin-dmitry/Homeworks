#include "pch.h"
#include "HashTable.h"
#include <algorithm>
#include <string>

int hashFunction(std::string const & str)
{
	int sum = 0;
	for (int i = 0; i < str.size(); ++i)
	{
		sum += sum * 5 + str[i];
	}
	return sum;
}

void constructor(HashTable &table)
{
	int size = 100;
	table.buckets.resize(size);
}

Node* findNode(HashTable &table, std::string const &str)
{
	int hash = abs((int)(hashFunction(str) % table.buckets.size()));
	std::list<Node>::iterator iter = table.buckets[hash].begin();
	while (iter != table.buckets[hash].end())
	{
		if (iter->value == str)
		{
			return &(*iter);
		}
		else
		{
			++iter;
		}
	}
	return nullptr;
}

void add(HashTable &table, std::string const & toAdd)
{
	Node *temp = findNode(table, toAdd);
	if (temp == nullptr)
	{
		int hash = abs((int)(hashFunction(toAdd) % table.buckets.size()));
		table.buckets[hash].push_back({ 1, toAdd });
	}
	else
	{
		++(temp->count);
	}
}
