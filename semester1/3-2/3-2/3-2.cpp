#include "pch.h"
#include <iostream>
#include "PriorityQueue.h"

using namespace std;

bool tests();

int main()
{
	if (tests())
	{
		cout << "Something went wrong !!";
		return 1;
	}
	cout << "Input 1 to add value to queue\n";
	cout << "Input 2 to get value from queue\n";
	cout << "Input -1 to exit\n";
	PriorityQueue *queue = new PriorityQueue;
	int choose = -3;
	while (true)
	{
		cin >> choose;
		if (choose == 1)
		{
			int prior = -1;
			string str = "";
			cin >> prior;
			cin >> str;
			enqueue(queue, prior, str);
			continue;
		}
		if (choose == 2)
		{
			cout << dequeue(queue) << endl;
			continue;
		}
		if (choose = -1)
		{
			break;
		}
	}
	clear(queue);
	delete queue;
}

bool tests()
{
	const int SIZE = 5;
	PriorityQueue *queue = new PriorityQueue;
	int priors[SIZE]{ 5, 3, 15, 15, 8 };
	string datas[SIZE]{ "a","fa","awf","nevermind", "qu" };
	string answers[SIZE]{ "awf", "nevermind", "qu", "a", "fa" };
	for (int i = 0; i < SIZE; ++i)
	{
		enqueue(queue, priors[i], datas[i]);
	}
	for (int i = 0; i < SIZE; ++i)
	{
		if (dequeue(queue) != answers[i])
		{
			clear(queue);
			delete queue;
			return 1;
		}
	}
	clear(queue);
	delete queue;
	return 0;
}