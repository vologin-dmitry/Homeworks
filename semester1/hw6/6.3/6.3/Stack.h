#pragma once

struct Stack;

//�������� ������� � ����
void push(Stack *stack, char data);

//������� ��������� ������� �� �����
void pop(Stack *stack);

//��������� �������� �� ���� ������
bool isEmpty(Stack *stack);

//������� ����
void deleteStack(Stack *stack);

char stackTop(Stack *stack);

Stack *createStack();