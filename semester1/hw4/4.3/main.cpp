#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>

void addNote();
void printAll();
void searchByNumber();
void searchByName();
bool haveInLine(char line[], char toSearch[]);
void fillLine(FILE *file, char line[]);

int main()
{
    setlocale(LC_ALL, "Rus");
    int choose = -1;
    while (choose != 0)
    {
        printf("\nВведите 0, чтобы выйти");
        printf("\nВведите 1, чтобы добавить запись");
        printf("\nВведите 2, чтобы распечатать все записи");
        printf("\nВведите 3, чтобы искать номер человека по имени");
        printf("\nВведите 4, чтобы искать имя человека по номеру");
        printf("\nВведите 5, чтобы сохранить изменения\n");
        scanf("%i", &choose);
        char temp = ' ';
        scanf("%c", &temp);
        switch (choose)
        {
            case 1 :
            {
                addNote();
                continue;
            }
            case 2:
            {
                printAll();
                continue;
            }
            case 3:
            {
                searchByName();
                continue;
            }
            case 4:
            {
                searchByNumber();
                continue;
            }
            default:
                continue;
        }
    }
}

void addNote()
{
    FILE *file = fopen("FileToWork.txt", "a");
    if (file == nullptr)
    {
        printf("Что то пошло не так !");
    }
    printf("Введите запись формате *Имя* *Фамилия* *Номер* (Не более 100 символов)\n");
    char line[100]{};
    int ending = 100;
    for (int i = 0; i < 100; i++)
    {
        scanf("%c", &line[i]);
        if (line[i] == '\n')
        {
            ending = i;
            break;
        }
    }
    fwrite(line, sizeof(char), ending + 1, file);
    fclose(file);
}

void printAll()
{
    FILE *file = fopen("FileToWork.txt", "r");
    char charsRead = ' ';
    while (!feof(file))
    {
        fscanf(file, "%c", &charsRead);
        printf("%c", charsRead);
    }
}

void searchByNumber()
{
    const int SIZE = 11;
    printf("Введите номер, по которому искать (11 цифр)\n");
    char number[SIZE + 1]{};
    for (int i = 0; i < SIZE; i++)
    {
        scanf("%c", &number[i]);
    }
    number[SIZE] = '\n';
    FILE *file = fopen("FileToWork.txt", "r");
    while (!feof(file))
    {
        char line[100]{};
        fillLine(file, line);
        if (haveInLine(line, number))
        {
            int spaces = 0;
            int i = 0;
            while (spaces < 2)
            {
                if (line[i] == ' ')
                {
                    spaces++;
                }
                printf("%c", line[i]);
                i++;
            }
            return;
        }
    }
    printf("Таких нет");
}

void searchByName()
{
    const int SIZE = 100;
    printf("Введите имя\n");
    char name[SIZE + 1]{};
    for (int i = 0; i < SIZE && name[i - 1] != '\n'; i++)
    {
        scanf("%c", &name[i]);
    }
    FILE *file = fopen("FileToWork.txt", "r");
    while (!feof(file))
    {
        char line[100]{};
        fillLine(file, line);
        int i = 0;
        if (haveInLine(line, name))
        {
            int spaces = 0;
            while (spaces < 2)
            {
                if (line[i] == ' ')
                {
                    spaces++;
                }
                i++;
            }
            while (line[i] != '\n')
            {
                printf("%c", line[i]);
                i++;
            }
            return;
        }

    }
    printf("Таких нет");
}

bool haveInLine(char line[], char toSearch[])
{
    int x = 0;
    int i = 0;
    for (i = 0; line[i] != '\n' && i < 100; i++)
    {
        if (toSearch[x] == '\n')
        {
            return true;
        }
        if (line[i] == toSearch[x])
        {
            x++;
            continue;
        }
        if (line[i] != toSearch[x])
        {
            x = 0;
        }
    }
    return (toSearch[x] == '\n');
}

void fillLine(FILE *file, char line[])
{
    char letter = ' ';
    int i = 0;
    while (letter != '\n' && i < 100)
    {
        fscanf(file, "%c", &letter);
        line[i] = letter;
        i++;
    }
}