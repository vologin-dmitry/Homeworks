#include "pch.h"
#include <iostream>
#include "MergeSort.h"
#include "List.h"
#include <string>
#include <fstream>
#include <locale.h>

using namespace std;

void fillList(List *list, ifstream &file);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так !!\n";
		return 1;
	}
	ifstream file("input.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Ошибка ! Проверьте наличие входного файла !\n";
		return 1;
	}
	List list;
	char choose = ' ';
	cout << "Введите 1, чтобы отсортировать по именам\n";
	cout << "Введите 2, чтобы отсортировать по номерам\n";
	cin >> choose;
	fillList(&list, file);
	file.close();
	list.head = sort(list.head, choose);
	printList(list);
	clear(list.head);
}

bool tests()
{
	const int SIZE = 5;
	ifstream file("test.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Ошибка ! Проверьте наличие входного тестового файла !\n";
		return 1;
	}
	string answers[2][SIZE]{ { "Bill", "Gherohn", "Joe", "Newbie" , "Thom" }, { "Gherohn", "Thom", "Bill", "Newbie", "Joe" } };
	List list;
	fillList(&list, file);
	list.head = sort(list.head, '1');
	for (int j = 0; j < 2; ++j)
	{
		Node *current = list.head;
		for (int i = 0; i < SIZE; ++i)
		{
			if (current->name != answers[j][i])
			{
				clear(list.head);
				file.close();
				return 1;
			}
			current = current->next;
		}
		list.head = sort(list.head, '2');
	}
	clear(list.head);
	file.close();
	return 0;
}

void fillList(List *list, ifstream &file)
{
	string temp = "";
	string temp2 = "";
	while (!file.eof())
	{
		file >> temp;
		file >> temp2;
		addNode(list, temp, temp2);
	}
}