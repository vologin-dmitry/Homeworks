#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>


int main()
{
	int data;
	scanf("%d",&data);
	int sqr = data * data;
	printf("%d", (sqr + data)*(sqr + 1) + 1);
}