#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

int recursFib(const int n);
int iterFib(const int number = 45);
void recursFibHelper();
int test();

bool main()
{
	printf("Please wait, tests passing\n");
	if (test() == 0)
	{
		printf("Tests passed successfully !\n<--------------------------------------------------------------->\n");
	}
	else
	{
		printf("ERROR! Something went wrong\n");
		return 1;
	}
	int choose = ' ';
	printf("Input 1 to choose recursive algorithm\nInput 2 to choose iterative algorithm ");
	scanf("%c", &choose);
	if (choose == '2')
	{
		iterFib();
	}
	if (choose == '1')
	{
		recursFibHelper();
	}
}

int recursFib(const int n)
{
	if (n == 0)
	{
		printf("ERROR! Input valid number");
		return 0;
	}
	if (n < 0)
	{
		printf("ERROR! Input valid number");
		return -1;
	}
	if (n < 2)
	{
		return 1;
	}
	return recursFib(n - 1) + recursFib(n - 2);
}

int iterFib(const int number)
{
	 if (number == 0)
	 {
		 printf("ERROR! Input valid number ");
		 return 0;
	 }
	 if (number < 0)
	 {
		 printf("ERROR! Input valid number ");
		 return -1;
	 }
	unsigned int first = 0;
	unsigned int second = 0;
	unsigned int toReturn = 1;
	for (int i = 1;; i++)
	{
		printf("%i ", toReturn);
		if (i == number)
		{
			return toReturn;
		}
		first = second;
		second = toReturn;
		toReturn = first + second;
	}
}

void recursFibHelper()
{
	for (int i = 0;; i++)
	{
		printf("%i ", recursFib(i));
	}
}

bool test()
{
	int datas[]{-1,0,1,5,-5,14};
	int answers[]{ -1,0,1,5,-1,377 };
	for (int i = 0; i < 6; i++)
	{
		if (recursFib(datas[i]) != answers[i])
		{
			return 1;
		}
		if (iterFib(datas[i]) != answers[i])
		{
			return 1;
		}
	}
	printf("\n\n");
	return 0;
}