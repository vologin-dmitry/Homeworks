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

//�������� ������� � ����
void push(Stack &stack, char data);

//������� ��������� ������� �� �����
void pop(Stack &stack);

//��������� �������� �� ���� ������
bool isEmpty(Stack stack);

//������� ����
void deleteStack(Stack &stack);

char stackTop(Stack stack);