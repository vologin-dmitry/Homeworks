#define _CRT_SECURE_NO_WARNINGS

#include "pch.h"
#include <stdlib.h>
#include <stdio.h>
#include <locale.h>

void encode(int number, int binary[]);
void additionalCode(int number, int additional[]);
void binaryCode(int number, int binary[]);
void printArray(int *data, int size);
int *binarySum(int data1[], int data2[]);
int decimalTranslation(int *data);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		printf("Что то пошло не так !\n");
		return 1;
	}
	const int SIZE = 32;
	int number1 = 0;
	int number2 = 0;
	printf("Введите числа ");
	scanf("%i %i", &number1, &number2);
	int data1[SIZE]{};
	int data2[SIZE]{};
	encode(number1, data1);
	encode(number2, data2);
	printf("Первый массив: \n");
	printArray(data1, SIZE);
	printf("Второй массив: \n");
	printArray(data2, SIZE);
	printf("Сумма в двоичном виде: \n");
	binarySum(data1, data2);
	printArray(data1, SIZE);
	printf("Сумма в десятичном виде: \n");
	printf("%i", decimalTranslation(data1));
}

void binaryCode(int number, int binary[])
{
	number = abs(number);
	for (int i = 0; i < 32; i++)
	{
		if (number % 2 == 0)
		{
			binary[i] = 0;
			number /= 2;

		}
		else
		{
			binary[i] = 1;
			number--;
			number /= 2;
		}
	}
}

void additionalCode(int number, int additional[])
{
	binaryCode(number, additional);
	for (int i = 0; i < 32; i++)
	{
		additional[i] == 1 ? additional[i] = 0 : additional[i] = 1;
	}
	int one[32]{};
	one[0] = 1;
	binarySum(additional, one);
	if (additional[31] > 1)
	{
		additional[31] -= 2;
	}
}

void encode(int number, int binary[])
{
	if (number >= 0)
	{
		binaryCode(number, binary);
	}
	else
	{
		additionalCode(number, binary);
	}
}

void printArray(int *data, int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%i", data[size - i - 1]);
	}
	printf("\n");
}

int *binarySum(int data1[], int data2[])
{
	for (int i = 0; i < 31; i++)
	{
		data1[i] += data2[i];
		if (data1[i] > 1)
		{
			data1[i + 1]++;
			data1[i] -= 2;
		}
	}
	data1[31] += data2[31];
	if (data1[31] > 1)
	{
		data1[31] -= 2;
	}
	return data1;
}

int decimalTranslation(int *data)
{
	int answer = 0;
	int power = 1;
	int oneInThisCase = 1;
	if (data[31] == 1)
	{
		oneInThisCase = 0;
		power = -1;
	}
	for (int i = 0; i < 31; i++)
	{
		if (data[i] == oneInThisCase)
		{
			answer = answer + power;
		}
		power *= 2;
	}
	if (data[31] == 1)
	{
		answer--;
	}
	return answer;
}

bool tests()
{
	int binary1[32];
	int binary2[32];
	const int SIZE = 5;
	int firstNumber[SIZE]{ 0,1,5,0,128 };
	int secondNumber[SIZE]{ 0,-1,-8,-5, 0 };
	int answers[SIZE]{ 0,0,-3,-5,128 };
	for (int i = 0; i < SIZE; i++)
	{
		encode(firstNumber[i], binary1);
		encode(secondNumber[i], binary2);
		if (decimalTranslation(binarySum(binary1, binary2)) != answers[i])
		{
			return true;
		}
	}
	return false;
}
