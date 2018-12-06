#pragma once

#include <fstream>
#include <string>
#include <iostream>

using namespace std;

struct Node
{
	string value = "";
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
	Node *parent = nullptr;
};


struct Tree
{
	Node *root = nullptr;
};


void buildTree(string line, Tree*& tree);
Node *nodeFree(Node* node);
int countTree(Node *node);
void printTree(Node *node);
void deleteTree(Node *&node);