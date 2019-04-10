using System;
using LinkedList;

namespace Table
{
    public class HashTable
    {
        private int MAX = 100;
        private List[] myTable;
        private int filledCells = 0;

        public HashTable()
        {
            myTable = new List[MAX];
            InitializeTable(myTable, MAX);
        }

        private void InitializeTable(List[] table, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                table[i] = new List();
            }
        }

        private void Resize()
        {
            MAX += 100;
            List[] temp = new List[MAX];
            InitializeTable(temp, MAX);
            foreach (List list in myTable)
            {
                for (int i = 1; i <= list.GetSize(); ++i)
                {
                    int hash = HashCode(list.GetDataOn(i));
                    temp[hash].Add(list.GetDataOn(i), temp[hash].GetSize() + 1);
                }
            }
            myTable = temp;
        }

        private int HashCode(string data)
            => Math.Abs(data.GetHashCode()) % MAX;

        public void Add(string data)
        {
            if (filledCells / MAX > 0.72)
            {
                Resize();
            }
            int hash = HashCode(data);
            if (myTable[hash].GetSize() == 0)
            {
                ++filledCells;
            }
            myTable[hash].Add(data, myTable[hash].GetSize() + 1);
        }

        public bool Delete(string data)
        {
            int hash = HashCode(data);
            int position = GetPosition(data, hash);
            if (position == -1)
            {
                return false;
            }
            myTable[hash].Delete(position);
            return true;
        }

        public bool Exists(string data)
            => (GetPosition(data, HashCode(data)) != -1);

        public void Clear()
        {
            for (int i = 0; i < MAX; ++i)
            {
                myTable[i] = null;
            }
        }

        private int GetPosition(string data, int hash)
        {
            int size = myTable[hash].GetSize();
            for (int i = 1; i <= size; ++i)
            {
                if (myTable[hash].GetDataOn(i) == data)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}