using System;

namespace Calculator
{
    public class StackOnArray : IStack
    {
        private int MAX = 100;
        private int[] stack;
        public int Size { get; private set; }

        public StackOnArray()
        {
            stack = new int[MAX];
        }

        public void Push(int data)
        {
            if (Size == MAX)
            {
                Resize();
            }
            stack[Size] = data;
            ++Size;
        }

        private void Resize()
        {
            MAX += 100;
            int[] temp = new int[MAX];
            for (int i = 0; i < MAX - 100; ++i)
            {
                temp[i] = stack[i];
            }
            stack = temp;
        }

        public int Pop()
        {
            if (Size <= 0)
            {
                throw new InvalidOperationException();
            }
            --Size;
            return stack[Size];
        }

        public bool IsEmpty() => Size == 0;

        public void Clear()
        {
            if (Size != 0)
            {
                for (int i = 0; i < Size; ++i)
                {
                    stack[i] = 0;
                }
                Size = 0;
            }
        }
    }
}
