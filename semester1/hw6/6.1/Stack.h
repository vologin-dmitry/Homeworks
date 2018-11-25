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

//Добавить элемент в стэк
void push(Stack &stack, int data);

//Вынуть элемент из стжка
int pop(Stack &stack, bool &result);

//Проверить является ли стэк пустным
bool isEmpty(Stack stack);

//Удалить стэк
void deleteStack(Stack &stack);
