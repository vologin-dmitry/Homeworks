#pragma once

struct Tree;

bool exists(Tree *tree, int value);
bool isEmpty(Tree *tree);
bool add(Tree* tree, int const  data);
bool remove(Tree* tree, int const value);
void deleteTree(Tree *tree);
void printTreeIncreasing(Tree *tree);
void printTreeDecreasing(Tree *tree);
Tree *createTree();