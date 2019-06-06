using System;
using System.Collections;
using System.Collections.Generic;

namespace H8_T1
{
    /// <summary>
    /// A simple list containing items of the specified type
    /// </summary>
    /// <typeparam name="T">Type of items stored in the list</typeparam>
    public class ListOnGenerics<T> : IList<T>
    {
        private Node head;
        private Node tail;

        /// <summary>
        /// Returns the number of items in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Returns if your list in readonly mode
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Returns the value stored in a list at a given position
        /// </summary>
        /// <param name="index">Position of value, you want to get</param>
        /// <returns>Value on given position of list</returns>
        public T this[int index]
        {
            get
            {
                var current = head;
                if (!CorrectIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                var current = head;
                if (!CorrectIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        /// <summary>
        /// List element
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Data of list element
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Next element in the list
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            public Node() { }

            /// <summary>
            /// The constructor that takes the value of the element and the next element
            /// </summary>
            /// <param name="data">Data of new list element</param>
            /// <param name="next">The element next to this</param>
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        /// <summary>
        /// Finds the index of the value entered
        /// </summary>
        /// <param name="value">Value whose index you want to know</param>
        /// <returns>Index of the value if it is in the list, "-1" if such value is not in the list</returns>
        public int IndexOf(T value)
        {
            var current = head;
            for (int i = 0; i < Count; ++i)
            {
                if (Equals(value, current.Data))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        /// <summary>
        /// Inserts an item at the specified position.
        /// </summary>
        /// <param name="position">The position to which you want to put the value</param>
        /// <param name="value">The value you want to put on a given position</param>
        public void Insert(int position, T value)
        {
            if (!CorrectIndex(position))
            {
                return;
            }
            if (Count == 0)
            {
                ++Count;
                head = new Node(value, null);
                tail = head;
                return;
            }
            if (position == Count)
            {
                ++Count;
                tail.Next = new Node(value, null);
                tail = tail.Next;
                return;
            }
            if (position == 0)
            {
                ++Count;
                head = new Node(value, head);
                return;
            }
            Node current = head;
            for (int i = 1; i < position; ++i)
            {
                current = current.Next;
            }
            var newNode = new Node(value, current.Next);
            current.Next = newNode;
            ++Count;
        }

        /// <summary>
        /// Removes an item at a given position
        /// </summary>
        /// <param name="index">Position of element, you want to remove</param>
        public void RemoveAt(int index)
        {
            if (!CorrectIndex(index))
            {
                return;
            }
            if (Count == 1)
            {
                head = null;
                tail = null;
                --Count;
                return;
            }
            if (index == 1)
            {
                --Count;
                head = head.Next;
                return;
            }
            Node current = head;
            for (int i = 1; i != index - 1; ++i)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            --Count;
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="value">Value, you want to put in the list</param>
        public void Add(T value)
            => Insert(Count, value);

        /// <summary>
        /// Clears your list
        /// </summary>
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        /// <summary>
        /// Checks if the entered value is in the list
        /// </summary>
        /// <param name="item">Your data</param>
        /// <returns>True, if data exists in the list and false otherwise</returns>
        public bool Contains(T item)
            => IndexOf(item) != -1;

        /// <summary>
        /// Copies values from a list to an array
        /// </summary>
        /// <param name="array">Array to which you want to copy values</param>
        /// <param name="arrayIndex">The array index from which elements are written to it</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = head;
            while (current != null)
            {
                array[arrayIndex] = current.Data;
                ++arrayIndex;
                current = current.Next;
            }
        }

        /// <summary>
        /// Removes an element in list
        /// </summary>
        /// <param name="value">Value, you want to remove</param>
        /// <returns>True, if removing was successfull</returns>
        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }
            if (Equals(head.Data, value))
            {
                head = head.Next;
                --Count;
                return true;
            }
            var current = head;
            while (current.Next != null)
            {
                if (Equals(current.Next, value))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private bool CorrectIndex(int index)
            => (index >= 0 && index <= Count);

        /// <summary>
        /// Returns enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
            => GetListEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetListEnumerator();

        private IEnumerator<T> GetListEnumerator()
            => new ListEnumerator(head) as IEnumerator<T>;

        /// <summary>
        /// Allows you walk through the list
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        { 

            private Node head;

            /// <summary>
            /// Creates enumerator
            /// </summary>
            /// <param name="head">First element for enumerator</param>
            public ListEnumerator(Node head)
            {
                current = new Node();
                this.head = head;
                current.Next = head;
            }

            private Node current;

            /// <summary>
            /// Current value
            /// </summary>
            public T Current
                => current.Data;
            
            object IEnumerator.Current
                => Current;
            
            /// <summary>
            /// Disposes enumerator
            /// </summary>
            public void Dispose()
            {
                // This is not necessary
            }

            /// <summary>
            /// Go to next element
            /// </summary>
            /// <returns>True, if current element is not null, false otherwise</returns>
            public bool MoveNext()
            {
                current = current.Next;
                return current != null;
            }

            /// <summary>
            /// Sets current to head
            /// </summary>
            public void Reset()
            {
                current.Next = head;
            }
        }
    }
}