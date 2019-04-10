using System;

namespace Calculator
{
    public class StackOnArray : IStack
    {
        private const int MAX = 100;
        private int[] stack = new int[MAX];
        public int Size { get; private set; } = 0;

        public void Push(int data)
        {
            if (Size < 99)
            {
                stack[Size] = data;
                ++Size;
            }
            else
            {
                Console.WriteLine("Ошибка ! Стек переполнен");
            }
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
