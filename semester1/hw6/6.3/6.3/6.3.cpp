#include "pch.h"
#include <iostream>
#include <string>
#include <locale.h>
#include "Stack.h"

using namespace std;

string transform(string data);
bool tests();

int main()
{
	if (tests())
	{
		cout << "Что то пошло не так !\n";
		return 1;
	}
	setlocale(LC_ALL, "russian");
	cout << "Введите строку \n";
	string data = "";
	getline(cin, data);
	data += "\n";
	cout << transform(data);
}

string transform(string data)
{
	string answer = "";
	Stack stack;
	int i = 0;
	while (true)
	{
		if (data[i] == ' ')
		{
			++i;
			continue;
		}
		char previous = stackTop(stack);
		if (isdigit(data[i]))
		{
			while (isdigit(data[i]))
			{
				answer += data[i];
				++i;
			}
			answer += ' ';
			continue;
		}
		else if (data[i] == '+' || data[i] == '-')
		{
			if (previous == '+' || previous == '-' || previous == '*' || previous == '/')
			{
				pop(stack);
				answer = answer + previous + " ";
				continue;
			}
			else if (previous == '\n' || previous == '(')
			{
				push(stack,data[i]);
			}
		}
		else if (data[i] == '*'|| data[i] == '/')
		{
			if (previous == '\n' || previous == '+' || previous == '-' || previous == '(')
			{
				push(stack, data[i]);
			}
			else if (previous == '*' || previous == '/')
			{
				pop(stack);
				answer = answer + previous + " ";
				continue;
			}
		}
		else if (data[i] == '(')
		{
			push(stack, data[i]);
		}
		else if (data[i] == ')')
		{
			if (previous == '+' || previous == '-' || previous == '*' || previous == '/')
			{
				pop(stack);
				answer = answer + previous + " ";
				continue;
			}
			else if (previous == '(')
			{
				pop(stack);
			}
			else if (previous == '\n')
			{
				return "Ошибка ! Проверьте правильность введённой строки";
			}
		}
		else if (data[i] == '\n')
		{
			if (previous == '+' || previous == '-' || previous == '*' || previous == '/')
			{
				pop(stack);
				answer = answer + previous + " ";
				continue;
			}
			else if (previous == '(')
			{
				return "Ошибка ! Проверьте правильность введённой строки";
			}
			else if (previous == '\n')
			{
				return answer;
			}
		}
		else
		{
			return "Ошибка ! Проверьте правильность введённой строки";
		}
		++i;
	}
}

bool tests()
{
	const int SIZE = 5;
	string datas[SIZE] = { "(1 + 1) * 2 \n", "dwafaf\n", "1 + 5 * 4\n", "(1 + 5) * )6 + 4)\n", "(1 + 6) * (7 + 4)\n" };
	string answers[SIZE] = { "1 1 + 2 * ", "Ошибка ! Проверьте правильность введённой строки", "1 5 4 * + ", "Ошибка ! Проверьте правильность введённой строки", "1 6 + 7 4 + * " };
	for (int i = 0; i < SIZE; i++)
	{
		if (transform(datas[i]) != answers[i])
		{
			return 1;
		}
	}
	return 0;
}