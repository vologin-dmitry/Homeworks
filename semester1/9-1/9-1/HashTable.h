#pragma once
#include <vector>
#include <string>
#include "List.h"

struct HashTable;

HashTable *createHashTable();
void add(HashTable *&table, std::string const & toAdd);
void clearTable(HashTable *&table);
int getTableSize(HashTable *table);
std::string tableToString(HashTable *table);
List *getBucket(HashTable *table, int number);