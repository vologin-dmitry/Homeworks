using System;

namespace Calculator
{
    /// <summary>
    /// The interface implemented by the stacks with Push, Pop, GetSize, IsEmpty and Clear methods.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Putting the value into stack
        /// </summary>
        /// <param name="data">Value to put in the stack</param>
        void Push(int data);

        /// <summary>
        /// Returns the last item from the stack.
        /// </summary>
        /// <returns>Last item from the stack</returns>
        int Pop();


        /// <returns>Size of the stack</returns>
        int Size { get;}

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
