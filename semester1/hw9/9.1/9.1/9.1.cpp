#include "pch.h"
#include <iostream>
#include "HashTable.h"
#include <fstream>
#include <string>
#include <locale.h>

using namespace std;

void countWords(HashTable &table, ifstream &file);
string hashToString(HashTable table);
int notEmptyBuckets(HashTable table);
int maxListSize(HashTable table);
int allListSizeSum(HashTable table);
void statistic(HashTable table);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так";
		return 1;
	}
	HashTable table;
	constructor(table);
	ifstream file("FileToWork.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файла не существет";
		return 1;
	}
	countWords(table, file);
	cout << hashToString(table);
	statistic(table);
	file.close();
	return 0;
}

void countWords(HashTable &table, ifstream &file)
{
	string temp = "";
	while (!file.eof())
	{
		file >> temp;
		add(table, temp);
	}
}

string hashToString(HashTable table)
{
	string answer = "";
	for (int i = 0; i < table.buckets.size(); i++)
	{
		if (!table.buckets[i].empty())
		{
			list<Node>::iterator current = table.buckets[i].begin();
			while (current != table.buckets[i].end())
			{
				answer += current->value + "\t" + to_string(current->count) + "\n";
				++current;
			}
		}
	}
	return answer;
}

int notEmptyBuckets(HashTable table)
{
	int count = 0;
	for (int i = 0; i < table.buckets.size(); ++i)
	{
		if (!table.buckets[i].empty())
		{
			++count;
		}
	}
	return count;
}

int maxListSize(HashTable table)
{
	unsigned int max = 0;
	for (int i = 0; i < table.buckets.size(); ++i)
	{
		if (table.buckets[i].size() > max)
		{
			max = table.buckets[i].size();
		}
	}
	return max;
}

int allListSizeSum(HashTable table)
{
	int sum = 0;
	for (int i = 0; i < table.buckets.size(); ++i)
	{
		sum += table.buckets[i].size();
	}
	return sum;
}

void statistic(HashTable table)
{
	int notEmpty = notEmptyBuckets(table);
	cout << endl << endl;
	cout << "Коэффициент заполнения хэш-таблицы: " << ((double) notEmpty / table.buckets.size()) << endl;
	cout << "Максимальная длина списка: " << maxListSize(table) << endl;
	cout << "Средняя длина списка: " << ((double) allListSizeSum(table) / notEmpty);
	cout << endl << endl;
}

bool tests()
{
	HashTable test;
	string answer = "нужно\t1\nтест\t3\nпроверяет\t2\nДля\t1\nзадача\t1\nнаписать\t1\nзадачи\t1\nне\t1\nзадачу\t1\n";
	constructor(test);
	ifstream file("FileToTest.txt", ios::in);
	countWords(test, file);
	string maybe = hashToString(test);
	if (hashToString(test) != answer || allListSizeSum(test) != 9 || maxListSize(test) != 2)
	{
		file.close();
		return 1;
	}
	file.close();
	return 0;
}