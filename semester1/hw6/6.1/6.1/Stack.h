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

//Add element to stack
void push(Stack &stack, int data);

//Remove element from stack
int pop(Stack &stack, bool &result);

//Check if the stack is empty
bool isEmpty(Stack stack);

//Delete stack
void deleteStack(Stack &stack);