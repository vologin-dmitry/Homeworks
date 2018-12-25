#pragma once

#include <string>

struct Tree;

void addNode(Tree *&tree, const std::string &data, int key);
std::string findStringByKey(Tree *tree, int key);
bool exists(Tree *tree, int key);
void remove(Tree *tree, int key);
void deleteTree(Tree *tree);
Tree *createTree();