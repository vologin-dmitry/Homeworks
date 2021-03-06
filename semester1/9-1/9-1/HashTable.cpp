#include "pch.h"
#include "HashTable.h"
#include "List.h"

struct HashTable
{
	std::vector<List *> buckets;
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
	size = table->buckets.size();
	for (int i = 0; i < size; ++i)
	{
		table->buckets[i] = createList();
	}
	return table;
}


void add(HashTable *&table, std::string const & toAdd)
{
	int hash = abs((int)(hashFunction(toAdd) % getTableSize(table)));
	addToList(table->buckets[hash], toAdd);
}


void clearTable(HashTable *&table)
{
	int size = table->buckets.size();
	for (int i = 0; i < size; ++i)
	{
		clear(table->buckets[i]);
	}
	delete table;
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
	return table->buckets[number];
}