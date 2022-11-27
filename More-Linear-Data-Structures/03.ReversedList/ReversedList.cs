namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (CheckIsFull())
            {
                Grow();
            }
            if (this.Count == 0)
            {
                this.items[this.Count] = item;
            }
            else
            {
                for (int i = this.Count; i > 0; i--)
                {
                    this.items[i] = this.items[i - 1];
                }
                this.items[0] = item;
            }
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i <= this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            if (CheckIsFull())
            {
                Grow();
            }
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index > -1)
            {
                for (int i = index; i < this.Count; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.Count--;
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool CheckIsFull()
        {
            return this.items.Length == this.Count;
        }

        private void Grow()
        {
            var newLength = this.items.Length * 2;
            var newArray = new T[newLength];
            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }
            this.items = newArray;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
        }
    }
}