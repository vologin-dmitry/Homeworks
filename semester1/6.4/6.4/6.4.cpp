#include "pch.h"
#include <iostream>
#include "MergeSort.h"
#include "List.h"
#include <string>
#include <fstream>
#include <locale.h>

using namespace std;

void fillList(Node *&head, ifstream &file);
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
	Node *head = createList();
	char choose = ' ';
	cout << "Введите 1, чтобы отсортировать по именам\n";
	cout << "Введите 2, чтобы отсортировать по номерам\n";
	//cin >> choose;
	fillList(head, file);
	file.close();
	sort(head, '1');
	printList(head);
	clear(head);
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
	Node *head = createList();
	fillList(head, file);
	sort(head, '1');
	for (int j = 0; j < 2; ++j)
	{
		Node *current = head;
		for (int i = 0; i < SIZE; ++i)
		{
			if (getName(current) != answers[j][i])
			{
				clear(head);
				file.close();
				return 1;
			}
			current = getNext(current);
		}
		sort(head, '2');
	}
	clear(head);
	file.close();
	return 0;
}

void fillList(Node *&head, ifstream &file)
{
	string temp = "";
	string temp2 = "";
	while (!file.eof())
	{
		file >> temp;
		file >> temp2;
		addNode(head, temp, temp2);
	}
}