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

//Добавить элемент в стек
void push(Stack &stack, int data);

//Вынуть элемент из стэка
int pop(Stack &stack, bool &result);

//Проверить является ли стек пустым
bool isEmpty(Stack stack);

//Удалить стэк
void deleteStack(Stack &stack);