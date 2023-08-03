
// type parameter T in angle brackets

public interface IGenericList<T>
{
    public void AddHead(T t);
    public int GetCount();
    public IEnumerator<T> GetEnumerator();
}
public class GenericList<T> : IGenericList<T>
{
    // The nested class is also generic on T.
    private class Node
    {
        // T used in non-generic constructor.
        public Node(T t)
        {
            next = null;
            data = t;
        }

        private Node? next;
        public Node? Next
        {
            get { return next; }
            set { next = value; }
        }

        // T as private member data type.
        private T data;

        // T as return type of property.
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
    }

    private int count;

    private Node? head;

    // constructor
    public GenericList()
    {
        head = null;
        count = 0;
    }

    // T as method parameter type:
    public void AddHead(T t)
    {
        var n = new Node(t)
        {
            Next = head
        };
        head = n;
        count++;
    }

    public int GetCount()
    {
        return count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}