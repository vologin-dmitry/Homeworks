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
            int i = 0;
            Node current = head;
            Node NewNode = new Node(data);
            while (i < position - 1)
            {
                current = current.next;
                ++i;
            }
            NewNode.next = current.next;
            current.next = NewNode;
            ++size;
            return true;
        }

        public 
    }
}
