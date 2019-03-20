using System;

namespace Calculator
{
    class StackOnArray : IStack
    {
        private const int MAX = 100;
        private string[] stack = new string[MAX];
        int size = 0;

        public void Push(string data)
        {
            stack[size] = data;
            ++size;
        }

        public string Pop()
        {
            --size;
            return stack[size];
        }

        public bool IsEmpty() => size == 0;

        public int GetSize() => size;

        public void Clear()
        {
            if (size != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    stack[i] = null;
                }
                size = 0;
            }
        }
    }
}
