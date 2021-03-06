#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <stdio.h>
#include <locale.h>

FILE *fileReadCheck();
void addNote(const char *fileName,char *line = nullptr, int ending = 0);
char *searchForLine(FILE *file, char *lineToSearch, char *lineToAnswer);
void fillToSearch(char name[], const int SIZE);
bool haveInLine(char line[], char toSearch[]);
void getLineToWork(char *lineToWork, const int SIZE);
void printAll();
void fillLine(FILE *file, char line[]);
void printAnswer(char *lineToWork, const int BEGIN, const int END);
int getWall(char *lineToWork);
bool tests();
void closeAndDeleteFile(FILE *file,const char *name);

int main()
{
	const int SIZE = 100;
	setlocale(LC_ALL, "Rus");
	if (tests())
	{
		printf("Что то пошло не так !");
		return 1;
	}
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
		case 1:
		{	
			addNote("FileToWork.txt");
			continue;
		}
		case 2:
		{
			printAll();
			continue;
		}
		case 3:
		{			
			char lineToWork[SIZE]{};
			getLineToWork(lineToWork, SIZE);
			printAnswer(lineToWork, getWall(lineToWork) + 1, SIZE);
			continue;
		}
		case 4:
		{
			char lineToWork[SIZE]{};
			getLineToWork(lineToWork, SIZE);
			printAnswer(lineToWork, 0, getWall(lineToWork));
			continue;
		}
		case 5:
		{
			printf("Эта кнопка бесполезна, изменения сохраняются автоматически");
		}
		default:
			continue;
		}
	}
}

void addNote(const char *fileName,char *line, int ending)
{
	FILE *file = fopen(fileName, "a");
	if (line == nullptr)
	{
		printf("Введите запись формате *Имя* *Фамилия* *Номер* (Не более 100 символов)\n");
		char note[100]{};
		line = note;
		for (int i = 0; i < 100; i++)
		{
			scanf("%c", &line[i]);
			if (line[i] == '\n')
			{
				ending = i;
				break;
			}
		}
	}
	fwrite(line, sizeof(char), ending + 1, file);
	fclose(file);
}

char *searchForLine(FILE *file, char *lineToSearch, char *lineToAnswer)
{
	while (!feof(file))
	{
		fillLine(file, lineToAnswer);
		if (haveInLine(lineToAnswer, lineToSearch))
		{
			return lineToAnswer;
		}
	}
	printf("Таких нет");
	return nullptr;
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

void fillToSearch(char name[], const int SIZE)
{
	printf("Введите что ищем\n");
	for (int i = 0; i < SIZE && name[i - 1] != '\n'; i++)
	{
		scanf("%c", &name[i]);
	}
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
	fclose(file);
}


void getLineToWork(char *lineToWork, const int SIZE)
{
	char *lineToSearch = new char[SIZE]{};
	fillToSearch(lineToSearch, SIZE);
	FILE *file = fileReadCheck();
	searchForLine(file, lineToSearch, lineToWork);
	delete []lineToSearch;
}

int getWall(char *lineToWork)
{
	int i = 0;
	for (int j = 0; j < 2; j++)
	{
		while (lineToWork[i] != ' ')
		{
			i++;
		}
		i++;
	}
	return i - 1;
}

void printAnswer(char *lineToWork, const int BEGIN, const int END)
{
	for (int i = BEGIN; i < END && lineToWork[i] != '\n'; i++)
	{
		printf("%c", lineToWork[i]);
	}
}

FILE *fileReadCheck()
{
	FILE *file = fopen("FileToWork.txt", "r");
	if (file == nullptr)
	{
		printf("Файла нет");
		file = fopen("FileToWork", "w");
		return file;
	}
	else
	{
		return file;
	}
}

void closeAndDeleteFile(FILE *file,const char *name)
{
	fclose(file);
	file = fopen(name, "w");
	fclose(file);
}

bool tests()
{
	const int SIZE = 31;
	char line[5][SIZE]{ { "Ivanovich Ivan 11133322244000\n" }, { "German Notgerm 12345678901123\n" }, { "Yarslav Fillip 12332112332445\n" },
		{ "Veliky Reforma 99999999999999\n" }, { "Testios Dudere 65465465412000\n" } };
	for (int i = 0; i < 5; i++)
	{
		addNote("TestFile.txt", line[i], SIZE - 2);
	}
	char datas[5][16]{ {"11133322244000\n"}, { "German Notgerm\n" }, { "12332112332445\n" }, { "Veliky Reforma\n" }, { "65465465412000\n" } };
	int wallCheck = 14;
	FILE *file = fopen("TestFile.txt", "r");
	char answers[5][SIZE]{};
	int walls[5]{};
	for (int i = 0; i < 5; i++)
	{
		searchForLine(file, datas[i], answers[i]);
		walls[i] = getWall(line[i]);
	}
	for (int i = 0; i < 5; i++)
	{
		if (walls[i] != wallCheck)
		{
			closeAndDeleteFile(file, "TestFile.txt");
			return true;
		}
		for (int j = 0; j < SIZE; j++)
		{
			if (answers[i][j] != line[i][j])
			{
				closeAndDeleteFile(file, "TestFile.txt");
				return true;
			}
		}
	}
	closeAndDeleteFile(file, "TestFile.txt");
	return false;
}