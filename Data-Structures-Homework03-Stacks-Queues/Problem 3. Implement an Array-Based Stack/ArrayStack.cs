using System;
using System.Linq;

public class ArrayStack<T>
{
    private T[] _elements;
    private const int _InitialCapacity = 16;
    private int _size;

    public ArrayStack(int capacity = _InitialCapacity)
    {
        _elements = new T[capacity];
        Capacity = capacity;
    }

    public int Capacity { get; private set; }

    public int Count
    {
        get
        {
            return _size;
        }

        private set
        {
            _size = value;
        }
    }

    public void Push(T element)
    {
        if (_size == _elements.Length)
        {
            Grow();
        }

        _elements[_size] = element;
        _size++;
    }

    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("No elements in the stack");
        }

        T output = _elements[_size - 1];

        if (_size == 1)
        {
            _elements = new T[_InitialCapacity];
        }
        else
        {
            T[] newArray = new T[_elements.Length];
            Array.Copy(_elements, newArray, _size - 1);
            _elements = newArray;
        }

        _size--;

        return output;
    }

    public T[] ToArray()
    {
        return _elements;
    }

    private void Grow()
    {
        Capacity = _elements.Length * 2;
        var newArray = new T[Capacity];
        Array.Copy(_elements, newArray, _elements.Count());
        _elements = newArray;
    }
}
