using System;

namespace Calculator
{
    public interface IStack
    {
        /// <summary>
        /// Putting the value into stack
        /// </summary>
        /// <param name="data">Value to put in the stack</param>
        void Push(string data);

        /// <summary>
        /// Returns the last item from the stack.
        /// </summary>
        /// <returns>Last item from the stack</returns>
        string Pop();


        /// <returns>Size of the stack</returns>
        int GetSize();

        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>True if stack is emty, false otherwise</returns>
        bool IsEmpty();

        /// <summary>
        /// Clears stack
        /// </summary>
        void Clear();
    }
}
