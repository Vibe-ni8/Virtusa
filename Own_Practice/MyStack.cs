
namespace Collections.Generic.Stack;


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



sealed class MyStack<T>{

	Node<T>? _Header = null;
	
	internal void Push(T newData)
	{
		Node<T> newNode = new Node<T>(newData);
		
		newNode.Next = _Header;
		_Header = newNode;
	}

	internal T? Peek()
	{
	  	if(_Header == null)
	    	return default(T);
		return _Header.Data;
	}
	
	
	internal void Pop()
	{
	  	if(_Header == null)
	    	throw new NullReferenceException("Stack is Empty");
	  	_Header = _Header.Next;
	}
}
