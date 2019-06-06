using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8_T1
{
    public class ListOnGenerics<T> : IList<T>
    {
        private Node head;
        private Node tail;
        public int Size { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;
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

        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node() { }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        public int IndexOf(T value)
        {
            var current = head;
            for (int i = 0; i < Size; ++i)
            {
                if (Equals(value, current.Data))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public void Insert(int position, T value)
        {
            if (!CorrectIndex(position))
            {
                return;
            }
            if (Size == 0)
            {
                ++Size;
                head = new Node(value, null);
                tail = head;
                return;
            }
            if (position == Size)
            {
                ++Size;
                tail.Next = new Node(value, null);
                tail = tail.Next;
                return;
            }
            if (position == 0)
            {
                ++Size;
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
            ++Size;
        }

        public void RemoveAt(int index)
        {
            if (!CorrectIndex(index))
            {
                return;
            }
            if (Size == 1)
            {
                head = null;
                tail = null;
                --Size;
                return;
            }
            if (index == 1)
            {
                --Size;
                head = head.Next;
                return;
            }
            Node current = head;
            for (int i = 1; i != index - 1; ++i)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            --Size;
            return;
        }

        public void Add(T value)
            => Insert(Size, value);

        public void Clear()
        {
            Size = 0;
            head = null;
            tail = null;
        }

        public bool Contains(T item)
            => IndexOf(item) != -1;

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

        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }
            if (Equals(head.Data, value))
            {
                head = head.Next;
                --Size;
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
            => (index >= 0 && index <= Size);

        public IEnumerator<T> GetEnumerator()
            => GetListEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetListEnumerator();

        private IEnumerator<T> GetListEnumerator()
            => new ListEnumerator(head) as IEnumerator<T>;

        private class ListEnumerator : IEnumerator<T>
        { 

            private Node head;

            public ListEnumerator(Node head)
            {
                current = new Node();
                this.head = head;
                current.Next = head;
            }

            private Node current;

            public T Current
                => current.Data;
            

            object IEnumerator.Current
                => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                current = current.Next;
                return current != null;
            }

            public void Reset()
            {
                current.Next = head;
            }
        }
    }
}