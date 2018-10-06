#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

bool tests();
bool errors(const int data, const int power);
int logPow(const int data, const int power);
int iterPow(const int data, const int power);

int main()
{
	if (tests())
	{
		printf("\nSomething went wrong!!\n");
		return 1;
	}
	else
	{
		printf("\n<----------------------------->\nTests passed succesfully\n");
	}
	int data = 0;
	int power = 0;
	int choose = ' ';
	printf("Please input the data \n");
	scanf("%i",&data);
	printf("Please input the power \n");
	scanf("%i", &power);
	printf("Input 1 to choose linear exponentation\n Input 2 to choose logarithmic exponentiation\n");
	scanf("%i", &choose);
	if (choose == 1)
	{
		printf("%i ",iterPow(data, power));
	}
	if (choose == 2)
	{
		printf("%i ",logPow(data, power));
	}
}

int iterPow(const int data,const int power)
{
	if (errors(data, power))
	{
		
		return -1;
	}
	int result = 1;
	for (int i = 0; i < power; i++)
	{
		result *= data;
	}
	return result;
}

int logPow(const int data, const int power)
{
	if (errors(data, power))
	{
		return -1;
	}
	int count = 0;
	int help = power;
	while (help != 0)
	{
		help /= 2;
		count++;
	}
	help = power;
	int *binary = new int [count] {};
	for (int i = 0; help != 0; i++)
	{
		if (help % 2 == 0)
		{
			help /= 2;
			binary[i] = 0;
		}
		else
		{
			help--;
			help /= 2;
			binary[i] = 1;
		}
	}
	int answer = 1;
	for (int i = 0; i < count; i++)
	{
		if (binary[i] == 1) 
		{
			int addToAns = data;
			for (int j = 1; j <= i; j++)
			{
				addToAns *= addToAns;
			}
			answer *= addToAns;
		}
	}
	delete[] binary;
	return answer;
}

bool errors(const int data, const int power)
{
	if (data < 0 || power < 0 || data == 0 && power == 0)
	{
		printf("Please input correct data\n");
		return 1;
	}
	return 0;
}

bool tests()
{
	int datas[]{ -5,0,0,8,1,4,2,5 };
	int powers[]{ 2,4,0,-1,5,4,10,0 };
	int answers[]{ -1,0,-1,-1,1,256,1024,1 };
	for (int i = 0; i < 8; i++)
	{
		if (logPow(datas[i], powers[i]) != answers[i])
		{
			return 1;
		}
		if (iterPow(datas[i], powers[i]) != answers[i])
		{
			return 1;
		}
	}
	return 0;
}