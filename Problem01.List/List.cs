namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
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
            if (IsFull())
            {
                Grow();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var current in this.items.Take(this.Count))
            {
                if (current.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
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

            if (IsFull())
            {
                Grow();
            }

            for (int i = this.Count; i >= index; i--)
            {
                if (i == index)
                {
                    this.items[i] = item;
                    this.Count++;
                    break;
                }
                var temp = this.items[i - 1];
                this.items[i] = temp;
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }
                    this.Count--;
                    return true;
                }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private bool IsFull()
        {
            return this.Count == this.items.Length;
        }
        private void Grow()
        {
            var newItems = new T[this.items.Length * 2];
            Array.Copy(this.items, newItems, this.Count);
            this.items = newItems;
        }
    }
}