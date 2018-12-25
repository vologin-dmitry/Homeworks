#pragma once

struct Stack;

//Добавить элемент в стек
void push(Stack *stack, char data);

//Удалить последний элемент из стэка
void pop(Stack *stack);

//Проверить является ли стек пустым
bool isEmpty(Stack *stack);

//Удалить стэк
void deleteStack(Stack *stack);

char stackTop(Stack *stack);

Stack *createStack();