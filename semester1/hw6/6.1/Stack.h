#pragma once

struct StackElement
{
	int data = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

void push(Stack &stack, int data);
int pop(Stack &stack, bool &result);
bool isEmpty(Stack stack);
void deleteStack(Stack &stack);
