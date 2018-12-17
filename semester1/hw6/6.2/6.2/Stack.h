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

//�������� ������� � ����
void push(Stack &stack, char data);

//������ ������� �� �����
char pop(Stack &stack, bool &result);

//��������� �������� �� ���� �������
bool isEmpty(Stack stack);

//������� ����
void deleteStack(Stack &stack);
