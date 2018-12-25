#include "pch.h"
#include <iostream>
#include "Tree.h"
#include <locale.h>
#include <string>

bool tests();

using namespace std;

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так !";
		return 1;
	}
	Tree *tree = createTree();
	char choose = ' ';
	while (choose != '0')
	{
		cout << "Введите 0, чтобы выйти " << endl;
		cout << "Введите 1, чтобы добавить значение " << endl;
		cout << "Введите 2, чтобы получить значение по заданному ключу " << endl;
		cout << "Введите 3, чтобы проверить наличие заданного ключа " << endl;
		cout << "Введите 4, чтобы удалить элемент по заданному ключу " << endl << endl;
		cin >> choose;
		switch (choose)
		{
		case '0':
		{
			deleteTree(tree);
			continue;
		}
		case '1':
		{
			string data = " ";
			int key = -1;
			cout << "Введите строку " << endl;
			cin >> data;
			cout << "Введите ключ " << endl;
			cin >> key;
			addNode(tree, data, key);
			break;
		}
		case '2':
		{
			cout << "Введите ключ " << endl;
			int key = -1;
			cin >> key;
			cout << findStringByKey(tree, key);
			continue;
		}
		case '3':
		{
			int key = -1;
			cout << "Введите ключ " << endl;
			cin >> key;
			if (exists(tree, key))
			{
				cout << "Существует " << endl;
			}
			else
			{
				cout << "Не существует " << endl;
			}
			continue;
		}
		case '4':
		{
			int key = -1;
			cin >> key;
			remove(tree, key);
			continue;
		}
		}
	}
	return 0;
}

bool tests()
{
	Tree *tree = createTree();
	int addKeys[]{ 1, 5, -5, -2, -8, -7, 43, -13, 4, -7, -2 };
	string addValues[]{ "Well", "some", "tests", "value1", "this", "is", "a", "string", "hope", "it", "value2" };
	int removes[]{ 1, -8, 43, 5, -13, 5 };
	string checks[]{ "", "", "tests", "value2", "", "it", "", "", "hope", "it", "value2" };
	for (int i = 0; i < 11; i++)
	{
		addNode(tree, addValues[i], addKeys[i]);
	}
	for (int i = 0; i < 6; i++)
	{
		remove(tree, removes[i]);
	}
	for (int i = 0; i < 11; i++)
	{
		if (findStringByKey(tree,addKeys[i]) != checks[i])
		{
			deleteTree(tree);
			return 1;
		}
	}
	deleteTree(tree);
	return 0;
}