using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    public class StoyanovDictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        public const int inticalCapacity = 16;
        public const float LoadFactor = 0.75f;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity
        {
            get { return slots.Length; }
        }

        public StoyanovDictionary()
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[inticalCapacity];
        }

        public StoyanovDictionary(int capacity = inticalCapacity)
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumber = FindSlotNumber(key);

            if (slots[slotNumber] == null)
            {
                slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists" + key);
                }
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            slots[slotNumber].AddLast(newElement);
            Count++;
        }

        private int FindSlotNumber(TKey key)
        {
            var slotNumber = Math.Abs(key.GetHashCode())%slots.Length;
            return slotNumber;
        }

        private void GrowIfNeeded()
        {
            if ((float) (Count + 1)/Capacity > LoadFactor)
            {
                Grow();
            }
        }

        private void Grow()
        {
            var newHashTable = new StoyanovDictionary<TKey, TValue>(2*Capacity);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }

            slots = newHashTable.slots;
            Count = newHashTable.Count;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            GrowIfNeeded();
            int slotNumber = FindSlotNumber(key);

            if (slots[slotNumber] == null)
            {
                slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var element in slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            slots[slotNumber].AddLast(newElement);
            Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException("Key not found");
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get { return Get(key); }
            set { AddOrReplace(key, value); }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = Find(key);
            if (element == null)
            {
                value = default(TValue);
                return false;
            }

            value = element.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = FindSlotNumber(key);
            var elements = slots[slotNumber];
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = FindSlotNumber(key);
            LinkedList<KeyValue<TKey, TValue>> elements = slots[slotNumber];
            if (elements != null)
            {
                var currentElement = elements.First;
                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        elements.Remove(currentElement);
                        Count--;
                        return true;
                    }

                    currentElement = currentElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[inticalCapacity];
            Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get { return this.Select(element => element.Key); }
        }

        public IEnumerable<TValue> Values
        {
            get { return this.Select(element => element.Value); }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var elements in slots)
            {
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}