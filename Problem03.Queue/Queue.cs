namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T item)
            {
                this.Item = item;
            }
            public T Item { get; set; }
            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            CheckForEmptyCollection();
            var elementToDequeue = this.head;
            this.head = this.head.Next;
            Count--;
            return elementToDequeue.Item;
        }

        public T Peek()
        {
            CheckForEmptyCollection();
            return this.head.Item;
        }

        public bool Contains(T item)
        {
            var current = this.head;
            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return this.head.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void CheckForEmptyCollection()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Can not perform operation on empty collection.");
            }
        }
    }
}