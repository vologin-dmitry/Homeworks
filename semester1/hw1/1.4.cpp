#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>


int main()
{
	int cntr[28]{};
	int ans=0;
	for (int i = 0; i <= 9; i++)
		for (int j = 0; j <= 9; j++)
			for (int k = 0; k <= 9; k++)
			{
				cntr[i + j + k]++;
			}

	for (int i = 0; i < 28; i++)
	{
		if (cntr[i] != 0)
		{
			ans += cntr[i] * cntr[i];
		}
	}
	printf("%d", ans);
}