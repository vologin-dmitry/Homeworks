#include "pch.h"
#include "Tree.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void buildTree(string line, Tree*& tree)
{
	Node *current = tree->root;
	Node *tripletHead = current;
	int i = 0;
	while (line[i] != '\n')
	{
		if (line[i] == ' ')
		{
			i++;
			continue;
		}
		if (line[i] == '(')
		{
			current->leftChild = new Node{ "", nullptr, nullptr, current };
			current->rightChild = new Node{ "", nullptr, nullptr, current };
			tripletHead = current;
			i++;
			continue;
		}
		if (line[i] == ')')
		{
			if (tripletHead != tree->root)
			{
				tripletHead = tripletHead->parent;
				current = nodeFree(tripletHead);
				i++;
				continue;
			}
			i++;
		}
		else
		{
			do
			{
				current->value = current->value + line[i];
				i++;
			}
			while (isdigit(line[i]));
			current = nodeFree(tripletHead);
		}
	}
	return;
}

Node *nodeFree(Node* node)
{
	if (node->value == "")
	{
		return node;
	}
	if (node->leftChild->value == "")
	{
		return node->leftChild;
	}
	if (node->rightChild->value == "")
	{
		return node->rightChild;
	}
	return nullptr;
}


int countTree(Node *node)
{
	if (node->leftChild == nullptr)
	{
		return stoi(node->value);
	} 
	else
	{
		if ((node->value).length() == 1 && (!isdigit((node->value)[0])))
		{
			char letter = (node->value)[0];
			switch(letter)
			{
			case '+':
			{
				return countTree(node->leftChild) + countTree(node->rightChild);
				break;
			}
			case '-':
			{
				return countTree(node->leftChild) - countTree(node->rightChild);
				break;
			}
			case '*':
			{
				return countTree(node->leftChild) * countTree(node->rightChild);
				break;
			}
			case '/':
			{
				return countTree(node->leftChild) / countTree(node->rightChild);
				break;
			}
			default: 
			{
				return 0;
			}
			}
		}
	}
}

void printTree(Node *node)
{
	if (node->leftChild != nullptr)    //Так как файл корректен, существование левого потомка гарантирует существование правого потомка
	{
		cout << "(";
		cout << ' ' << node->value << ' ';
		printTree(node->leftChild);
		printTree(node->rightChild);
		cout << ")";
	}
	else
	{
		cout << ' ' << node->value << ' ';
	}
}

void deleteTree(Node *&node)
{
	if (node->leftChild != nullptr)
	{
		deleteTree(node->leftChild);
		node->leftChild = nullptr;
	}
	if (node->rightChild != nullptr)
	{
		deleteTree(node->rightChild);
		node->rightChild = nullptr;
	}
	delete node;
	return;
}