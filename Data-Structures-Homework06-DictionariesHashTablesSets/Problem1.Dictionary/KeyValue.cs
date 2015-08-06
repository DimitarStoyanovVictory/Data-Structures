using System;

namespace Dictionary
{
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override bool Equals(object other)
        {
            var element = (KeyValue<TKey, TValue>) other;
            var equals = Object.Equals(Key, element.Key) && Object.Equals(Value, element.Value);
            return equals;
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(Key.GetHashCode(), Value.GetHashCode());
        }

        private int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        public override string ToString()
        {
            return string.Format(" [{0} -> {1}]", Key, Value);
        }
    }
}