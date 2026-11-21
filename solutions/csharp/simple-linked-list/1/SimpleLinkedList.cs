using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value;
        public Node Next;

        public Node(T value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node _head;

    public int Count { get; private set; }

    public SimpleLinkedList()
    {
    }

    public SimpleLinkedList(T value)
    {
        Push(value);
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        if (values == null)
            return;

        foreach (var value in values)
            Push(value);
    }

    public void Push(T value)
    {
        _head = new Node(value, _head);
        Count++;
    }

    public T Pop()
    {
        if (_head == null)
            throw new InvalidOperationException("Список порожній.");

        T value = _head.Value;
        _head = _head.Next;
        Count--;
        return value;
    }

    public SimpleLinkedList<T> Reverse()
    {
        var reversed = new SimpleLinkedList<T>();

        for (var node = _head; node != null; node = node.Next)
            reversed.Push(node.Value);

        return reversed;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var node = _head; node != null; node = node.Next)
            yield return node.Value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}