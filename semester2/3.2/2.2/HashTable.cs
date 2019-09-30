using System;
using LinkedList;

namespace Table
{
    /// <summary>
    /// Hash table with strings as data
    /// </summary>
    public class HashTable
    {
        private int MAX = 100;
        private List[] myTable;
        private int filledCells;
        private IHash hashFunction;

        /// <summary>
        /// Default constructor that initializes the table and sets hash function as default visual studio function
        /// </summary>
        public HashTable()
        {
            myTable = new List[MAX];
            InitializeTable(myTable, MAX);
            hashFunction = new DefaultHashFunction();
        }

        public HashTable(IHash hash)
        {
            myTable = new List[MAX];
            InitializeTable(myTable, MAX);
            this.hashFunction = hash;
        }

        private void InitializeTable(List[] table, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                table[i] = new List();
            }
        }

        /// <summary>
        /// Increases the table if it is too full
        /// </summary>
        private void Resize()
        {
            MAX += 100;
            var temp = new List[MAX];
            InitializeTable(temp, MAX);
            foreach (List list in myTable)
            {
                for (int i = 1; i <= list.Size; ++i)
                {
                    int hash = HashCode(list.GetDataOn(i), hashFunction);
                    temp[hash].Add(list.GetDataOn(i), temp[hash].Size + 1);
                }
            }
            myTable = temp;
        }

        private int HashCode(string data, IHash hashFunction)
            => Math.Abs(hashFunction.HashCode(data) % MAX);

        /// <summary>
        /// Adds an element to a hash table
        /// </summary>
        /// <param name="data">String to add</param>
        public void Add(string data)
        {
            if (filledCells / MAX > 0.72)
            {
                Resize();
            }
            int hash = HashCode(data, hashFunction);
            if (myTable[hash].Size == 0)
            {
                ++filledCells;
            }
            myTable[hash].Add(data, myTable[hash].Size + 1);
        }

        /// <summary>
        /// Deletes an element from hash table
        /// </summary>
        /// <param name="data">String do delete</param>
        /// <returns>True, if the operation is successful, false if there is no such element</returns>
        public bool Delete(string data)
        {
            int hash = HashCode(data, hashFunction);
            int position = GetPosition(data, hash);
            if (position == -1)
            {
                return false;
            }
            myTable[hash].Delete(position);
            return true;
        }

        /// <summary>
        /// Checks if an element exists in a table
        /// </summary>
        /// <param name="data">String to search in hash table</param>
        /// <returns>True, if an element exists, false if there is no such element</returns>
        public bool Exists(string data)
            => (GetPosition(data, HashCode(data, hashFunction)) != -1);

        /// <summary>
        /// Deletes all data from hash table
        /// </summary>
        public void Clear()
        {
            myTable = new List[MAX];
            InitializeTable(myTable, MAX);
        }

        private int GetPosition(string data, int hash)
        {
            int size = myTable[hash].Size;
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