using System;

namespace LinkedList
{
    public class List
    {
        private class Node
        {
            internal string Data { get; set; }

            internal Node Next { get; set; }

            public Node()
            {
            }

            public Node(string data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;
        private Node tail;
        public int Size { get; private set; }

        public bool IsEmpty() => Size == 0;

        public bool Add(string data, int position)
        {
            if (position > Size + 1 || position < 1)
            {
                return false;
            }
            if (Size == 0)
            {
                ++Size;
                tail = new Node(data, null);
                head = new Node(data, null);
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

        public bool Delete(int position)
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

        public string GetDataOn(int position)
        {
            Node current = GetNode(position);
            if (current == null)
            {
                return $"Ошибка, проверьте корректность данных";
            }
            return current.Data;
        }

        public bool SetDataOn(string data, int position)
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

        public void Clear()
        {
            head = null;
            Size = 0;
            tail = null;
        }
    }
}