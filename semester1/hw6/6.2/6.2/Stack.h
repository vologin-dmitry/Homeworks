#pragma once

struct Stack;

//�������� ������� � ����
void push(Stack *stack, char data);

//������ ������� �� �����
char pop(Stack *stack, bool &result);

//��������� �������� �� ���� �������
bool isEmpty(Stack *stack);

//������� ����
void deleteStack(Stack *stack);

Stack *createStack();