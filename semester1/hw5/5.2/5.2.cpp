#include "pch.h"
#include <iostream>
#include <locale.h>
#include "CircleList.h"

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так !";
	}
    cout << "Введите кол-во воинов и количество шагов до убийства: ";
	int m = 0;
	int n = 0;
	cin >> m >> n;
	Node *head = circleList(m);
	cout << deleteNode(&head, n);
	return 0;
}

bool tests()
{
	Node *head = nullptr;
	const int SIZE = 5;
	int ems[5]{ 8,15,7,4,11 };
	int ens[5]{ 1,3,2,7,5 };
	int answers[5]{ 8,5,7,2,8 };
	for (int i = 0; i < SIZE; i++)
	{
		Node *head = circleList(ems[i]);
		if (deleteNode(&head, ens[i]) != answers[i])
		{
			return true;
		}
	}
	return false;
}