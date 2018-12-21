#include "pch.h"
#include "HashTable.h"
#include "List.h"

int hashFunction(std::string const & str)
{
	int sum = 0;
	int size = str.size();
	for (int i = 0; i < size; ++i)
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
	Node *current = table.buckets[hash].head;
	int size = getLength(table.buckets[hash].head);
	for (int i = 0; i < size; ++i)
	{
		if (current->value == str)
		{
			return current;
		}
		else
		{
			current = current->next;
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
		addNode(&table.buckets[hash], toAdd);
	}
	else
	{
		++(temp->count);
	}
}
