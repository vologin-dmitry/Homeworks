#include "pch.h"
#include <iostream>
#include <locale.h>
#include "CircleList.h"

using namespace std;

int killThem(Node **head, int stepsCounter);
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
	Node *head = createSquad(m);
	cout << killThem(&head, n);
	return 0;
}


int killThem(Node **head, int stepsCounter)
{
	Node *current = *head;
	Node *parent = current;
	while (parent->next != current)
	{
		parent = parent->next;
	}
	while (current->next != parent)
	{
		for (int i = 1; i < stepsCounter; i++)
		{
			parent = current;
			current = current->next;
		}
		if (current == *head)
		{
			*head = current->next;
		}
		parent->next = current->next;
		delete current;
		current = parent->next;
	}
	if (stepsCounter % 2 == 0)
	{
		delete parent;
		int toReturn = current->number;
		delete current;
		return toReturn;
	}
	else
	{
		delete current;
		int toReturn = parent->number;
		delete parent;
		return toReturn;
	}
}

bool tests()
{
	Node *head = nullptr;
	const int SIZE = 5;
	int peopleNumber[5]{ 8, 15, 7, 4, 11 };
	int diesEvery[5]{ 1, 3, 2, 7, 5 };
	int answers[5]{ 8, 5, 7, 2, 8 };
	for (int i = 0; i < SIZE; i++)
	{
		Node *head = createSquad(peopleNumber[i]);
		if (killThem(&head, diesEvery[i]) != answers[i])
		{
			return true;
		}
	}
	return false;
}