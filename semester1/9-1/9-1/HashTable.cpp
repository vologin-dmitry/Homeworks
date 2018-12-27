#include "pch.h"
#include "HashTable.h"
#include "List.h"

struct Node
{
	std::string value = "";
	int count = 1;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
};

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

HashTable *createHashTable()
{
	HashTable *table = new HashTable;
	int size = 100;
	table->buckets.resize(size);
	return table;
}


void add(HashTable *table, std::string const & toAdd)
{
	int hash = abs((int)(hashFunction(toAdd) % getTableSize(table)));
	addToList(table->buckets[hash], toAdd);
}


void clearTable(HashTable *&table)
{
	int size = table->buckets.size();
	for (int i = 0; i < size; ++i)
	{
		if (!isEmpty(table->buckets[i]))
		{
			clear(table->buckets[i]);
		}
	}
}

int getTableSize(HashTable *table)
{
	return table->buckets.size();
}

std::string tableToString(HashTable *table)
{
	std::string answer = "";
	int size = getTableSize(table);
	for (int i = 0; i < size; ++i)
	{
		answer += listToString(table->buckets[i]);
	}
	return answer;
}

List *getBucket(HashTable *table,int number)
{
	return &table->buckets[number];
}