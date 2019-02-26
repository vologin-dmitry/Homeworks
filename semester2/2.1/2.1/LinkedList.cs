using System;

namespace LinkedList
{
    class LinkedList
    {
        private class Node
        {
            internal string data = "";
            internal Node next = null;

            public Node()
            {
            }

            public Node(string data)
            {
                data = this.data;
            }
        }

        private Node head = null;
        private Node tail = null;
        private int size = 0;

        public bool IsEmpty() => size == 0;

        public int GetSize() => size;

        public bool Add(string data, int position)
        {
            if (position > size + 1 || position < 1)
            {
                return false;
            }
            if (position == size + 1)
            {
                ++size;
                tail.next = new Node(data);
                tail = tail.next;
                return true;
            }
            if (position == 1)
            {
                ++size;
                head = new Node(data);
            }
            Node current = head;
            for (int i = 1; i != position - 1; ++i)
            {
                current = current.next;
            }
            Node newNode = new Node(data);
            newNode = current.next;
            current.next = newNode;
            ++size;
            return true;
        }

        public bool Delete(int position)
        {
            if (position < 1 || position > size)
            {
                return false;
            }
            if (size == 1)
            {
                head = tail = null;
                --size;
                return true;
            }
            if (position == 1)
            {
                --size;
                head = head.next;
                return true;
            }
            Node current = head;
            for (int i = 1; i != position - 1; ++i)
            {
                current = current.next;
            }
            current.next = current.next.next;
            --size;
            return false;
        }

        public string GetDataOn(int position)
        {
            Node current = GetNode(position);
            if (current == null)
            {
                return $"Ошибка, проверьте корректность данных";
            }
            return current.data;
        }

        public bool SetDataOn(string data, int position)
        {
            Node current = GetNode(position);
            if (current == null)
            {
                return false;
            }
            current.data = data;
            return true;
        }

        private Node GetNode(int position)
        {
            if (position < 1 || position > size)
            {
                return null
            }
            Node current = head;
            for (int i = 0; i != position; ++i)
            {
                current = current.next;
            }
            return current;
        }
    }
}
