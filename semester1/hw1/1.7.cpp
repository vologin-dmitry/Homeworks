#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <math.h>

int main()
{
	bool divides;
	int nmb;
	printf("Insert number ");
	scanf("%i",&nmb);
	if (nmb > 1)
		printf("2 ");
	for (int i = 3; i <= nmb; i += 2)
	{
		divides = false;
		for (int j = 3; j <= sqrt(i); j += 2)
		{
			if (i % j == 0)
			{
				divides = true;
				break;
			}
		}	
		if (!divides)
			printf("%i ", i);
	}
	return 0;
}