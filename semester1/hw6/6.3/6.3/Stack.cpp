#include "pch.h"
#include "Stack.h"
#include <stdio.h>

struct StackElement
{
	char data = 0;
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

void pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return;
	}
	StackElement *temp = stack->head;
	stack->head = stack->head->next;
	delete temp;
	return;
}

char stackTop(Stack *stack)
{
	if (stack->head != nullptr)
	{
		return stack->head->data;
	}
	else
	{
		return '\n';
	}
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
	delete stack;
}

Stack *createStack()
{
	return new Stack;
}