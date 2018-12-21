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
	PriorityQueue *queue = new PriorityQueue;
	enqueue(queue, 5, "hello");
	enqueue(queue, 1, "ewt");
	enqueue(queue, 10, "wafiafo");
	cout << dequeue(queue) << endl;
	cout << dequeue(queue) << endl;
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