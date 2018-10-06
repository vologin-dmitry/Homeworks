#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>

int main()
{
	int a, b;
	bool negative_answer = false;
	int cntr = 0;
	scanf("%i %i", &a, &b);
	if (b == 0)
	{
		printf("You can not divide by zero");
		return 0;
	}
	if ((a xor b) < 0)
		negative_answer = true;
	if (a < 0)
		a = -a;
	if (b < 0)
		b = -b;
	for (; a > 0; a -= b, cntr++) {}
	if (a < 0)
		cntr--;
	if (negative_answer)
		cntr = -cntr;
	printf("%i", cntr);
}