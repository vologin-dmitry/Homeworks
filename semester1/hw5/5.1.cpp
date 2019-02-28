#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <locale.h>

using namespace std;

struct Element
{
    int value = -1;
    Element *next = nullptr;
};

void deleteNumber(Element **head, int toDelete);
void push(Element **head, int data);
void print(Element *head);
void clear(Element **head);
bool test();

int main()
{
    setlocale(LC_ALL, "russian");
    cout << "Подождите, проходят тесты\n";
    if (test())
    {
        cout << "Тесты прошли неправильно !!";
        return 1;
    }
    else
    {
        cout << "Тесты прошли успешно";
    }
    char choose = ' ';
    Element *head = nullptr;
    while (choose != '0')
    {
        cout << "\nВведите 0, чтобы выйти";
        cout << "\nВведите 1, чтобы добавить значение";
        cout << "\nВведите 2, чтобы удалить значение";
        cout << "\nВведите 3, чтобы распечатать список\n";
        cin >> choose;
        switch (choose)
        {
            case '0':
            {
                if (head == nullptr)
                {
                    return 0;
                }
                clear(&head);
                return 0;
            }
            case '1':
            {
                cout << "Введите число\n";
                int number = 0;
                cin >> number;
                push(&head, number);
                break;
            }
            case '2':
            {
                cout << "Какую цифру удалить ?\n";
                int toDel = 0;
                cin >> toDel;
                deleteNumber(&head, toDel);
                break;
            }
            case '3':
            {
                if (head == nullptr)
                {
                    cout << "\nСписок пуст";
                    return 1;
                }
                print(head);
                break;
            }
            default:
                break;
        }
    }
    return 0;
}

void push(Element **head, const int data)
{
    auto *node = new Element;
    node->value = data;

    if (*head == nullptr)
    {
        *head = node;
        return;
    }
    if (node->value < (*head)->value)
    {
        node->next = *head;
        *head = node;
        return;
    }
    Element *pointer = *head;
    while (pointer->next != nullptr && (pointer->next)->value < node->value)
    {
        pointer = pointer->next;
    }
    if (pointer->next == nullptr)
    {
        pointer->next = node;
        return;
    }
    if ((pointer->next)->value >= node->value)
    {
        node->next = pointer->next;
        pointer->next = node;
        return;
    }
}

void print(Element *head)
{
    Element *pointer = head;
    while (pointer != nullptr)
    {
        cout << pointer->value << ' ';
        pointer = pointer->next;
    }
}

void deleteNumber(Element **head, const int toDelete)
{
    Element *pointer = *head;
    if ((*head)->value == toDelete)
    {
        *head = (*head)->next;
        delete pointer;
        return;
    }
    while (pointer->next != nullptr && (pointer->next)->value != toDelete)
    {
        pointer = pointer->next;
    }
    if (pointer->next == nullptr)
    {
        cout << "Нет такого номера !\n";
        return;
    }
    if ((pointer->next)->value == toDelete)
    {
        Element *delPtr = pointer->next;
        pointer->next = (pointer->next)->next;
        delete delPtr;
    }
}

void clear(Element **head)
{
    Element *pointer = *head;
    Element *following = pointer->next;
    while (following != nullptr)
    {
        delete pointer;
        pointer = following;
        following = following->next;
    }
    delete pointer;
}

bool test()
{
    int add[10]{ 5, -6, 0, 53, 125, -643, 1234, 6, 2, 0 };
    int minus[10]{ 6, 2, 0, 42141, -1, -32, -9, -65, 1234, 2 };
    int firstAns[10]{ -643, -6, 0, 0, 2, 5, 6, 53, 125, 1234 };
    int secondAns[6]{ -643, -6, 0, 5, 53, 125 };
    Element *head = nullptr;
    for (int i = 0; i < 10; ++i)
    {
        push(&head, add[i]);
    }
    Element *pointer = head;
    for (int i = 0; i < 10; i++)
    {
        if (pointer->value != firstAns[i])
        {
            return true;
        }
        pointer = pointer->next;
    }
    for (int i = 0; i < 10; ++i)
    {
        deleteNumber(&head, minus[i]);
    }
    pointer = head;
    for (int i = 0; i < 6; i++)
    {
        if (pointer->value != secondAns[i])
        {
            return true;
        }
        pointer = pointer->next;
    }
    clear(&head);
    return false;
}
