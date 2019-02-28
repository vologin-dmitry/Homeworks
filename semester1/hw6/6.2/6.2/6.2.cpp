#include "pch.h"
#include <string>
#include <iostream>
#include "Stack.h"
#include <stdio.h>
#include <locale.h>
#include <stdlib.h>

using namespace std;

bool parenthesesCheck(string data, Stack *stack);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		printf("Что то пошло не так !");
		return 1;
	}
	Stack *stack = createStack();
	string data = " ";
	cout << "Введите строку" << endl;
	getline(cin, data);
	data += '\n';
	if (parenthesesCheck(data, stack))
	{
		cout << "Баланс скобок соблюден" << endl;
	}
	else
	{
		cout << "Баланс скобок не соблюден" << endl;
	}
	deleteStack(stack);
	delete stack;
	return 0;
}

bool parenthesesCheck(string data, Stack *stack)
{
	int i = 0;
	while (data[i] != '\n')
	{
		bool result = false;
		char letter = ' ';
		if (data[i] == '{' || data[i] == '(' || data[i] == '[')
		{
			push(stack, data[i]);
		}
		if (data[i] == '}' || data[i] == ')' || data[i] == ']')
		{
			letter = pop(stack, result);
			if (result == false || (data[i] != letter + 1 && data[i] != letter + 2))
			{
				return false;
			}
		}
		i++;
	}
	if (isEmpty(stack))
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool tests()
{
	const int SIZE = 5;
	string datas[SIZE]{ "{не}[л(пис[тесты]ать)юблю](вот)\n", "{(Не){знаю что (написать)]\n", "{{]}\n", "{[]}\n", "(Вау) {Да [она] видимо} [работает]\n" };
	bool answers[SIZE]{ true, false, false, true, true };
	for (int i = 0; i < SIZE; i++)
	{
		Stack *stack = createStack();
		if (parenthesesCheck(datas[i], stack) != answers[i])
		{
			deleteStack(stack);
			delete stack;
			return true;
		}
		deleteStack(stack);
		delete stack;
	}
	return false;
}