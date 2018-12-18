#include "pch.h"
#include "Sort.h"

void swap(int &first, int &second);
int maxOf(int data1, int data2, int data3);

void qSort(int data[], int leftWall, int rightWall)
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

void insertionSort(int data[], const int leftWall, const int rightWall)
{
	for (int i = leftWall + 1; i < rightWall + 1; i++)
	{
		int dataToWork = data[i];
		int j = i - 1;
		while (j >= leftWall && dataToWork < data[j])
		{
			data[j + 1] = data[j];
			j--;
		}
		data[j + 1] = dataToWork;
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

void swap(int &first, int &second)
{
	int temp = first;
	first = second;
	second = temp;
}