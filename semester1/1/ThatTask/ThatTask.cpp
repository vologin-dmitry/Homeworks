#include "pch.h"
#include <iostream>
#include <stack>
#include <string>
#include "Sort.h"

using namespace std;


string howMuch(int data[], int size);

int main()
{
	int number = -1;
	stack<int> data{};
	while (number != 0)
	{
		cin >> number;
		if (number != 0)
		{
			data.push(number);
		}
	}
	int size = data.size();
	int *dataInArray = new int[size] {}; // Не забудь очистить !!!
	for (int i = 0; i < size; i++)
	{
		dataInArray[i] = data.top();
		data.pop();
	}
	qSort(dataInArray, 0, size - 1);
	cout << howMuch(dataInArray, size);
	delete[] dataInArray;
}



string howMuch(int data[], int size)
{
	string answer = "";
	int count = 1;
	answer = answer + to_string(data[0]);
	for (int i = 1; i < size; i++)
	{
		if (data[i] == data[i - 1])
		{
			count++;
		}
		else
		{
			answer += " " + to_string(count) + "times " + to_string(data[i]);
			count = 1;
		}
	}
	answer += " " + to_string(count) + " times";
	return answer;
}