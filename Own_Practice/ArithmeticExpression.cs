
namespace Expressions;


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



sealed class ArithmeticExpression
{
  
    MyStack<int> _Operands = new MyStack<int>();
    MyStack<char> _Operators = new MyStack<char>();
  
    int PriorityCheck(char curOperater)
    {
        switch(curOperater)
        {
            case '+':return 1;
            case '-':return 2;
            case '*':return 3;
            case '/':return 4;
            case '^':return 6;
            case '(':return 0;
            case ')':return 7;
            default :return -1;
        }
    }
  
    int Operation(int value1, int value2, char curOperater)
    {
        switch(curOperater)
        {
            case '+':return value1+value2;
            case '-':return value1-value2;
            case '*':return value1*value2;
            case '/':return value1/value2;
            case '^':
            {
                while(value2>1)
                {
                    value1 *= value1;
                    value2--;
                }
                return value1;
            }
            default :return 0;
        }
    }
  
    void SemiExpressionSolve()
    {
        char currentOperator;
        do{
            currentOperator = _Operators.Peek();
            if( currentOperator != ')' && currentOperator != '(' )
            {
                int value2 = _Operands.Peek();
                _Operands.Pop();
                int value1 = _Operands.Peek();
                _Operands.Pop();
                _Operands.Push( Operation(value1, value2, currentOperator) );
            }
            _Operators.Pop();
        }while( _Operators.Peek() != '\0' && PriorityCheck(currentOperator) > PriorityCheck(_Operators.Peek()) );
    }
  
    internal int Solve(string equation)
    {
        string symbols = "(+-*/^)";
        string number = "";
    
        foreach(char e in equation)
        {
            if( symbols.Contains(e+"") )
            {
                //enter _Operands in stack 
                if( e != '(' && e != ')' )
                {
                    _Operands.Push(int.Parse(number));
                    number = "";
                }
        
                if(_Operators.Peek()=='\0')
                {
                    _Operators.Push(e);
                }
        
                else if( e == '(' )
                {
                    _Operators.Push(e);
                }
                //only push the operator into the stack when the current operator priority is higher than or equal to the previous operator priority
                else if(PriorityCheck(e) >= PriorityCheck(_Operators.Peek()))
                {
                    _Operators.Push(e);
                }
                //all the conditions failed then it will execute. the expression before current operator is solved.
                else
                {
                    SemiExpressionSolve();
                    _Operators.Push(e);
                }
            }
      
            else
            {
                number += e;
            }
        }
    
        int finalValue = int.Parse(number);
        while(_Operands.Peek() != 0)
        {
            _Operands.Push(finalValue);
            SemiExpressionSolve();
            finalValue = _Operands.Peek();
            _Operands.Pop();
        }
    
        return finalValue;
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Arithmetic Expression");
        string? input = Console.ReadLine();
        if(input != "" && input != null)
        {
            Console.Write("Answer:");
		    Console.WriteLine(new ArithmeticExpression().Solve(input));
        }
    }
}
