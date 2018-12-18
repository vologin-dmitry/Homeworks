#pragma once

struct StackElement
{
	char data = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

//Добавить элемент в стек
void push(Stack &stack, char data);

//Удалить последний элемент из стэка
void pop(Stack &stack);

//Проверить является ли стек пустым
bool isEmpty(Stack stack);

//Удалить стэк
void deleteStack(Stack &stack);

char stackTop(Stack stack);