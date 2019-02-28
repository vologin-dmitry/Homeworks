#include "pch.h"
#include "Tree.h"
#include <iostream>
#include <fstream>
#include <string>

struct Node
{
	std::string value = "";
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
	Node *parent = nullptr;
};

struct Tree
{
	Node *root = nullptr;
};

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

void buildTree(const std::string &line, Tree* tree)
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

int countTreeRecursive(Node *node)
{
	if (node->leftChild == nullptr)
	{
		return std::stoi(node->value);
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
				return countTreeRecursive(node->leftChild) + countTreeRecursive(node->rightChild);
				break;
			}
			case '-':
			{
				return countTreeRecursive(node->leftChild) - countTreeRecursive(node->rightChild);
				break;
			}
			case '*':
			{
				return countTreeRecursive(node->leftChild) * countTreeRecursive(node->rightChild);
				break;
			}
			case '/':
			{
				return countTreeRecursive(node->leftChild) / countTreeRecursive(node->rightChild);
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

void printTreeRecursive(Node *node)
{
	if (node->leftChild != nullptr)    //Так как файл корректен, существование левого потомка гарантирует существование правого потомка
	{
		std::cout << "(";
		std::cout << ' ' << node->value << ' ';
		printTreeRecursive(node->leftChild);
		printTreeRecursive(node->rightChild);
		std::cout << ")";
	}
	else
	{
		std::cout << ' ' << node->value << ' ';
	}
}

void deleteTreeRecursive(Node *&node)
{
	if (node->leftChild != nullptr)
	{
		deleteTreeRecursive(node->leftChild);
		node->leftChild = nullptr;
	}
	if (node->rightChild != nullptr)
	{
		deleteTreeRecursive(node->rightChild);
		node->rightChild = nullptr;
	}
	delete node;
	return;
}

int countTree(Tree *tree)
{
	return countTreeRecursive(tree->root);
}

void printTree(Tree *tree)
{
	printTreeRecursive(tree->root);
}

void deleteTree(Tree *tree)
{
	deleteTreeRecursive(tree->root);
	delete tree;
}

Tree *createTree()
{
	Tree *tree = new Tree;
	tree->root = new Node;
	return tree;
}