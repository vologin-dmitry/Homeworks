#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

void bubbleSort(int data[], const int size);
void countSort(int data[], const int size);
void youMustChoose(int data[], const int size);
bool tests();

int main()
{
	if (tests())
	{
		printf("\nSomething went wrong\n");
		return 1;
	}
	else
	{
		printf("\nTests were successfull\n");
	}
	int size;
	printf("Input array size ");
	scanf("%i", &size);
	int *data = new int[size];
	printf("Input array ");
	for (int i = 0; i < size; i++)
	{
		scanf("%i", &data[i]);
	}
	youMustChoose(data, size);
	for (int i = 0; i < size; i++)
	{
		printf("%i ", data[i]);
	}
	delete[] data;
}

void bubbleSort(int data[], const int size)
{
	for (int i = 0; i < size - 1; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (data[i] > data[j])
			{
				int temp = data[i];
				data[i] = data[j];
				data[j] = temp;
			}
		}
	}
}


void countSort(int data[], const int size)
{
	int max = data[0];
	int min = data[0];
	for (int i = 1; i < size; i++)
	{
		if (data[i] > max)
		{
			max = data[i];
		}
		if (data[i] < min)
		{
			min = data[i];
		}
	}
	int *counter = new int[max - min + 1]{};
	for (int i = 0; i < size; i++)
	{
		counter[data[i] - min]++;
	}
	int point = 0;
	for (int i = 0; i < max - min + 1; i++)
	{
		while (counter[i] != 0)
		{
			data[point] = i + min;
			point++;
			counter[i]--;
		}
	}
	delete[] counter;
}

void youMustChoose(int data[], const int size)
{
	printf("\nSelect the sorting algorithm: \nInput 1 to choose Bubble Sort \nInput 2 to choose Sort by counting\n");
	int chooseSort;
	scanf("%i", &chooseSort);
	if (chooseSort == 1)
	{
		bubbleSort(data, size);
	}
	if (chooseSort == 2)
	{
		countSort(data, size);
	}
}

bool tests()
{
	int arrays1[4][5]{ {0,0,0,0,0},{-65,-7,86,0,-100},{7,6,5,4,3},{1,2,3,4,5} };
	int arrays2[4][5]{ {0,0,0,0,0},{-65,-7,86,0,-100},{7,6,5,4,3},{1,2,3,4,5} };
	int answers[4][5]{ {0,0,0,0,0},{-100,-65,-7,0,86},{3,4,5,6,7},{1,2,3,4,5} };
	for (int i = 0; i < 4; i++)
	{
		bubbleSort(arrays1[i], 5);
		countSort(arrays2[i], 5);
		for (int j = 0; j < 5; j++)
		{
			if (arrays1[i][j] != answers[i][j])
			{
				return 1;
			}
			if (arrays2[i][j] != answers[i][j])
			{
				return 1;
			}
		}
	}
	return 0;
}