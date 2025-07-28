
namespace Problems.Queen;

class Queens
{
    private char[,] _Board=new char[,]{};

    internal Queens(int size)
    {
        _Board = new char[size,size];
    }


    private void QueenTrace(int i, int j, char from, char to)
    {
        for(int k=0;k<_Board.GetLength(1);k++)
            if(_Board[i,k]==from)
                _Board[i,k]=to;
        for(int k=1;k<_Board.GetLength(0);k++)
        {
            if(i-k>=0)
            {
                if(_Board[i-k,j]==from)
                    _Board[i-k,j]=to;
                if(j-k>=0)
                    if(_Board[i-k,j-k]==from)
                        _Board[i-k,j-k]=to;
                if(j+k<_Board.GetLength(1))
                    if(_Board[i-k,j+k]==from)
                        _Board[i-k,j+k]=to;
            }
            if(i+k<_Board.GetLength(0))
            {
                if(_Board[i+k,j]==from)
                    _Board[i+k,j]=to;
                if(j-k>=0)
                    if(_Board[i+k,j-k]==from)
                        _Board[i+k,j-k]=to;
                if(j+k<_Board.GetLength(1))
                    if(_Board[i+k,j+k]==from)
                        _Board[i+k,j+k]=to;
            }
        }
    }
    

    internal bool Place(int i=0,int j=0)
    {
        if(i==_Board.GetLength(0))
            return true;
        if(j==_Board.GetLength(1))
            return false;

        if(_Board[i,j]!='\0')
            return Place(i,j+1);

        _Board[i,j]='Q';
        QueenTrace(i,j,'\0',(i+"")[0]);

        bool res = Place(i+1,0);

        if(res)
        {
            for(int x=0;x<_Board.GetLength(0);x++)
            {
                for(int y=0;y<_Board.GetLength(1);y++)
                    Console.Write((_Board[x,y]=='Q')?'Q':'-');
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        _Board[i,j]='\0';
        QueenTrace(i,j,(i+"")[0],'\0');
        return Place(i,j+1);
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter how many queens to place : ");
        int count = int.Parse(Console.ReadLine());
        Queens obj = new Queens(count);
        Console.WriteLine(count+" x "+count+" board is created. Now can i place the queens in possible permutations? yes/no : ");
        string resp = Console.ReadLine();
        if(resp=="yes")
            obj.Place();
        else    
            Console.WriteLine("Thank you.");
    }
}
