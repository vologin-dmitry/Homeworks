#include "pch.h"
#include "Tree.h"
#include <iostream>

using namespace std;

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
	if (searchValue(tree, value) != nullptr)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool isEmpty(Tree *tree)
{
	if (tree->root == nullptr)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool add(Tree* tree, int const  data)
{
	if (isEmpty(tree))
	{
		tree->root = new Node{ data, nullptr, nullptr };
	}
	else
	{
		if (!exists(tree, data))
		{
			addNode(tree->root, data);
		}
		else
		{
			return false;
		}
	}
	return true;
}


void addNode(Node* node, int value)
{
	if (node->value > value && node->leftChild != nullptr)
	{
		addNode(node->leftChild, value);
	}
	else if (node->value < value && node->rightChild != nullptr)
	{
		addNode(node->rightChild, value);
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

bool remove(Tree* tree, int const value)
{
	if (!exists(tree, value))
	{
		return false;
	}
	removeRecursion(tree->root, value);
	return true;
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

void deleteTree(Node *current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			deleteTree(current->leftChild);
		}
		if (current->rightChild != nullptr)
		{
			deleteTree(current->rightChild);
		}
		Node *temp = current;
		delete temp;
		current = nullptr;
	}
	else return;
}

void printTreeIncreasing(Node *current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			printTreeIncreasing(current->leftChild);
		}
		cout << current->value << " ";
		if (current->rightChild)
		{
			printTreeIncreasing(current->rightChild);
		}
	}
}

void printTreeDecreasing(Node *current)
{
	if (current != nullptr)
	{
		if (current->leftChild != nullptr)
		{
			printTreeDecreasing(current->rightChild);
		}
		cout << current->value << " ";
		if (current->rightChild)
		{
			printTreeDecreasing(current->leftChild);
		}
	}
}

