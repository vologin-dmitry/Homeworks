#include "pch.h"
#include <iostream>
#include <fstream>
#include <locale.h>

using namespace std;

void takingCities(int **graphTable, int *cityBelongsTo, int capitalCount, int citiesCount);
void fillTable(int **graphTable, int roadsCount, ifstream &file);
void matrixDelete(int *data[], int size);
bool tests();

int main()
{
	setlocale(LC_ALL,"russian");
	if (tests())
	{
		cout << "Что то пошло не так !!";
		return 1;
	}
	ifstream file("FileToWork.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Файла не существет";
		return 1;
	}
	int roadsCount = -1;
	int citiesCount = -1;
	file >> roadsCount;
	file >> citiesCount;
	int *cityBelongsTo = new int[citiesCount] {};
	int** graphTable = new int*[citiesCount] {};
	for (int i = 0; i < citiesCount; i++)
	{
		graphTable[i] = new int[citiesCount] {};
	}
	fillTable(graphTable, roadsCount, file);
	int capitalCount = -1;
	file >> capitalCount;
	for (int i = 0; i < capitalCount; i++)
	{
		int capitalNumber = -1;
		file >> capitalNumber;
		cityBelongsTo[capitalNumber - 1] = i + 1;
	}
	takingCities(graphTable, cityBelongsTo, capitalCount, citiesCount);
	matrixDelete(graphTable, citiesCount);
	for (int i = 0; i < citiesCount; ++i)
	{
		cout << i + 1 << "ой город" << "\t" << cityBelongsTo[i] << endl;
	}
	delete[] graphTable;
	delete[] cityBelongsTo;
	file.close();
	return 0;
}

void takingCities(int **graphTable, int *cityBelongsTo, int capitalCount, int citiesCount)
{
	int i = 0;
	int freeCities = citiesCount - capitalCount;
	while (freeCities > 0)
	{
		int min = numeric_limits<int>::max();
		int minIndex = -1;
		int country = (i % capitalCount) + 1;
		for (int j = 0; j < citiesCount; j++)
		{
			if (cityBelongsTo[j] == country)
			{
				int used = 0;
				for (int z = 0; z < citiesCount; z++)
				{
					if (graphTable[j][z] > 0 && graphTable[j][z] < min && cityBelongsTo[z] == 0)
					{
						min = graphTable[j][z];
						minIndex = z;
					}
					else if (cityBelongsTo[z] != 0 || graphTable[j][z] == 0)
					{
						++used;
					}
				}
				if (used == citiesCount)
				{
					cityBelongsTo[j] *= -1;
				}
			}
		}
		if (min != numeric_limits<int>::max())
		{
			cityBelongsTo[minIndex] = country;
			--freeCities;
		}
		++i;
	}
	for (int i = 0; i < citiesCount; i++)
	{
		cityBelongsTo[i] = abs(cityBelongsTo[i]);
	}
}

void fillTable(int **graphTable, int roadsCount, ifstream &file)
{
	for (int i = 0; i < roadsCount; i++)
	{
		int city1 = 0;
		int city2 = 0;
		int len = 0;
		file >> city1;
		file >> city2;
		file >> len;
		graphTable[city1 - 1][city2 - 1] = len;
		graphTable[city2 - 1][city1 - 1] = len;
	}
}

void matrixDelete(int *data[], int size)
{
	for (int i = 0; i < size; i++)
	{
		delete data[i];
	}

}

bool tests()
{
	const int SIZE = 5;
	int **graphTable = new int *[SIZE] {};
	graphTable[0] = new int [SIZE]{ 0, 8, 0, 5, 0 };
	graphTable[1] = new int[SIZE]{ 8, 0, 6, 0, 11 };
	graphTable[2] = new int[SIZE]{ 0, 6, 0, 7, 0 };
	graphTable[3] = new int[SIZE]{ 5, 0, 7, 0, 12 };
	graphTable[4] = new int[SIZE]{ 0, 11, 0, 12, 0 };
	int answers[SIZE]{ 1, 1, 3, 3, 2 };
	int cityBelongsTo[SIZE]{};
	cityBelongsTo[0] = 1;
	cityBelongsTo[4] = 2;
	cityBelongsTo[3] = 3;
	takingCities(graphTable, cityBelongsTo, 3, SIZE);
	for (int i = 0; i < SIZE; i++)
	{
		if (answers[i] != cityBelongsTo[i])
		{
			matrixDelete(graphTable, SIZE);
			delete[] graphTable;
			return 1;
		}
	}
	matrixDelete(graphTable, SIZE);
	delete[] graphTable;
	return 0;
}