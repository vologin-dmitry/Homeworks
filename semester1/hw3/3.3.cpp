#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int mostOften(int data[], int size);
void fillArray(int data[], int size);
void swap(int & first, int & second);
int maxOf(int data1, int data2, int data3);
void qSort(int data[], int leftWall, int rightWall);
bool tests();

int main()
{
    if (tests())
    {
        printf("Something went wrong !!!");
        return 1;
    }
    int size = 0;
    printf("Please input array size (it must be > 0)");
    scanf("%i", &size);
    printf("Please input array");
    int *data = new int[size];
    fillArray(data,size);
    printf("%i",mostOften(data,size));
    delete[] data;
}

void fillArray(int data[], int size)
{
    for (int i = 0; i < size; i++)
    {
        scanf("%i", &data[i]);
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
        if (data[i] == data[i-1])
        {
            counter++;
        }
        else
        {
            if (maxCounter < counter)
            {
                maxCounter = counter;
                maxNumber = data[i - 1];
            }
            counter = 1;
        }
    }
    return  maxNumber;
}

void qSort(int data[], int leftWall, int rightWall)
{
    int ptrLeft = leftWall;
    int ptrRight = rightWall;
    int number = maxOf(data[ptrLeft], data[ptrRight], data[(ptrRight + ptrLeft) / 2]);
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

int maxOf(int data1, int data2, int data3)
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

void swap(int & first, int & second)
{
    int temp = first;
    first = second;
    second = temp;
}

bool tests()
{
    const int SIZE1 = 5;
    const int SIZE2 = 10;
    int data[SIZE1][SIZE2]{{1,2,3,4,5,6,7,7,8,9},{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},{5,6,8,-6,-5,78,-6,221,6,-6},
             {63,36,732,7332,6343,436,235,235,2324,0},{100,91,91,91,91,91,91,100,0,100}};
    int answers[5]{7,-1,-6,235,91};
    for (int i = 0; i < SIZE1; i++)
    {
        if (mostOften(data[i],SIZE2) != answers[i])
        {
            return true;
        }
    }
    return false;
}
