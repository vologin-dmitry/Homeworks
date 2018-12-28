#include "pch.h"
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

void snail(int rows, int columns, vector<vector<int>> matrix);
void withoutZeros(int rows, int columns, vector<vector<int>> matrix);
void sqare(int rows, int columns, vector<vector<int>> matrix);

int main()
{
	ifstream file("in.txt", ios::in);
	int rows = -1;
	file >> rows;
	int columns = -1;
	file >> columns;
	vector<vector<int>> matrix(rows, vector<int>(columns));
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			file >> matrix[i][j];
		}
	}
	file.close();
	snail(rows, columns, matrix);
	sqare(rows, columns, matrix);
	withoutZeros(rows, columns, matrix);
	return 0;
}

void snail(int rows, int columns, vector<vector<int>> matrix)
{
	int left = 0;
	int right = columns - 1;
	int upper = 0;
	int bottom = rows - 1;
	ofstream out1("out1.txt", ios::out);
	int i = 0;
	int j = 0;
	while (left < right || bottom > upper)
	{
		i = left;
		if (left <= right && upper <= bottom)
		{
			while (i <= right)
			{
				cout << matrix[upper][i] << " ";
				out1 << matrix[upper][i] << " ";
				i++;
			}
		}
		upper++;
		i = upper;
		if (left <= right && upper <= bottom)
		{
			while (i <= bottom)
			{
				cout << matrix[i][right] << " ";
				out1 << matrix[i][right] << " ";
				i++;
			}
		}
		right--;
		i = right;
		if (left <= right && upper <= bottom)
		{
			while (i >= left)
			{
				cout << matrix[bottom][i] << " ";
				out1 << matrix[bottom][i] << " ";
				i--;
			}
		}
		bottom--;
		i = bottom;
		if (left <= right && upper <= bottom)
		{
			while (i >= upper)
			{
				cout << matrix[i][left] << " ";
				out1 << matrix[i][left] << " ";
				i--;
			}
		}
		left++;
	}
	out1.close();
}

void withoutZeros(int rows, int columns, vector<vector<int>> matrix)
{
	ofstream out2("out2.txt", ios::out);
	int i = 0;
	while (i < rows * columns)
	{
		if (matrix[i / columns][i % columns] != 0)
		{
			out2 << matrix[i / columns][i % columns] << " ";
		}
		++i;
	}
	out2.close();
}

void sqare(int rows, int columns, vector<vector<int>> matrix)
{
	ofstream out3("out3.txt", ios::out);
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			out3 << matrix[i][j] * matrix[i][j] << " ";
		}
		out3 << '\n';
	}
	out3.close();
}