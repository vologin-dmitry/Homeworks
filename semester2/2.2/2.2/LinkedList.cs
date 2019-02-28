using System;

 namespace LinkedList
{
    class List
    {
        private class Node
        {
            internal string data = "";
            internal Node next = null;

             public Node()
            {
            }

             public Node(string data, Node next)
            {
                this.data = data;
                this.next = next;
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
            if (size == 0)
            {
                ++size;
                tail = head = new Node(data, null);
                return true;
            }
            if (position == size + 1)
            {
                ++size;
                tail.next = new Node(data, null);
                tail = tail.next;
                return true;
            }
            if (position == 1)
            {
                ++size;
                head = new Node(data, head);
                return true;
            }
            Node current = head;
            for (int i = 1; i != position - 1; ++i)
            {
                current = current.next;
            }
            Node newNode = new Node(data, current.next);
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
            if (position > size || position < 0)
            {
                return false;
            }
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
                return null;
            }
            Node current = head;
            for (int i = 1; i != position; ++i)
            {
                current = current.next;
            }
            return current;
        }

         public void Clear()
        {
            head = null;
            size = 0;
            tail = null;
        }
    }
}