using System;

namespace LinkedList
{
    /// <summary>
    /// List with strings as data
    /// </summary>
    public class List
    {
        private class Node
        {
            internal string Data { get; set; }
            internal Node Next { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            public Node()
            {
            }

            /// <summary>
            /// Creates a node with the entered values
            /// </summary>
            /// <param name="data">Data of new node</param>
            /// <param name="next">Pointer to a next node in list</param>
            public Node(string data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;
        private Node tail;
        public int Size { get; private set; }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>True, if list is empty, false, if list is not empty</returns>
        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// Adds an item to the list at a given position
        /// </summary>
        /// <param name="data">The string you want to add</param>
        /// <param name="position">Position to which you want to add an element</param>
        /// <returns></returns>
        public virtual bool Add(string data, int position)
        {
            if (position > Size + 1 || position < 1)
            {
                return false;
            }
            if (Size == 0)
            {
                ++Size;
                head = new Node(data, null);
                tail = head;
                return true;
            }
            if (position == Size + 1)
            {
                ++Size;
                tail.Next = new Node(data, null);
                tail = tail.Next;
                return true;
            }
            if (position == 1)
            {
                ++Size;
                head = new Node(data, head);
                return true;
            }
            Node current = head;
            for (int i = 1; i != position - 1; ++i)
            {
                current = current.Next;
            }
            var newNode = new Node(data, current.Next);
            current.Next = newNode;
            ++Size;
            return true;
        }

        /// <summary>
        /// Deletes an element at a given position.
        /// </summary>
        /// <param name="position">Position of element, you want to delete</param>
        /// <returns>True, if deletion is succesfull, false if such element not found</returns>
        public virtual bool Delete(int position)
        {
            if (position < 1 || position > Size)
            {
                return false;
            }
            if (Size == 1)
            {
                head = null;
                tail = null;
                --Size;
                return true;
            }
            if (position == 1)
            {
                --Size;
                head = head.Next;
                return true;
            }
            Node current = head;
            for (int i = 1; i != position - 1; ++i)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            --Size;
            return false;
        }

        /// <summary>
        /// Returns data on given position
        /// </summary>
        /// <param name="position">The position of the element whose value you want to get</param>
        /// <returns>Value of the element at this position</returns>
        public string GetDataOn(int position)
        {
            Node current = GetNode(position);
            if (current == null)
            {
                return $"Ошибка, проверьте корректность данных";
            }
            return current.Data;
        }

        /// <summary>
        /// Changes string on given position
        /// </summary>
        /// <param name="data">The string to which you want to change the string at a given position</param>
        /// <param name="position">Position of a string, you want to change</param>
        /// <returns>True, if operation was successful, false otherwise</returns>
        public virtual bool SetDataOn(string data, int position)
        {
            if (position > Size || position < 0)
            {
                return false;
            }
            Node current = GetNode(position);
            if (current == null)
            {
                return false;
            }
            current.Data = data;
            return true;
        }
        protected int GetPosition(string data)
        {
            Node current = head;
            int i = 1;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return i;
                }
                current = current.Next;
                ++i;
            }
            return -1;
        }

        private Node GetNode(int position)
        {
            if (position < 1 || position > Size)
            {
                return null;
            }
            Node current = head;
            for (int i = 1; i != position; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Removes all elements in list
        /// </summary>
        public void Clear()
        {
            head = null;
            Size = 0;
            tail = null;
        }
    }
}