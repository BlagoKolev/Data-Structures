namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private class Node<T>
        {
            public Node(T item)
            {
                this.Item = item;
            }
            public T Item { get; set; }
            public Node<T> Next { get; set; }
        }
        public int Count { get; set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                var current = this.head;
                this.head = newNode;
                this.head.Next = current;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.Count++;
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

            if (this.Count == 1)
            {
                this.Count--;
                return this.head.Item;
            }
            this.head = this.head.Next;
            this.Count--;
            return this.head.Item;
        }

        public T RemoveLast()
        {
            CheckIsEmpty();
            if (this.Count == 1)
            {
                this.Count--;
                return this.head.Item;
            }
            else
            {
                var current = this.head;
                var previous = current;
                Node<T> last;
                while (true)
                {
                    last = this.tail;
                    if (current.Next == null)
                    {
                        this.tail = previous;
                        this.tail.Next = null;
                        break;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
                this.Count--;
                return last.Item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}