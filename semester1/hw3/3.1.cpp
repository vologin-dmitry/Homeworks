#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void fillArray(int data[], const int size);
void swap(int &first, int &second);
void printArray(int data[], const int size);
void randArray(int data[], const int size);
void qSort(int data[], int leftWall, int rightWall);
void insSort(int data[], const int size);
int maxOf(int data1, int data2, int data3);
bool tests();

int main()
{
	if (tests())
	{
		printf("\nSomething went wrong !!\n");
		return 1;
	}
	srand(time(nullptr));
	int size = 0;
	printf("Please enter array size: ");
	scanf("%i", &size);
	int *data = new int[size] {};
	fillArray(data, size);
	(size >= 10) ? qSort(data, 0, size - 1) : insSort(data, size);
	printArray(data, size);
	delete []data;
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

void qSort(int data[], int leftWall, int rightWall)
{
	int ptrLeft = leftWall;
	int ptrRight = rightWall;
	int number = maxOf(data[ptrLeft], data[ptrRight], data[(ptrRight + ptrLeft) / 2]);
	while (ptrRight > ptrLeft)
	{
		while (data[ptrLeft] < number)
		{
			ptrLeft++;
		}
		while (data[ptrRight] >= number)
		{
			ptrRight--;
		}
		if (ptrLeft < ptrRight)
		{
			swap(data[ptrLeft], data[ptrRight]);
		}
	}
	if (ptrRight > leftWall)
	{
		qSort(data, leftWall, ptrRight);
	}
	if (ptrLeft < rightWall && ptrLeft - leftWall > 0)
	{
		qSort(data, ptrLeft, rightWall);
	}
}

void fillArray(int data[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		scanf("%i", &data[i]);
	}
	printf("\n \n");
}

void randArray(int data[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		data[i] = rand();
	}
}

int maxOf(int data1, int data2, int data3)
{
	if (data1 >= data2 && data1 >= data3)
	{
		return data1;
	}
	if (data2 >= data1 && data2 >= data3)
	{
		return data2;
	}
	if (data3 >= data2 && data3 >= data1)
	{
		return data3;
	}
	return 0;
}

void insSort(int data[], const int size)
{
	int j = 0;
	int dataToWork = 0;
	for (int i = 1; i < size; i++)
	{
		int dataToWork = data[i];
		j = i - 1;
		while (j >= 0 && dataToWork < data[j])
		{
			data[j + 1] = data[j];
			j--;
		}
		data[j + 1] = dataToWork;
	}
}

bool tests()
{
	srand(time(nullptr));
	for (int i = 0; i < 5; i++)
	{
		const int SIZE1 = 15;
		const int SIZE2 = 9;
		int data1[15]{};
		int data2[9]{};
		randArray(data1, 15);
		randArray(data2, 9);
		qSort(data1, 0, SIZE1 - 1);
		insSort(data2, SIZE2);
		int previous = data1[0];
		for (int i = 0; i < SIZE1; i++)
		{
			if (data1[i] < previous)
			{
				return 1;
			}
			previous = data1[i];
		}
		previous = data2[0];
		for (int i = 0; i < SIZE2; i++)
		{
			if (data2[i] < previous)
			{
				return 1;
			}
			previous = data2[i];
		}
	}
	return 0;
}
