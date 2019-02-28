using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class HashTable
    {
        const int MAX = 100;
        LinkedList.List[] MyTable = new LinkedList.List[MAX];

        public HashTable()
        {
            for (int i = 0; i < MAX; ++i)
            {
                MyTable[i] = new LinkedList.List();
            }
        }

        private int HashCode(string data)
        {
            return Math.Abs(data.GetHashCode()) % MAX;
        }

        public void Add(string data)
        {
            int hash = HashCode(data);
            MyTable[hash].Add(data, MyTable[hash].GetSize() + 1);
        }

        public bool Delete(string data)
        {
            int hash = HashCode(data);
            int position = GetPosition(data, hash);
            if (position == -1)
            {
                return false;
            }
            MyTable[hash].Delete(position);
            return true;
        }

        public bool Exists(string data)
        {
            return (GetPosition(data, HashCode(data)) != -1);
        }

        public void Clear()
        {
            for (int i = 0; i < MAX; ++i)
            {
                MyTable[i] = null;
            }
        }

        private int GetPosition(string data, int hash)
        {
            int size = MyTable[hash].GetSize();
            for (int i = 1; i <= size; ++i)
            {
                if (MyTable[hash].GetDataOn(i) == data)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
