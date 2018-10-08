#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h> 

void fillArray(int data[], const int size);
void swap(int &first, int &second);
void printArray(int data[], const int size);
void doingWork(int data[], const int size);
bool tests();

int main()
{
	if (!tests())
	{
		printf("\nSomething went wrong !!\n");
		return 1;
	}
	srand(time(NULL));
	int size = 0;
	printf("Please enter array size");
	scanf("%i", &size);
	int *data = new int[size] {};
	fillArray(data, size);
	printArray(data, size);
	doingWork(data, size);
	printArray(data, size);
	delete[] data;
}

void fillArray(int data[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		data[i] = rand();
	}
}

void swap(int & first, int & second)
{
	int temp = first;
	first = second;
	second = temp;
}

void printArray(int data[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%i ", data[i]);
	}
	printf("\n \n");
}

void doingWork(int data[], const int size)
{
	int number = data[0];
	int ptrRight = size - 1;
	int ptrLeft = 0;
	while (ptrRight != ptrLeft)
	{
		while (data[ptrLeft] < number && ptrRight > ptrLeft)
		{
			ptrLeft++;
		}
		while (data[ptrRight] >= number && ptrRight > ptrLeft)
		{
			ptrRight--;
		}
		swap(data[ptrLeft], data[ptrRight]);
	}
}
bool tests()
{
	srand(time(NULL));
	const int SIZE = 10;
	for (int i = 0; i < 10; i++)
	{
		int data[SIZE];
		fillArray(data, SIZE);
		int number = data[0];
		doingWork(data, SIZE);
		i = 0;
		while (data[i] < number)
		{
			i++;
		}
		while (data[i] >= number && i < SIZE)
		{
			i++;
		}
		return (i == SIZE);
	}
}