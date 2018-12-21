#include "pch.h"
#include "HashTable.h"
#include "List.h"
#include <iostream>
#include <fstream>
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
	int size = table.buckets.size();
	for (int i = 0; i < size; ++i)
	{
		if (!(isEmpty(table.buckets[i])))
		{
			Node *current = table.buckets[i].head;
			while (current != nullptr)
			{
				answer += current->value + "\t" + to_string(current->count) + "\n";
				current = current->next;
			}
		}
	}
	return answer;
}

int notEmptyBuckets(HashTable table)
{
	int count = 0;
	int size = table.buckets.size();
	for (int i = 0; i < size; ++i)
	{
		if (!isEmpty(table.buckets[i]))
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
		if (getLength(table.buckets[i].head) > max)
		{
			max = getLength(table.buckets[i].head);
		}
	}
	return max;
}

int allListSizeSum(HashTable table)
{
	int sum = 0;
	for (int i = 0; i < table.buckets.size(); ++i)
	{
		sum += getLength(table.buckets[i].head);
	}
	return sum;
}

void statistic(HashTable table)
{
	int notEmpty = notEmptyBuckets(table);
	cout << endl << endl;
	cout << "Коэффициент заполнения хэш-таблицы: " << ((double)notEmpty / table.buckets.size()) << endl;
	cout << "Максимальная длина списка: " << maxListSize(table) << endl;
	cout << "Средняя длина списка: " << ((double)allListSizeSum(table) / notEmpty);
	cout << endl << endl;
}

bool tests()
{
	HashTable test;
	string answer = "проверяет\t2\nДля\t1\nзадача\t1\nнаписать\t1\nзадачи\t1\nне\t1\nзадачу\t1\nнужно\t1\nтест\t3\n";
	constructor(test);
	ifstream file("FileToTest.txt", ios::in);
	countWords(test, file);
	if (hashToString(test) != answer || allListSizeSum(test) != 9 || maxListSize(test) != 2)
	{
		file.close();
		return 1;
	}
	file.close();
	return 0;
}