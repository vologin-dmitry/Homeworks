#pragma once

#include <fstream>
#include <string>
#include <iostream>

struct Tree;

void buildTree(const std::string &line, Tree* tree);
int countTree(Tree *tree);
void printTree(Tree *tree);
void deleteTree(Tree *tree);
Tree *createTree();