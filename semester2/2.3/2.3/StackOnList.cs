using System;

namespace Calculator
{
    public class StackOnList : IStack
    {
        private StackElement end = null;
        public int Size { get; private set; } = 0;

        private class StackElement
        {
            public int Data { get; set; } = 0;
            public StackElement Previous { get; set; } = null;

            public StackElement(int data, StackElement previous)
            {
                this.Data = data;
                this.Previous = previous;
            }
        }

        public void Push(int data)
        {
            ++Size;
            end = new StackElement(data, end);
        }

        public int Pop()
        {
            if (Size <= 0)
            {
                throw new InvalidOperationException();
            }
            int toReturn = end.Data;
            end = end.Previous;
            --Size;
            return toReturn;
        }

        public bool IsEmpty() => Size == 0;


        public void Clear()
        {
            Size = 0;
            end = null;
        }
    }
}
