#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

int main()
{
	int size;
	int count = 0;
	printf("Insert array's size ");
	scanf("%i", &size);
	int *arr = new int[size];
	for (int i = 0; i < size; i++)
		scanf("%i", &arr[i]);
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == 0)
			count++;
	}
	printf("%i", count);
	return 0;
}