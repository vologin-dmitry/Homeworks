#include "pch.h"
#include "Stack.h"
#include <stdio.h>


void push(Stack &stack, int data)
{
	auto newElement = new StackElement{ data, stack.head };
	stack.head = newElement;
}

int pop(Stack &stack, bool &result)
{
	if (stack.head == nullptr)
	{
		result = false;
		return -1;
	}
	StackElement *temp = stack.head;
	stack.head = stack.head->next;
	const int value = temp->data;
	delete temp;
	result = true;
	return value;
}

bool isEmpty(Stack stack)
{
	return stack.head == nullptr;
}

void deleteStack(Stack &stack)
{
	while (stack.head != nullptr)
	{
		StackElement *temp = stack.head;
		stack.head = temp->next;
		delete temp;
	}
}