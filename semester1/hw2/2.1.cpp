#define _CRT_SECURE_NO_WARNINGS
//#include "pch.h"
#include <stdio.h>

int recursiveFibonacci(const int n);
int iterativeFibonacci(const int number);
void recursiveFibonacciHelper();
void iterativeFibonacciHelper(const int tooMuch = 45);
bool test();

int main()
{
    printf("Please wait, tests passing\n");
    if (!test())
    {
        printf("Tests passed successfully !\n<--------------------------------------------------------------->\n");
    }
    else
    {
        printf("ERROR! Something went wrong\n");
        return 1;
    }
    int choose = ' ';
    printf("Input 1 to choose recursive algorithm\nInput 2 to choose iterative algorithm ");
    scanf("%c", &choose);
    if (choose == '2')
    {
        iterativeFibonacciHelper();
    }
    if (choose == '1')
    {
        recursiveFibonacciHelper();
    }
    return 0;
}

int recursiveFibonacci(const int n)
{
    if (n == 0)
    {
        printf("ERROR! Input valid number");
        return 0;
    }
    if (n < 0)
    {
        printf("ERROR! Input valid number");
        return -1;
    }
    if (n < 2)
    {
        return 1;
    }
    return recursiveFibonacci(n - 1) + recursiveFibonacci(n - 2);
}

int iterativeFibonacci(const int number)
{
    int temp[3]{ 0, 0, 1 };
    if (number < 0)
    {
        temp[2] = -1;
        return temp[2];
    }
    if (number == 0)
    {
        temp[2] = 0;
        return temp[2];
    }
    for (int i = 1;; i++)
    {
        if (i == number)
        {
            return temp[2];
        }
        temp[0] = temp[1];
        temp[1] = temp[2];
        temp[2] = temp[0] + temp[1];
    }
}

void recursiveFibonacciHelper()
{
    for (int i = 0;; i++)
    {
        printf("%i ", recursiveFibonacci(i));
    }
}

void iterativeFibonacciHelper(const int tooMuch)
{
    for (int i = 0;i < tooMuch; i++)
    {
        printf("%i ", iterativeFibonacci(i));
    }
}

bool test()
{
    int datas[]{ -1, 0, 1, 5, -5, 14 };
    int answers[]{ -1, 0, 1, 5, -1, 377 };
    for (int i = 0; i < 6; i++)
    {
        if (recursiveFibonacci(datas[i]) != answers[i])
        {
            return true;
        }
        if (iterativeFibonacci(datas[i]) != answers[i])
        {
            return true;
        }
    }
    printf("\n\n");
    return false;
}
