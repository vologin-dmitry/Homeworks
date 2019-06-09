using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace H8_T2
{
    /// <summary>
    /// A generic set that does not contain duplicate elements
    /// </summary>
    /// <typeparam name="T">Type of items in set</typeparam>
    public class GenericSet<T> : ISet<T> where T : IComparable
    {
        /// <summary>
        /// Returns the number of items in the set
        /// </summary>
        public int Count { get; private set; }

        private Node head;

        /// <summary>
        /// Set element
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Data of set element
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Left child of element. Lower than current
            /// </summary>
            public Node LeftChild { get; set; }

            /// <summary>
            /// Right child of element. Greater than current
            /// </summary>
            public Node RightChild { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            public Node() { }

            /// <summary>
            /// The constructor that takes the value of the element
            /// </summary>
            /// <param name="data">Data of new list node</param>
            public Node(T data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// Adds an item to the set
        /// </summary>
        /// <param name="value">Item, you want to put in the list</param>
        /// <returns>False if the item is already in the set, true otherwise</returns>
        public bool Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                ++Count;
                return true;
            }
            return RecursiveAddHelper(head, value);
        }

        /// <summary>
        /// Returns if your list in readonly mode
        /// </summary>
        public bool IsReadOnly => false;

        private bool RecursiveAddHelper(Node node, T value)
        {
            if (node.Data.CompareTo(value) < 0)
            {
                if (node.RightChild != null)
                {
                    return RecursiveAddHelper(node.RightChild, value);
                }
                node.RightChild = new Node(value);
                ++Count;
                return true;
            }
            if (node.Data.CompareTo(value) > 0)
            {
                if (node.LeftChild != null)
                {
                    return RecursiveAddHelper(node.LeftChild, value);
                }
                node.LeftChild = new Node(value);
                ++Count;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears your set
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Checks if the entered item is in the queue
        /// </summary>
        /// <param name="item">Your item</param>
        /// <returns>True, if item exists in the set and false otherwise<</returns>
        public bool Contains(T item)
            => SearchValue(item) != null;

        private Node SearchValue(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.CompareTo(value) > 0)
                {
                    current = current.LeftChild;
                    continue;
                }
                if (current.Data.CompareTo(value) < 0)
                {
                    current = current.RightChild;
                    continue;
                }
                if (current.Data.CompareTo(value) == 0)
                {
                    return current;
                }
            }
            return null;
        }

        /// <summary>
        /// Copies all items from set to an array
        /// </summary>
        /// <param name="array">Array to which you want to copy items</param>
        /// <param name="arrayIndex">The array index from which elements are written to it</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var i = arrayIndex;
            foreach (var element in this)
            {
                array[i] = element;
                ++i;
            }
        }

        /// <summary>
        /// Removes an element from set
        /// </summary>
        /// <param name="value">Value of item, you want to remove</param>
        /// <returns>True, if removing was successfull, false otherwise</returns>
        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }
            head = RemoveRecursive(head, value);
            --Count;
            return true;
        }

        private Node RemoveRecursive(Node current, T value)
        {
            if (current.Data.CompareTo(value) < 0)
            {
                current.RightChild = RemoveRecursive(current.RightChild, value);
            }
            else if (current.Data.CompareTo(value) > 0)
            {
                current.LeftChild = RemoveRecursive(current.LeftChild, value);
            }
            else
            {
                if (current.LeftChild == null && current.RightChild == null)
                {
                    return null;
                }
                else if (current.LeftChild != null && current.RightChild == null)
                {
                    return current.LeftChild;
                }
                else if (current.LeftChild == null && current.RightChild != null)
                {
                    return current.RightChild;
                }
                else
                {
                    current.Data = GetRightMax(current.LeftChild);
                    current.LeftChild = RemoveRecursive(current.LeftChild, current.Data);
                }
            }
            return current;
        }

        private T GetRightMax(Node current)
        {
            while (current.RightChild != null)
            {
                current = current.RightChild;
            }
            return current.Data;
        }

        /// <summary>
        /// Returns enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
            => GetPreorderEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetPreorderEnumerator();

        /// <summary>
        /// Checks if two sets are equal
        /// </summary>
        /// <param name="other">Second set</param>
        /// <returns>True, if sets are equal, false otherwise</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        private IEnumerator<T> GetPreorderEnumerator()
            => new PreorderEnumerator(head) as IEnumerator<T>;

        /// <summary>
        /// Combines two sets
        /// </summary>
        /// <param name="other">The set with which you want to combine your set</param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Intersects two sets
        /// </summary>
        /// <param name="other">The set with which you want to intersect your set</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            foreach (var node in this)
            {
                if (!other.Contains(node))
                {
                    Remove(node);
                }
            }
        }

        /// <summary>
        /// Removes elements contained in both the first and second sets from the first set
        /// </summary>
        /// <param name="other">The set that you want to except from your set</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var node in other)
            {
                Remove(node);
            }
        }

        /// <summary>
        /// Removes the elements contained in the first and second sets from the first set
        /// and adds the elements contained only in the second set to the first set
        /// </summary>
        /// <param name="other">The set that you want to symmetrically except from your set</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            foreach (var node in other)
            {
                if (Contains(node))
                {
                    Remove(node);
                }
                else
                {
                    Add(node);
                }
            }
        }

        /// <summary>
        /// Checks if your set is a superset of the entered set
        /// </summary>
        /// <param name="other">Set that may be a subset of yours</param>
        /// <returns>True, if your set is superset of entered set, false otherwise</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
            => FirstIsSubsetOfSecond(other, this);

        /// <summary>
        /// Checks if your set is a subset of the entered set
        /// </summary>
        /// <param name="other">Set that may be a superset of yours</param>
        /// <returns>True, if your set is subrset of entered set, false otherwise</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
            => FirstIsSubsetOfSecond(this, other);

        private bool FirstIsSubsetOfSecond(IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var node in first)
            {
                if (!second.Contains(node))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if your set is a proper subset of the entered set
        /// </summary>
        /// <param name="other">Set that may be a proper superset of yours</param>
        /// <returns>True, if your set is a proper subrset of entered set, false otherwise</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
            => FirstIsProperSubsetOfSecond(this, other);

        /// <summary>
        /// Checks if your set is a proper superset of the entered set
        /// </summary>
        /// <param name="other">Set that may be a proper subset of yours</param>
        /// <returns>True, if your set is a proper superset of entered set, false otherwise</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
            => FirstIsProperSubsetOfSecond(other, this);

        private bool FirstIsProperSubsetOfSecond(IEnumerable<T> first, IEnumerable<T> second)
        {
            return (FirstIsSubsetOfSecond(first, second) && first.Count() < second.Count());
        }

        /// <summary>
        /// Checks if two sets intersect
        /// </summary>
        /// <param name="other">The set that you want to check for intersection with your set</param>
        /// <returns>True, if the sets intersect, false otherwise</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var node in other)
            {
                if (Contains(node))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Enumerator that allows walking on the tree in preorder
        /// </summary>
        private class PreorderEnumerator : IEnumerator<T>
        {

            private Node head;
            private Node current;
            private Stack<Node> stack;

            /// <summary>
            /// Creates enumerator
            /// </summary>
            /// <param name="head">First element for enumerator</param>
            public PreorderEnumerator(Node head)
            {
                current = new Node();
                stack = new Stack<Node>();
                this.head = head;
                stack.Push(head);
            }

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
                current = stack.Count() != 0 ? stack.Pop() : current = null;
                if (current != null)
                {
                    if (current.RightChild != null)
                    {
                        stack.Push(current.RightChild);
                    }
                    if (current.LeftChild != null)
                    {
                        stack.Push(current.LeftChild);
                    }
                }
                return current != null;
            }

            /// <summary>
            /// Sets next element to head
            /// </summary>
            public void Reset()
            {
                current.RightChild = head;
            }
        }
    }
}
