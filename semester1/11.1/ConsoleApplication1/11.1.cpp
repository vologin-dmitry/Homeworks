#include "pch.h"
#include "KMP.h"
#include <iostream>
#include <fstream>
#include <locale.h>

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так ! Тесты не прошли";
		return 1;
	}
	string line;
	string text;
	ifstream file("Text.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файла нет !\n";
		return 1;
	}
	file >> text;
	cout << "Пожалуйста введите строку, которую ищем\n";
	cin >> line;
	int result = KMPAlgorithm(line, text);
	if (result != -1)
	{
		cout << result;
	}
	else
	{
		cout << "\nПодстрока не входит в данную строку\n";
	}
	file.close();
	return 0;
}

bool tests()
{
	const int SIZE = 5;
	string texts[SIZE]{ "aaaccaba", "aaadadadddaa", "olololololol", "adadaddadada", "nonononononono" };
	string toSearch[SIZE]{ "cca", "dad", "olo", "daa", "yes" };
	int answers[SIZE]{ 4, 4, 1, -1, -1 };
	for (int i = 0; i < SIZE; ++i)
	{
		if (KMPAlgorithm(toSearch[i], texts[i]) != answers[i])
		{
			return 1;
		}
	}
	return 0;
}