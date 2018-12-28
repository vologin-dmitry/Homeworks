#include "pch.h"
#include <iostream>
#include <locale.h>
#include <fstream>
#include <locale.h>

using namespace std;

const int SIZE = 24;

void readFile(ifstream &file, int *counter);
int maximal(int *counter);

int main()
{
	setlocale(LC_ALL, "russian");
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файла не существует !";
		return 1;
	}
	int counter[SIZE]{};
	readFile(file, counter);
	file.close();
	int max = maximal(counter);
	if (max == -1)
	{
		cout << "Неправильные входные данные !!";
		return 1;
	}
	cout << "Максимальное число посетителей было в период с " << max << " по " << max + 1 << " часов";
}

void readFile(ifstream &file, int *counter)
{
	int hourStart = -1;
	int minStart = -1;
	int hourEnd = -1;
	int minEnd = -1;
	while (!file.eof())
	{
		file >> hourStart >> minStart >> hourEnd >> minEnd;
		for (int i = hourStart; i <= hourEnd; ++i)
		{
			++counter[i];
		}
	}

}

int maximal(int *counter)
{
	int max = -1;
	int maxIndex = -1;
	for (int i = 0; i < SIZE; ++i)
	{
		if (counter[i] > max)
		{
			max = counter[i];
			maxIndex = i;
		}
	}
	if (max == -1)
	{
		return -1;
	}
	return maxIndex;
}