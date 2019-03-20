using System;

namespace Calculator
{
    interface IStack
    {
        void Push(string data);

        string Pop();

        int GetSize();

        bool IsEmpty();

        void Clear();
    }
}
