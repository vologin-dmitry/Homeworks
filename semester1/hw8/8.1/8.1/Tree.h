#pragma once

#include <string>

using namespace std;

struct Node
{
	int height = 0;
	int key = 0;
	string value = "";
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};


struct Tree
{
	Node *root = nullptr;
};


void addNode(Node *&node, string data, int key);
int getHeight(Node *node);
Node *findNodeByKey(Tree *tree, int key);
string findStringByKey(Tree *tree, int key);
bool exists(Tree *tree, int key);
Node *smallRotateLeft(Node *&first);
Node *smallRotateRight(Node *&first);
Node *balance(Node *node);
int height(Node* node);
int difference(Node *node);
void remove(Node *&node, int key);
void deleteTree(Node *current);