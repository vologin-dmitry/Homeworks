#include "pch.h"
#include "List.h"
#include <iostream>

using namespace std;

bool tests();

int main()
{
	List list;
	if (tests())
	{
		cout << "Something went wrong !\n";
		return 1;
	}
	int choose = -1;
	while (choose != 0)
	{
		cin >> choose;
		cout << "Input 1 to add node\n";
		cout << "Input 2 to delete node\n";
		cout << "Input 3 to print list\n";
		cout << "Input 0 to exit";
		switch (choose)
		{
		case 1:
		{
			cout << "Please input value and its position\n";
			int value = -1;
			int position = -1;
			cin >> value >> position;
			addNode(&list, value, position);
			continue;
		}
		case 2:
		{
			cout << "Please input position of element to delete\n";
			int position = -1;
			cin >> position;
			deleteNode(&list, position);
			continue;
		}
		case 3:
		{
			cout << endl;
			printList(list);
			continue;
		}
		case 0:
		{
			deleteList(&list);
			break;
		}
		}
	}
	return 0;
}

bool tests()
{
	int adds[8]{ 3, 4, 0, 124, 463, 67, -5, 14 };
	int positions[8]{ 0, 1, 0, 2, 3, 0, 1, 4 };
	int answers[5]{ -5, 0, 3, 124, 463 };
	int removes[3]{ 0, 6, 3 };
	List test;
	for (int i = 0; i < 8; i++)
	{
		addNode(&test, adds[i], positions[i]);
	}
	for (int i = 0; i < 3; i++)
	{
		deleteNode(&test, removes[i]);
	}
	int i = 0;
	Node *current = test.head;
	while (i < 5)
	{
		if (current->value != answers[i])
		{
			deleteList(&test);
			return 1;
		}
		++i;
		current = current->rightPointer;
	}
	return 0;
}
