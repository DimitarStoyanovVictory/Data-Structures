public class Node<T>
{
    public T Value { get; private set; }
    public Node<T> NextNode { get; private set; }

    public Node(T value, Node<T> nextNode = null)
    {
        Value = value;
        NextNode = nextNode;
    }
}
