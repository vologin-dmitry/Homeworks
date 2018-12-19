#include "pch.h"
#include "KMP.h"

void prefixFunc(const std::string line,int prefixes[])
{
	int size = line.length();
	prefixes[0] = 0;
 	int j = 0;
	int i = 1;
	while (i < size)
	{
		if (line[i] == line[j])
		{
			prefixes[i] = ++j;
			++i;
		}
		else if (j == 0)
		{
			prefixes[i] = 0;
			++i;
		}
		else
		{
			j = prefixes[j - 1];
		}
	}
}

int kmpSearch(const std::string line, const std::string text, const int prefixes[])
{
	int size = line.length();
	int textPointer = 0;
	int linePointer = 0;
	while (linePointer < size && textPointer < text.length())
	{
		if (line[linePointer] == text[textPointer])
		{
			++textPointer;
			++linePointer;
			continue;
		}
		else if (linePointer == 0)
		{
			++textPointer;
		}
		else
		{
			linePointer = prefixes[linePointer - 1];
		}
	}
	if (linePointer == size)
	{
		return textPointer - linePointer + 1;
	}
	else
	{
		return -1;
	}
}

int KMPAlgorithm(const std::string line, const std::string text)
{
	int *prefixes = new int[line.length()];
	prefixFunc(line, prefixes);
	int toReturn = kmpSearch(line, text, prefixes);
	delete[] prefixes;
	return toReturn;
}