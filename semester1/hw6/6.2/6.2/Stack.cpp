#include "pch.h"
#include "Stack.h"
#include <stdio.h>


struct StackElement
{
	char data = ' ';
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

void push(Stack *stack, char data)
{
	auto newElement = new StackElement{ data, stack->head };
	stack->head = newElement;
}

char pop(Stack *stack, bool & result)
{
	if (stack->head == nullptr)
	{
		result = false;
		return -1;
	}
	StackElement *temp = stack->head;
	stack->head = stack->head->next;
	const char value = temp->data;
	delete temp;
	result = true;
	return value;
}

bool isEmpty(Stack *stack)
{
	return stack->head == nullptr;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *temp = stack->head;
		stack->head = temp->next;
		delete temp;
	}
}

Stack *createStack()
{
	return new Stack;
}