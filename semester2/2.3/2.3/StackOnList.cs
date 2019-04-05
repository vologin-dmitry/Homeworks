using System;

namespace Calculator
{
    public class StackOnList : IStack
    {
        private StackElement end = null;
        private int size = 0;

        private class StackElement
        {
            internal string data = "";
            internal StackElement previous = null;

            public StackElement(string data, StackElement previous)
            {
                this.data = data;
                this.previous = previous;
            }
        }

        public void Push(string data)
        {
            ++size;
            if (end == null)
            {
                end = new StackElement(data, null);
                return;
            }
            end = new StackElement(data, end);
        }

        public string Pop()
        {
            string toReturn = end.data;
            end = end.previous;
            --size;
            return toReturn;
        }

        public bool IsEmpty() => size == 0;

        public int GetSize() => size;

        public void Clear()
        {
            size = 0;
            end = null;
        }
    }
}
