
namespace Collections.MAL;


sealed class Node<T>
{
	internal T Data {get; set;}
	internal Node<T>? Next {get; set;}
	
	internal Node(T data)
	{
		this.Data = data;
		this.Next = null;
	}

}

sealed class MyArrayList
{
    private Node<object>? _Header;
    private uint _Count;

    internal MyArrayList()
    {
        _Header = null;
        _Count = 0;
    }


    private Node<object> GetAddress(uint index)
    {
        if(_Header is null)
            throw new ArgumentOutOfRangeException("You trying to access element in the empty list");
        Node<object> curNode = _Header;
        while(index>0)
        {
            if(curNode.Next is null)
                throw new ArgumentOutOfRangeException("index is ouside the bound or length of the list");
            curNode = curNode.Next;
            index--;
        }
        return curNode;
    }

    internal uint Count
    {
        get
        {
            return _Count;
        }
    }

    internal object this[uint index]
    {
        get
            {return GetAddress(index).Data;}

        set
        {
            if(_Header is null)
                throw new ArgumentOutOfRangeException("You trying to overwrite the element in the empty list");
            GetAddress(index).Data = value;
        }
    }

    internal void Add(object data)
    {
        Node<object> newNode = new Node<object>(data);
        if(_Header is null)
            _Header = newNode;
        else
        {
            GetAddress(_Count-1).Next = newNode;
            _Count++;
        }
    }

    internal void Insert(uint index, object data)
    {
        Node<object> insertNode = new Node<object>(data);
        if(index == 0)
        {
            insertNode.Next = GetAddress(0);
            _Header = insertNode;
        }
        else
        {
            Node<object> prevNode = GetAddress(index-1);
            insertNode.Next = prevNode.Next;
            prevNode.Next = insertNode;
        }
        _Count++;
    }

    internal void Remove(object data)
    {
        if(_Header == null)
           return;
        Node<object> curNode = _Header, prevNode = _Header;
        while(curNode.Next is not null)
        {
            if(curNode.Data == data)
            {
                prevNode.Next = curNode.Next;
                _Count--;
                break;
            }
            prevNode = curNode;
            curNode = curNode.Next;
        }
    }

    internal int IndexOf(object data)
    {
        if(_Header == null)
           return -1;
        Node<object> curNode = _Header;
        int index = 0;
        while(curNode.Next is not null)
        {
            if(curNode.Data == data)
            {
                return index;
            }
            curNode = curNode.Next;
            index++;
        }
        return -1;
    }

    internal bool Contains(object data)
    {
        if(IndexOf(data)<0)
            return false;
        return true;
    }

    
}
