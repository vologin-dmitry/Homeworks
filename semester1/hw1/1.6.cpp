#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>


int main()
{
	int len, len1;
	bool next = true;
	int count = 0;

	printf("Insert string length ");
	scanf("%i",&len);
	char *str = new char[len + 1]{};
	printf("Insert string ");
	scanf("%s",str);

	printf("Insert string to search's length ");
	scanf("%i",&len1);
	char *s1 = new char[len1 + 1]{};
	printf("Insert string to search ");
	scanf("%s",s1);

	for (int i = 0; i < len; i++)
	{
		if (str[i] == s1[0])
		{
			for (int m = 1; m < len1 - 1; m++)
			{
				if (s1[m] != str[m + i])
				{
					next = false;
					break;
				}
			}
			if (next && s1[len1 - 1] == str[i + len1 - 1])
				count++;
		}
	}
	printf("%i", count);
	delete[] str;
	delete[] s1;
	return 0;
}