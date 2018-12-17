#define _CRT_SECURE_NO_WARNINGS

#include "pch.h"
#include <stdio.h>
#include "Sort.h"
#include <locale.h>

void fillArray(int data[], int size, FILE *file);
int mostOften(int data[], int size);
bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		printf("\nЧто то пошло не так !\n");
		return 1;
	}
	FILE *file = fopen("Data.txt", "r");
	if (file == nullptr)
	{
		printf("Файла не существует, создайте файл\n");
		return 1;
	}
	int size = 0;
	fscanf(file, "%i", &size);
	int *data = new int[size];
	fillArray(data, size, file);
	printf("%i", mostOften(data, size));
	delete[] data;
	return 0;
}

void fillArray(int data[], int size, FILE *file)
{
	int i = 0;
	while (!feof(file))
	{
		fscanf(file, "%i", &data[i]);
		i++;
	}
}

int mostOften(int data[], int size)
{
	qSort(data, 0, size - 1);
	int counter = 1;
	int maxCounter = 1;
	int maxNumber = data[0];
	for (int i = 1; i < size; i++)
	{
		if (data[i] == data[i - 1])
		{
			counter++;

		}
		if (maxCounter < counter)
		{
			maxCounter = counter;
			maxNumber = data[i - 1];
		}
		if (data[i] != data[i - 1])
		{
			counter = 1;
		}
	}
	return maxNumber;
}

bool tests()
{
	const int SIZE1 = 5;
	const int SIZE2 = 10;
	int data[SIZE1][SIZE2]{ { 1, 2, 3, 4, 5, 6, 7, 7, 8, 9 },
						   { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
						   { 5, 6, 8, -6, -5, 78, -6, 221, 6, -6 },
						   { 63, 36, 732, 7332, 6343, 436, 235, 235, 2324, 0 },
						   { 100, 91, 91, 91, 91, 91, 91, 100, 0, 100 } };
	int answers[5]{ 7, -1, -6, 235, 91 };
	for (int i = 0; i < SIZE1; i++)
	{
		if (mostOften(data[i], SIZE2) != answers[i])
		{
			return true;
		}
	}
	return false;
}
