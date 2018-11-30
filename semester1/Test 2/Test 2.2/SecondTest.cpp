#include "pch.h"
#include <iostream>
#include <fstream>
#include <iostream>
#include "List.h"
#include <locale.h>

using namespace std;

bool check(List *list);
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
	ifstream file("file.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файл не найден !" << endl;
		return 1;
	}
	int number = 0;
	while (!file.eof())
	{
		file >> number;
		addNode(list, number);
	}
	if (check(list))
	{
		cout << "Симметричен";
	}
	else
	{
		cout << "Не симментричен";
	}
	deleteList(list);
}

bool check(List *list)
{
	Node *leftArrow = list->head;
	Node *rightArrow = list->tail;
	while (leftArrow->mark < rightArrow->mark)
	{
		if (leftArrow->value != rightArrow->value)
		{
			return false;
		}
		leftArrow = leftArrow->rightPointer;
		rightArrow = rightArrow->leftPointer;
	}
	return true;
}


bool tests()
{
	const int SIZE = 5;
	int data[5][6]{ { 1, 2, 3, 3, 2, 1 }, { 1, 2, 3, 4, 2, 1 }, { 1, 2, 3, 3, 3, 3 }, {0,0,0,0,0,0}, {1,2,3,4,5,6} };
	bool answers[5]{ true, false, false, true, false };
	List* list = new List;
	for (int i = 0; i < SIZE; i++)
	{
		for (int j = 0; j < SIZE + 1; j++)
		{
			addNode(list, data[i][j]);
		}
		if (check(list) != answers[i])
		{
			delete list;
			return true;
		}
		deleteList(list);
	}
	return false;
}