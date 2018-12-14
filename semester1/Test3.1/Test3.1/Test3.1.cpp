#include "pch.h"
#include "List.h"
#include <locale.h>
#include <iostream>
#include <fstream>

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так !";
		return 1;
	}
	List* list = new List;
	ifstream file("FileToWork.txt", ios::in);
	if (!file.is_open())
	{
		delete list;
		cout << "Файл не найден !" << endl;
		return 1;
	}
	int number = -1;
	while (!file.eof())
	{
		file >> number;
		addNode(list, number);
	}
	listRotate(list);
	deleteList(list);
	delete list;
	return 0;
}

bool tests()
{
	List* list = new List;
	int adds[5]{ 5, 2, 4, 6, 8 };
	for (int i = 0; i < 5; i++)
	{
		addNode(list, adds[i]);
	}
	listRotate(list);
	Node *current = list->head;
	for(int i = 0; i < 5; i++)
	{
		if (current->value != adds[4 - i])
		{
			deleteList(list);
			delete list;
			return 1;
		}
		current = current->next;
	}
	deleteList(list);
	delete list;
	return 0;
}