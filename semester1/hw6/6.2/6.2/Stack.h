#pragma once

struct StackElement
{
	char data = ' ';
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

//Добавить элемент в стэк
void push(Stack &stack, char data);

//Вынуть элемент из стжка
char pop(Stack &stack, bool &result);

//Проверить является ли стэк пустным
bool isEmpty(Stack stack);

//Удалить стэк
void deleteStack(Stack &stack);
