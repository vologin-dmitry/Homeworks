#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>
#include "List.h"
#include <locale.h>

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так!";
		return 1;
	}
	fstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Пожалуйста добавьте файл \n";
	}
	string temp = "";
	List list;
	while (!file.eof())
	{
		getline(file, temp);
		addNode(&list, temp);
	}
	file.close();
	deleteRepeating(&list);
	cout << "Список без повторений:\n";
	printList(list);
	clear(list.head);
}

bool tests()
{
	const int SIZE = 7;
	fstream file("test.txt", ios::in);
	if (!file.is_open())
	{
		return 1;
	}
	string temp = "";
	List test;
	string answers[SIZE]{ "man", "fox", "returning", "bee", "keyboard", "f12", "dontknow" };
	while (!file.eof())
	{
		getline(file, temp);
		addNode(&test, temp);
	}
	file.close();
	deleteRepeating(&test);
	Node *current = test.head;
	for (int i = 0; i < SIZE; i++)
	{
		if (answers[i] != current->data)
		{
			clear(test.head);
			return 1;
		}
		current = current->next;
	}
	clear(test.head);
	return 0;
}