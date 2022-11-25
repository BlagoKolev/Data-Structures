namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] array;
        private int startIndex;
        private int endIndex;

        public CircularQueue()
        {
            this.array = new T[DEFAULT_CAPACITY];
        }

        public int Count { get; set; }

        public T Dequeue()
        {
            CheckIsEmpty();
            var elementToReturn = this.array[startIndex];
            this.array[startIndex] = default;
            this.startIndex = (this.startIndex + 1) % this.array.Length;
            this.Count--;
            return elementToReturn;
        }

        public void Enqueue(T item)
        {
            if (CheckIsFull())
            {
                Grow();
            }
            this.array[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.array.Length;
            this.Count++;
        }

        public T Peek()
        {
            CheckIsEmpty();
            return this.array[startIndex];
        }

        public T[] ToArray()
        {
            var newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[(this.startIndex + i) % this.array.Length];
            }
            this.array = newArray;
            return this.array;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[(startIndex + i) % this.array.Length];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool CheckIsFull()
        {
            return this.Count == this.array.Length;
        }
        private void Grow()
        {
            var newLength = this.array.Length * 2;
            var newArray = new T[newLength];
            
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[(this.startIndex + i) % this.array.Length];
            }
            this.array = newArray;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CheckIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
        }
    }

}
