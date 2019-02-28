#include "pch.h"
#include "Tree.h"
#include <iostream>

using namespace std;

struct Node
{
	int value = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct Tree
{
	Node *root = nullptr;
};

Node *searchValue(Tree* tree, int value)
{
	Node *current = tree->root;
	while (current != nullptr)
	{
 		if (value < current->value)
		{
			current = current->leftChild;
			continue;
		}
		if (value > current->value)
		{
			current = current->rightChild;
			continue;
		}
		if (value == current->value)
		{
			return current;
		}
	}
	return nullptr;
}

bool exists(Tree *tree, int value)
{
	return searchValue(tree, value) != nullptr;
}

bool isEmpty(Tree *tree)
{
	return tree->root == nullptr;
}

void addNodeRecursive(Node* node, int value)
{
	if (node->value > value && node->leftChild != nullptr)
	{
		addNodeRecursive(node->leftChild, value);
	}
	else if (node->value < value && node->rightChild != nullptr)
	{
		addNodeRecursive(node->rightChild, value);
	}
	else
	{
		if (node->value > value)
		{
			node->leftChild = new Node{ value, nullptr, nullptr };
		}
		else
		{
			node->rightChild = new Node{ value, nullptr, nullptr };
		}
	}
}

bool add(Tree* tree, int const  data)
{
	if (isEmpty(tree))
	{
		tree->root = new Node{ data, nullptr, nullptr };
		return true;
	}
	else if (!exists(tree, data))
	{
		addNodeRecursive(tree->root, data);
		return true;
	}
	return false;
}

int maximum(Node* current)
{
	auto* temp = current;
	temp = temp->leftChild;
	while (temp->rightChild != nullptr)
	{
		temp = temp->rightChild;
	}
	return temp->value;
}

void removeRecursion(Node *&node, int value)
{
	if (node->value > value)
	{
		removeRecursion(node->leftChild, value);
	}
	else if (node->value < value)
	{
		removeRecursion(node->rightChild, value);
	}
	else
	{
		if (node->leftChild == nullptr && node->rightChild == nullptr)
		{
			auto *temp = node;
			node = nullptr;
			delete temp;
			return;
		}
		else if (node->leftChild != nullptr && node->rightChild == nullptr)
		{
			auto *temp = node;
			node = node->leftChild;
			delete temp;
			return;
		}
		else if (node->leftChild == nullptr && node->rightChild != nullptr)
		{
			auto *temp = node;
			node = node->rightChild;
			delete temp;
			return;
		}
		else
		{
			node->value = maximum(node);
			removeRecursion(node->leftChild, node->value);
		}
	}
}

bool remove(Tree* tree, int const value)
{
	if (!exists(tree, value))
	{
		return false;
	}
	removeRecursion(tree->root, value);
	return true;
}

void deleteTreeRecursion(Node *&current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			deleteTreeRecursion(current->leftChild);
		}
		if (current->rightChild != nullptr)
		{
			deleteTreeRecursion(current->rightChild);
		}
		Node *temp = current;
		delete temp;
		current = nullptr;
	}
}

void deleteTree(Tree *tree)
{
	deleteTreeRecursion(tree->root);
	delete tree;
}

void printTreeIncreasingRecursive(Node *current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			printTreeIncreasingRecursive(current->leftChild);
		}
		cout << current->value << " ";
		if (current->rightChild)
		{
			printTreeIncreasingRecursive(current->rightChild);
		}
	}
}

void printTreeDecreasingRecursive(Node *current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			printTreeDecreasingRecursive(current->rightChild);
		}
		cout << current->value << " ";
		if (current->rightChild)
		{
			printTreeDecreasingRecursive(current->leftChild);
		}
	}
}

void printTreeIncreasing(Tree *tree)
{
	printTreeIncreasingRecursive(tree->root);
}

void printTreeDecreasing(Tree *tree)
{
	printTreeDecreasingRecursive(tree->root);
}

Tree *createTree()
{
	return new Tree;
}