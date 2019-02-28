#include "pch.h"
#include <iostream>
#include "Tree.h"
#include <string>
#include <fstream>
#include <locale.h>

using namespace std;

bool tests();

int main()
{
	setlocale(LC_ALL, "russian");
	if (tests())
	{
		cout << "Что то пошло не так !";
		return 1;
	}
	Tree *tree = createTree();
	ifstream fileToWork("FileToWork.txt", ios::in);
	if (!fileToWork.is_open())
	{
		cout << "Файла не существет";
		return 1;
	}
	string line = "";
	getline(fileToWork, line);
	line += '\n';
	buildTree(line, tree);
	cout << countTree(tree) << endl;
	printTree(tree);
	deleteTree(tree);
 }

bool tests()
{
	const int SIZE = 5;
	int answers[5]{ 4, 108, 0, 0, 5 };
	ifstream TestFile("TestFile.txt", ios::in);
	if (!TestFile.is_open())
	{
		cout << "Файла не существет";
		return 1;
	}
	for (int i = 0; i < SIZE; i++)
	{
		Tree *testTree = createTree();
		string line = "";
		getline(TestFile, line);
		line += '\n';
		buildTree(line, testTree);
		if (countTree(testTree) != answers[i])
		{
			deleteTree(testTree);
			return 1;
		}
		deleteTree(testTree);
	}
	return 0;
}