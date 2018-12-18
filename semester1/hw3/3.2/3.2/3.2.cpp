#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <time.h>

bool test();
void qSort(long long data[], const long long leftWall, const long long rightWall);
long long maxOf(const long long data1, const long long data2, const long long data3);
void swap(long long &first, long long &second);
void getArr(long long data[], const long long size);
bool binSearch(long long data[], long long number, const long long leftWall, const long long rightWall);
void insertionSort(long long data[], const long long leftWall, const long long rightWall);

int main()
{
	srand(time(nullptr));
	setlocale(LC_ALL, "russian");
	if (test()) 
	{
		printf("Тесты не прошли !\n");
		return 1;
	}
	else
	{
		printf("Тесты прошли успешно\n");
	}

	long long n = 0;
	long long k = 0;
	printf("Введите числа\n");
	scanf("%d", &n);
	scanf("%d", &k);
	long long *nArray = new long long[n] {};
	long long *kArray = new long long[k] {};
	getArr(nArray, n);
	getArr(kArray, k);
	qSort(nArray, 0, n - 1);
	for (long long i = 0; i < k; i++)
	{
		if (binSearch(nArray, kArray[i], 0, n - 1))
		{
			printf("%iй элемент найден\n", i + 1);
		}
		else
		{
			printf("%iй элемент не найден\n", i + 1);
		}
	}
	delete[]nArray;
	delete[]kArray;
	return 0;
}

void qSort(long long data[], const long long leftWall, const long long rightWall)
{
	if (rightWall - leftWall + 1 < 10)
	{
		insertionSort(data, leftWall, rightWall);
	}
	else 
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
}

void insertionSort(long long data[], const long long leftWall, const long long rightWall)
{
	int j = leftWall;
	int dataToWork = leftWall;
	for (int i = leftWall + 1; i < rightWall + 1; i++)
	{
		int dataToWork = data[i];
		j = i - 1;
		while (j >= leftWall && dataToWork < data[j])
		{
			data[j + 1] = data[j];
			j--;
		}
		data[j + 1] = dataToWork;
	}
}

long long maxOf(long long data1, long long data2, long long data3)
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

void swap(long long &first, long long &second)
{
	long long temp = first;
	first = second;
	second = temp;
}

void getArr(long long data[], const long long size)
{
	for (long long i = 0; i < size; i++)
	{
		data[i] = rand() % 21;
		printf("%i ", data[i]);
	}
	printf("\n");
}

bool binSearch(long long data[], long long number, long long leftWall, long long rightWall)
{
	long long wall = (leftWall + rightWall) / 2;
	if (number > data[wall])
	{
		if (rightWall - wall > 0)
		{
			return binSearch(data, number, wall + 1, rightWall);
		}
		else
		{
			return data[wall] == number;
		}
	}
	if (number < data[wall])
	{
		if (wall - leftWall > 0)
		{
			return binSearch(data, number, leftWall, wall - 1);
		}
		else
		{
			return data[wall] == number;
		}
	}
	if (number == data[wall])
	{
		return true;
	}
}

bool test()
{
	const long long SIZE = 18;
	long long data[11]{ 45, 2, 3, 1, 6, 1, 324, 63, 123, 98, -86 };
	int searchFor[SIZE]{ 43, 2341, 53, 123, 4, 1, 45, 6, 324, 7, 3243, 98, 99, 45, 0, -62, -86, 121 };
	bool answers[SIZE]{ false, false, false, true, false, true, true, true, true, false, false, true, false, true, false, false, true, false };
	qSort(data, 0, 10);
	for (int i = 0; i < SIZE; i++)
	{
		if (binSearch(data, searchFor[i], 0, 10) != answers[i])
		{
			return true;
		}
	}
	return false;
}