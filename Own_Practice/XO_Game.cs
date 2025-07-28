
namespace Gaming.XO;

sealed class XO_Game
{

  internal XO_Game()
  {
    Console.WriteLine("\nWElcome to XO Game!\n\tEnter number(1 to 9) when your turns come.\n\t\'-1\' for UNDO.");
  }

  private char[,] _Board = new char[3,3]{{' ',' ',' '},{' ',' ',' '},{' ',' ',' '}};
  private ValueTuple<int,int>[]  _Index = new ValueTuple<int,int>[9]{(0,0),(0,1),(0,2),(1,0),(1,1),(1,2),(2,0),(2,1),(2,2)};
  

  private void Display()
  {
    Console.WriteLine();
    for(int i=0;i<3;i++)
    {
      for(int j=0;j<3;j++)
        Console.Write(_Board[i,j]+((j!=2)?"|":""));
      Console.WriteLine((i!=2)?"\n-+-+-":"\n");
    }
  }
  

  private bool CheckStrick(int position, char symbol)
  {
    int i=_Index[position-1].Item1, j=_Index[position-1].Item2;
    switch(position)
    {
      case 1:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) || (_Board[i+1,j+1]==symbol && _Board[i+2,j+2]==symbol) )?true:false;
      case 2:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) )?true:false;
      case 3:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) || (_Board[i+1,j-1]==symbol && _Board[i+2,j-2]==symbol) )?true:false;
      case 4:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) )?true:false;
      case 5:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) || (_Board[i+1,j+1]==symbol && _Board[i-1,j-1]==symbol) || (_Board[i+1,j-1]==symbol && _Board[i-1,j+1]==symbol) )?true:false;
      case 6:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) )?true:false;
      case 7:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) || (_Board[i-1,j+1]==symbol && _Board[i-2,j+2]==symbol) )?true:false;
      case 8:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) )?true:false;
      case 9:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) || (_Board[i-1,j-1]==symbol && _Board[i-2,j-2]==symbol) )?true:false;
    }
    return false;
  }
  


  internal void Play()
  {

    Stack<int> undo = new Stack<int>();

    for(int i=0; i<9; i++)
    {

L:    Display();
      char symbol = (i%2==0)?'X':'O';
      int position=0;
      bool again;

      do{
        again = false;
        Console.Write(symbol+"'s turn (enter any number 1 to 9): ");
        try{
        position = int.Parse(""+Console.ReadLine());
        }catch(FormatException){
          Console.WriteLine("Invalid Input Format");
          again=true;
          continue;
        }

//undo logic START
        if(position==-1)
        {
          if(i==0 || i==1)
          {
            Console.WriteLine("No UNDO available");
            again = true;
            continue;
          }
          else
          {
            Console.Write("{0}'s try to UNDO one turn. Can you permit?(yes/no): ",symbol);
            if(Console.ReadLine()+"".Trim().ToLower()!="yes")
            {
              again = true;
              continue;
            }
            _Board[_Index[undo.Peek()-1].Item1,_Index[undo.Pop()-1].Item2] = ' ';
            _Board[_Index[undo.Peek()-1].Item1,_Index[undo.Pop()-1].Item2] = ' ';
            i-=2;
            goto L;
          }
        }
//undo logic END

        if(position<1 || position>9)
        {
          Console.WriteLine("Invalid Position");
          again = true;
          continue;
        }

        if("XO".Contains(_Board[_Index[position-1].Item1,_Index[position-1].Item2]))
        {
          Console.WriteLine("Another Coin is there, try another place.");
          again = true;
        }

      }while( again );

      _Board[_Index[position-1].Item1,_Index[position-1].Item2] = symbol;
      undo.Push(position);

      if(CheckStrick(position,symbol))
      {
        Display();
        Console.WriteLine("{0}'s win the Match!\n",symbol);
        break;
      }

      if(i==8)
      {
        Display();
        Console.WriteLine("Match Draw!\n");
        break;
      }

//auto detection logic STARTS
      // if(i==7)
      // {
      //   Display();
      //   int lastPosition=0;
      //   for(int x=0;x<3;x++)
      //     for(int y=0;y<3;y++)
      //       if(_Board[x,y]==' ')
      //         lastPosition = x*3+y+1;
      //   if(CheckStrick(lastPosition,(symbol=='X')?'Y':'X'))
      //     Console.WriteLine("{0}'s win the Match!\n",(symbol=='X')?'Y':'X');
      //   else
      //     Console.WriteLine("Match Draw!\n");
      //   break;
      // }
//auto detection END

    }
  }

}


public class Program
{
    public static void Main(string[] args)
    {
      new XO_Game().Play();
    }
}
