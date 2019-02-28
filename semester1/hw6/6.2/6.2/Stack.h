#pragma once

struct Stack;

//Добавить элемент в стэк
void push(Stack *stack, char data);

//Вынуть элемент из стжка
char pop(Stack *stack, bool &result);

//Проверить является ли стэк пустным
bool isEmpty(Stack *stack);

//Удалить стэк
void deleteStack(Stack *stack);

Stack *createStack();