namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private class Node<T>
        {
            public Node<T> Previous { get; set; }
            public Node<T> Next { get; set; }
            public T Item { get; set; }
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>();

            if (this.Count == 0)
            {
                this.tail = this.head = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }
            //else if (this.Count == 1)
            //{
            //    this.head = newNode;
            //    this.head.Next = this.tail;
            //    this.tail.Previous = this.head;
            //}
            //else
            //{
            //    var previousHead = this.head;
            //    this.head = newNode;
            //    this.head.Next = previousHead;
            //    previousHead.Previous = this.head;

            //}

            this.head.Item = item;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>();
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }
            this.tail.Item = item;
            this.Count++;
        }

        public T GetFirst()
        {
            CheckIsEmpty();
            return this.head.Item;
        }

        public T GetLast()
        {
            CheckIsEmpty();
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            CheckIsEmpty();
            var itemToReturn = this.head.Item;
            this.head = this.head.Next;
            this.Count--;
            return itemToReturn;
        }

        public T RemoveLast()
        {
            CheckIsEmpty();
            var itemToReturn = this.tail;

            if (itemToReturn.Previous == null)
            {
                this.tail = this.head = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }
           
            this.Count--;
            return itemToReturn.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The Collection is empty");
            }
        }
    }
}