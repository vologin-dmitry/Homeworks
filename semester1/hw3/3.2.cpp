#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>

bool test();
void qSort(__int64 data[], __int64 leftWall, __int64 rightWall);
__int64 maxOf(__int64 data1, __int64 data2, __int64 data3);
void swap(__int64 & first, __int64 & second);
void getArr(__int64 data[], __int64 size);
bool binSearch(__int64 data[], __int64 numb, __int64 leftWall, __int64 rightWall);

int main()
{
	setlocale(LC_ALL, "russian");
	printf("Введите 1, чтобы провести тесты\nВведите любое другое число, чтобы не проводить тесты\n");
	int choose = -1;
	scanf("%i", &choose);
	if (choose = 1)
	{
		if (test())
		{
			printf("Тесты не прошли !\n");
			return 1;
		}
		else
		{
			printf("Тесты прошли успешно\n");
		}
	}
	 __int64 n = 0;
	 __int64 k = 0;
	printf("Введите числа\n");
	scanf("%d", &n);
	scanf("%d", &k);
	__int64 *nArr = new __int64[n] {};
	__int64 *kArr = new __int64[k] {};
	getArr(nArr, n);
	getArr(kArr, k);
	qSort(nArr, 0, n - 1);
	for (__int64 i = 0; i < k; i++)
	{
		if (binSearch(nArr, kArr[i], 0, n - 1))
		{
			printf("%iй элемент найденí\n", i + 1);
		}
		else
		{
			printf("%iй элемент не найден\n", i + 1);
		}
	}
}

void qSort(__int64 data[], __int64 leftWall, __int64 rightWall)
{
	__int64 ptrLeft = leftWall;
	__int64 ptrRight = rightWall;
	__int64 number = maxOf(data[ptrLeft], data[ptrRight], data[(ptrRight + ptrLeft) / 2]);
	while (ptrRight > ptrLeft)
	{
		while (data[ptrLeft] < number)
		{
			ptrLeft++;
		}
		while (data[ptrRight] >= number)
		{
			ptrRight--;
		}
		if (ptrLeft < ptrRight)
		{
			swap(data[ptrLeft], data[ptrRight]);
		}
	}
	if (ptrRight > leftWall)
	{
		qSort(data, leftWall, ptrRight);
	}
	if (ptrLeft < rightWall && ptrLeft - leftWall > 0)
	{
		qSort(data, ptrLeft, rightWall);
	}
}

__int64 maxOf(__int64 data1, __int64 data2, __int64 data3)
{
	if (data1 >= data2 && data1 >= data3)
	{
		return data1;
	}
	if (data2 >= data1 && data2 >= data3)
	{
		return data2;
	}
	if (data3 >= data2 && data3 >= data1)
	{
		return data3;
	}
	return 0;
}

void swap(__int64 & first, __int64 & second)
{
	__int64 temp = first;
	first = second;
	second = temp;
}

void getArr(__int64 data[], __int64 size)
{
	for (__int64 i = 0; i < size; i++)
	{
		scanf("%d", &data[i]);
	}
}

bool binSearch(__int64 data[], __int64 numb, __int64 leftWall, __int64 rightWall)
{
	__int64 wall = (leftWall + rightWall)/2;
	if (numb > data[wall])
	{
		if (rightWall - wall > 0)
		{
			return binSearch(data, numb, wall + 1, rightWall);
		}
		else
		{
			if (data[wall] == numb)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	if (numb < data[wall])
	{
		if (wall - leftWall > 0)
		{
			return binSearch(data, numb, leftWall, wall - 1);
		}
		else
		{
			if (data[wall] == numb)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	if (numb == data[wall])
	{
		return true;
	}
}

bool test()
{
	const __int64 SIZE = 18;
	__int64 data[11]{ 45,2,3,1,6,1,324,63,123,98,-86};
	int searchFor[SIZE]{ 43,2341,53,123,4,1,45,6,324,7,3243,98,99,45,0,-62,-86, 121 };
	bool answers[SIZE]{ false,false,false,true,false,true,true,true,true,false,false,true,false,true,false,false,true,false };
	qSort(data, 0, 10);
	for (int i = 0; i < SIZE; i++)
	{
		if (binSearch(data, searchFor[i], 0, SIZE - 1) != answers[i])
		{
			return 1;
		}
	}
	return 0;
}
