#pragma once

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


Node *searchValue(Tree* tree, int value);
bool exists(Tree *tree, int value);
bool isEmpty(Tree *tree);
bool add(Tree* tree, int const  data);
void addNode(Node* node, int value);
bool remove(Tree* tree, int const value);
void removeRecursion(Node *&node, int value);
int maximum(Node* current);
void deleteTree(Node *current);
void printTreeIncreasing(Node *current);
void printTreeDecreasing(Node *current);

