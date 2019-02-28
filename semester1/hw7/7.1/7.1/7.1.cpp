#include "pch.h"
#include "Tree.h"
#include <iostream>
#include <locale.h>

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
	char choose = ' ';
	Tree *tree = createTree();
	while (choose != '0')
	{
		cout << "Введите 0, чтобы выйти" << endl;
		cout << "Введите 1, чтобы добавить значение" << endl;
		cout << "Введите 2, чтобы удалить значение" << endl;
		cout << "Введите 3, чтобы проверить, принадлежит ли значение множеству" << endl;
		cout << "Введите 4, чтобы распечатать множество в возрастающем порядке" << endl;
		cout << "Введите 5, чтобы распечатать множество в убывающем порядке" << endl;
		cin >> choose;
		switch (choose)
		{
		case '1':
		{
			int number = 0;
			cout << "Введите добавляемое число" << endl;
			cin >> number;
			add(tree, number);
			continue;
		}
		case '2':
		{
			int number = 0;
			cout << "Введите удаляемое число" << endl;
			cin >> number;
			remove(tree, number);
			continue;
		}
		case '3':
		{
			int number = 0;
			cout << "Введите число" << endl;
			cin >> number;
			if (exists(tree, number))
			{
				cout << "Элемент существует" << endl;
			}
			else
			{
				cout << "Такого элемента нет" << endl;
			}
			continue;
		}
		case '4':
		{
			printTreeIncreasing(tree);
			cout << endl;
			continue;
		}
		case '5':
		{
			printTreeDecreasing(tree);
			cout << endl;
			continue;
		}
		default:
			continue;
		}
	}
	deleteTree(tree);
	return 0;
}

bool tests()
{
	Tree *tree = createTree();
	int adds[]{ 1, 5, -5, -8, -7, 43, -13, 4, -7, -2, -2 };
	int removes[]{ 1, -8, 43, 5, - 2, 5 };
	int checks[]{ false, false, true, false, true, false, true, true, true, false, false };
	for (int i = 0; i < 11; i++)
	{
		add(tree, adds[i]);
	}
	for (int i = 0; i < 6; i++)
	{
		remove(tree, removes[i]);
	}
	for (int i = 0; i < 6; i++)
	{
		if (exists(tree, adds[i]) != checks[i])
		{
			deleteTree(tree);
			return 1;
		}
	}
	deleteTree(tree);
	return 0;
}