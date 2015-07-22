using System;

public class LinkedStack<T>
{
    private const int defaultCapacity = 16;
    private Node<T> firstNote;
    private int _size;
    
    public LinkedStack(int capacity = defaultCapacity)
    {
        Capacity = capacity;
    }

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

    public int Capacity { get; private set; }

    public void Push(T element)
    {
        if (_size == Capacity)
        {
            Grow();
        }

        firstNote = new Node<T>(element, firstNote);
        _size++;
    }

    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("No elements in the stack");
        }

        var outputNode = firstNote;
        firstNote = firstNote.NextNode;
        _size--;

        return outputNode.Value;
    }

    public void Grow()
    {
        Capacity = _size * 2;
    }

    //public T[] ToArray()
    //{
    //    var array = new T[_size];
    //    array[0] = firstNote.Value;

    //    for (int indexNode = 1; indexNode < array.Length; indexNode++)
    //    {
    //        array[indexNode] = firstNote.NextNode.Value;
    //    }

    //    return array;
    //}
}
