namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node<T>
        {
            public Node(T element)
            {
                this.Item = element;
            }
            public T Item { get; set; }
            public Node<T> Next { get; set; }
        }

        private Node<T> top;

        public int Count { get; set; }

        public void Push(T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = this.top;
            this.top = newNode;
            this.Count++;
        }

        public T Pop()
        {
            CheckIsStackEmpty();
            var elementToPop = this.top;
            this.top = this.top.Next;
            this.Count--;
            return elementToPop.Item;
        }

        public T Peek()
        {
            CheckIsStackEmpty();
            return this.top.Item;
        }

        public bool Contains(T item)
        {
            var current = this.top;
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
            var current = this.top;

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

        private void CheckIsStackEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Unable to perform this operation. The Stack is empty");
            }
        }
    }
}