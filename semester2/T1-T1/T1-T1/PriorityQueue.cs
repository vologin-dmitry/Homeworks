using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorutyQueueNamespace
{
    /// <summary>
    /// Queue, where element with higher priority goes earlier, then element with lower priority
    /// </summary>
    public class PriorityQueue
    {
        private Node head;
        public int Size { get; set; }
        public class Node
        {
            public Node Next { get; set; }
            public string Data { get; }
            public int Prior { get; }

            public Node(Node next, string data, int prior)
            {
                Next = next;
                Data = data;
                Prior = prior;
            }
        }

        /// <summary>
        /// Add an element in queue
        /// </summary>
        /// <param name="data">Data, you want to add to the queue</param>
        /// <param name="prior">Priority of your data</param>
        public void Enqueue(string data, int prior)
        {
            if (Size == 0)
            {
                head = new Node(null, data, prior);
                ++Size;
                return;
            }
            if (prior > head.Prior)
            {
                ++Size;
                head = new Node(head, data, prior);
            }
            var current = head;
            while (current.Next != null && prior >= current.Next.Prior)
            {
                current = current.Next;
            }
            current.Next = new Node(current.Next, data, prior);
            ++Size;
        }

        /// <summary>
        /// Returns data with highest priority
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            if (Size == 0)
            {
                throw new RemovingElementOfEmptyQueue();
            }
            var toReturn = head.Data;
            head = head.Next;
            --Size;
            return toReturn;
        }

        /// <summary>
        /// Deletes all elements of your queue
        /// </summary>
        public void Clear()
        {
            Size = 0;
            head = null;
        }
    }
}
