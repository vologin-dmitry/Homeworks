#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>


int main()
{
	int count = 0;
	int lngth;
	printf("Insert string length ");
	scanf("%i", &lngth);
	char *str = new char[lngth + 1];
	scanf("%s", str);
	for (int i = 0; i < lngth; i++)
	{
		if (count < 0)
		{
			printf("Balance is not observed");
			return 0;
		}
		if (str[i] == '(')
			count++;
		if (str[i] == ')')
			count--;
	}
	if (count == 0)
	{
		printf("Balance is observed");
		return 0;
	}
	delete[] str;
	printf("Balance is not observed");
	return 0;
}