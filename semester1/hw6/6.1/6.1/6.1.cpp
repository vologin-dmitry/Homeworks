#include "pch.h"
#include <string>
#include <string.h>
#include <iostream>
#include "Stack.h"
#include <stdio.h>
#include <locale.h>
#include <stdlib.h>

using namespace std;

bool popAndCheck(Stack &stack, int &firstNumber, int &secondNumber);
int countThis(string data, Stack stack);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		printf("Что то пошло не так !");
		return 1;
	}
	Stack* stack = new Stack;
	string data = " ";
	cout << "Введите строку" << endl;
	getline(cin, data);
	data += '\n';
	cout << countThis(data, *stack);
	deleteStack(*stack);
	delete stack;
	return 0;
}

int countThis(string data, Stack stack)
{
	int i = 0;
	bool result = false;
	int firstNumber = 0;
	int secondNumber = 0;

	while (data[i] != '\n')
	{
		switch (data[i])
		{
		case '+':
		{

			if (popAndCheck(stack, firstNumber, secondNumber))
			{
				push(stack, firstNumber + secondNumber);
			}
			else
			{
				cout << "Что то пошло не так ! Проверьте введенный значения";
				return 1;
			}
			i++;
			continue;
		}
		case '-':
		{
			if (popAndCheck(stack, firstNumber, secondNumber))
			{
				push(stack, firstNumber - secondNumber);
			}
			else
			{
				cout << "Что то пошло не так ! Проверьте введенный значения";
				return 1;
			}
			i++;
			continue;
		}
		case '*':
		{
			if (popAndCheck(stack, firstNumber, secondNumber))
			{
				push(stack, firstNumber * secondNumber);
			}
			else
			{
				cout << "Что то пошло не так ! Проверьте введенный значения";
				return 1;
			}
			i++;
			continue;
		}
		case '/':
		{
			if (popAndCheck(stack, firstNumber, secondNumber))
			{
				push(stack, firstNumber / secondNumber);
			}
			else
			{
				cout << "Что то пошло не так ! Проверьте введенный значения";
				return 1;
			}
			i++;
			continue;
		}
		default:
		{
			if (isdigit(data[i]))
			{
				push(stack, atoi(&data[i]));
				while (isdigit(data[i + 1]))
				{
					i++;
				}
			}
		}
		}
		i++;
	}
	return stack.head->data;
}

bool popAndCheck(Stack &stack, int &firstNumber, int &secondNumber)
{
	bool result = false;
	secondNumber = pop(stack, result);
	if (result)
	{
		firstNumber = pop(stack, result);
	}
	return result;
}

bool tests()
{
	const int SIZE = 5;
	Stack *stack = new Stack;
	string data[5]{ { "0 0 +\n" }, { "5 5 6 + *\n" }, { "5 4 * 4 5 - /\n" }, { "51 3 -\n" }, { "9 6 - 1 2 + * \n" } };
	int answers[5]{ 0, 55, -20, 48, 9 };
	for (int i = 0; i < SIZE; i++)
	{
		if (countThis(data[i], *stack) != answers[i])
		{
			deleteStack(*stack);
			delete stack;
			return 1;
		}
	}
	deleteStack(*stack);
	delete stack;
	return 0;
}