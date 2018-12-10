#include "pch.h"
#include "Tree.h"
#include <iostream>

using namespace std;

void addNode(Node *&node, string data, int key)
{
	if (node == nullptr)
	{
		node = new Node{ 1, key, data, nullptr, nullptr };
		return;
	}
	else
	{
		if (key > node->key)
		{
			addNode(node->rightChild, data, key);
		}
		else
		{
			if(key < node->key)
			{
				addNode(node->leftChild, data, key);
			}
			else
			{
				node->value = data;
			}
		}
	}
	node = balance(node);
}

int getHeight(Node *node)
{
	if (node == nullptr)
	{
		return 0;
	}
	if (node->leftChild == nullptr && node->rightChild == nullptr)
	{
		return 1;
	}
	else
	{
		if (height(node->leftChild) > height(node->rightChild))
		{
			return node->leftChild->height + 1;
		}
		else
		{
			return node->rightChild->height + 1;
		}
	}
}

Node *findNodeByKey(Tree *tree, int key)
{
	Node *current = tree->root;
	while (current != nullptr)
	{
		if (key > current->key)
		{
			current = current->rightChild;
		}
		else
		{
			if (key < current->key)
			{
				current = current->leftChild;
			}
			else
			{
				return current;
			}
		}
	}
	return nullptr;
}

string findStringByKey(Tree *tree, int key)
{
	Node *temp = findNodeByKey(tree, key);
	if (temp != nullptr)
	{
		return temp->value;
	}
	else
	{
		return "";
	}
}

bool exists(Tree *tree, int key)
{
	return (findNodeByKey(tree, key) != nullptr);
}

Node *smallRotateLeft(Node *&first)
{
	Node *second = first->rightChild;
	first->rightChild = second->leftChild;
	second->leftChild = first;
	first->height = getHeight(first);
	second->height = getHeight(second);
	return second;
}

Node *smallRotateRight(Node *&first)
{
	Node *second = first->leftChild;
	first->leftChild = second->rightChild;
	second->rightChild = first;
	first->height = getHeight(first);
	second->height = getHeight(second);
	return second;
}

Node *balance(Node *node)
{
	node->height = getHeight(node);
	if (difference(node) > 1)
	{
		if (difference(node->leftChild) < 0)
		{
			node->leftChild = smallRotateLeft(node->leftChild);
		}
		return smallRotateRight(node);
	}
	if (difference(node) < -1)
	{
		if (difference(node->rightChild) > 0)
		{
			node->rightChild = smallRotateRight(node->rightChild);
		}
		return smallRotateLeft(node);
	}
	node->height = getHeight(node);
	return node;
}

int height(Node* node)
{
	if (node == nullptr)
	{
		return 0;
	}
	else
	{
		return node->height;
	}
}

int difference(Node *node)
{
	return height(node->leftChild) - height(node->rightChild);
}

Node *minimum(Node* current)
{
	auto* temp = current;
	temp = temp->rightChild;
	while (temp->leftChild != nullptr)
	{
		temp = temp->leftChild;
	}
	return temp;
}

void remove(Node *&node, int key)
{
	if (node == nullptr)
	{
		return;
	}
	else if (node->key > key)
	{
		remove(node->leftChild, key);
	}
	else if (node->key < key)
	{
		remove(node->rightChild, key);
	}
	else
	{
		if (node->leftChild == nullptr && node->rightChild == nullptr)
		{
			auto *temp = node;
			node = nullptr;
			delete temp;
		}
		else if (node->leftChild != nullptr && node->rightChild == nullptr)
		{
			auto *temp = node;
			node = node->leftChild;
			delete temp;
		}
		else if (node->leftChild == nullptr && node->rightChild != nullptr)
		{
			auto *temp = node;
			node = node->rightChild;
			delete temp;
		}
		else
		{
			node->value = minimum(node)->value;
			node->key = minimum(node)->key;
			remove(node->rightChild, node->key);
		}

	}
	if (node != nullptr)
	{
		balance(node);
	}
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