
namespace Collections.Generic.MLL;


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


sealed class MyLinkedList<T>{

	Node<T>?  _Header = null;
	
	internal void Add(T newdata)
	{
		Node<T> newNode = new Node<T>(newdata);
		
		if( _Header == null)
			 _Header = newNode;
		else
		{
			Node<T> curNode = _Header;
			while(curNode.Next != null)
				curNode = curNode.Next;
			curNode.Next = newNode;
		}
	}
	
	internal T Get(int index)
	{
		if (_Header == null)
			throw new IndexOutOfRangeException();

		Node<T> curNode = _Header;
		while(index > 0)
		{
			if(curNode.Next != null)
				curNode = curNode.Next;
			else
				throw new IndexOutOfRangeException();
			index--;
		}

		return curNode.Data;
	}
	
	internal int Find(T data)
	{
		int index = 0;
		Node<T>? curNode = _Header;

		if(curNode != null)
	  	{
		  if(curNode.Data+"" == data+"")
		    return index;
		  while(curNode.Next != null)
		  {
		    curNode = curNode.Next;
		    index++;
			if(curNode.Data+"" == data+"")
				return index;
		  }
	  	}

		return -1;
	}
	
	internal void Insert(T data, int index)
	{
		Node<T>? curNode = _Header, newNode = new Node<T>(data);

		if(index == 0)
		{
			if(curNode == null)
			 _Header = newNode;
			else
			{
				newNode.Next = curNode;
			 _Header = newNode;
			}
		}
		else
		{
			index--;
			if(curNode == null)
				throw new IndexOutOfRangeException();
			while(index > 0)
			{
				if(curNode.Next == null)
			    	throw new IndexOutOfRangeException();
				curNode = curNode.Next;
				index--;
			}
			newNode.Next = curNode.Next;
			curNode.Next = newNode;
		}
	}
	
	internal void Remove(T data)
	{
		if (_Header != null)
		{
	  		if (_Header.Data+"" == data+"")
	    	 _Header = _Header.Next;
	  		else
		  	{
	    		Node<T>? curNode = _Header.Next, prevNode = _Header;
				while(curNode != null)
			  	{
	    			if(curNode.Data+"" == data+"")
	    			{
			   			prevNode.Next =  curNode.Next;
	      				break;
		    		}
					prevNode = curNode;
					curNode = curNode.Next;
			  	}
	  		}
		}
	}
	
}


public class Program
{
    public static void Main(string[] args)
    {
		MyLinkedList<string> obj = new MyLinkedList<string>();
		string? input = Console.ReadLine();
		if(input != null)
		obj.Add(input);
		Console.WriteLine(obj.Get(0));
    }
}
