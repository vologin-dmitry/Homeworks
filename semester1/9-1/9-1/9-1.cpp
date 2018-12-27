#include "pch.h"
#include "HashTable.h"
#include "List.h"
#include <iostream>
#include <fstream>
#include <locale.h>

using namespace std;

void countWords(HashTable *&table, ifstream &file);
int notEmptyBuckets(HashTable *table);
int maxListSize(HashTable *table);
int allListSizeSum(HashTable *table);
void statistic(HashTable *table);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так";
		return 1;
	}
	HashTable *table = createHashTable();
	ifstream file("FileToWork.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файла не существет";
		return 1;
	}
	countWords(table, file);
	cout << tableToString(table);
	statistic(table);
	file.close();
	clearTable(table);
	return 0;
}

void countWords(HashTable *&table, ifstream &file)
{
	string temp = "";
	while (!file.eof())
	{
		file >> temp;
		add(table, temp);
	}
}

int notEmptyBuckets(HashTable *table)
{
	int count = 0;
	int size = getTableSize(table);
	for (int i = 0; i < size; ++i)
	{
		if (!isEmpty(*getBucket(table, i)))
		{
			++count;
		}
	}
	return count;
}

int maxListSize(HashTable *table)
{
	unsigned int max = 0;
	int size = getTableSize(table);
	for (int i = 0; i < size; ++i)
	{
		int currentLength = getLength(getBucket(table, i));
		if (currentLength > max)
		{
			max = currentLength;
		}
	}
	return max;
}

int allListSizeSum(HashTable *table)
{
	int sum = 0;
	int size = getTableSize(table);
	for (int i = 0; i < size; ++i)
	{
		sum += getLength(getBucket(table, i));
	}
	return sum;
}

void statistic(HashTable *table)
{
	int notEmpty = notEmptyBuckets(table);
	cout << endl << endl;
	cout << "Коэффициент заполнения хэш-таблицы: " << ((double)notEmpty /getTableSize(table)) << endl;
	cout << "Максимальная длина списка: " << maxListSize(table) << endl;
	cout << "Средняя длина списка: " << ((double)allListSizeSum(table) / notEmpty);
	cout << endl << endl;
}

bool tests()
{
	HashTable *test = createHashTable();
	string answer = "проверяет\t2\nДля\t1\nзадача\t1\nнаписать\t1\nзадачи\t1\nне\t1\nзадачу\t1\nнужно\t1\nтест\t3\n";
	ifstream file("FileToTest.txt", ios::in);
	countWords(test, file);
	if (hashToString(test) != answer || allListSizeSum(test) != 9 || maxListSize(test) != 2)
	{
		clearTable(test);
		file.close();
		return 1;
	}
	file.close();
	clearTable(test);
	return 0;
}