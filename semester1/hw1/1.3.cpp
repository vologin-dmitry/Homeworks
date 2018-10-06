#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

void Swapping(int arr[], int begin, int end)
{
	for (int i = begin; i <begin+(end-begin)/2; i++)
	{
		int temp = arr[i];
		arr[i] = arr[end-1-(i-begin)];
		arr[end-1-(i-begin)] = temp;
	}
}

int main()
{
	int m, n;
	scanf("%i %i", &m, &n);
	int *arr = new int[m + n];
	for (int i = 0; i < m + n; i++)
	{
		scanf("%d", &arr[i]);
	}
	Swapping(arr, 0, m);
	Swapping(arr, m, m + n);
	Swapping(arr, 0, m + n);
	for (int i = 0; i < m + n; i++)
	{
		printf("%d " , arr[i]);
	}
	delete[] arr;
}