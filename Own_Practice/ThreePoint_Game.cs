
namespace Gaming.TP;

sealed class ThreePoint_Game
{
    private char[,] _Board = new char[3,3]{{' ',' ',' '},{' ',' ',' '},{' ',' ',' '}};
    private ValueTuple<int,int>[]  _Index = new ValueTuple<int,int>[9]{(0,0),(0,1),(0,2),(1,0),(1,1),(1,2),(2,0),(2,1),(2,2)};


    private void Display()
    {
        Console.WriteLine();
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
                Console.Write(_Board[i,j]+((j!=2)?"--":""));
            Console.WriteLine((i!=2)?"\n|  |  |":"\n");
        }
    }


    private bool CheckStrick(int position, char symbol)
    {
        int i=_Index[position-1].Item1, j=_Index[position-1].Item2;
        switch(position)
        {
            case 1:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) )?true:false;
            case 2:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) )?true:false;
            case 3:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i+1,j]==symbol && _Board[i+2,j]==symbol) )?true:false;
            case 4:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) )?true:false;
            case 5:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) )?true:false;
            case 6:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i+1,j]==symbol && _Board[i-1,j]==symbol) )?true:false;
            case 7:return ( (_Board[i,j+1]==symbol && _Board[i,j+2]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) )?true:false;
            case 8:return ( (_Board[i,j+1]==symbol && _Board[i,j-1]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) )?true:false;
            case 9:return ( (_Board[i,j-1]==symbol && _Board[i,j-2]==symbol) || (_Board[i-1,j]==symbol && _Board[i-2,j]==symbol) )?true:false;
        }
        return false;
    }



    internal void Play()
    {
        char symbol='X';

        for(int i=0; i<6; i++)
        {
            Display();
            symbol = (i%2==0)?'X':'O';
            int position=0;
            bool again;

            do{
                again = false;
                Console.Write("{0}'s turn (enter any number 1 to 9 to place coin): ",symbol);
                try{position = int.Parse(""+Console.ReadLine());}
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input Format");
                    again=true;
                    continue;
                }

                if(position<1 || position>9)
                {
                    Console.WriteLine("Invalid Position");
                    again = true;
                    continue;
                }

                if("XO".Contains( _Board[ _Index[position-1].Item1 , _Index[position-1].Item2 ] ))
                {
                    Console.WriteLine("A Coin is there, try another place.");
                    again = true;
                    continue;
                }

                if(CheckStrick(position,symbol))
                {
                    Console.WriteLine("You are not allowed to place the coin here, try another place.");
                    again = true;
                    continue;
                }

            }while( again );

            _Board[_Index[position-1].Item1,_Index[position-1].Item2] = symbol;
        }

        while(true)
        {
            Display();
            symbol = (symbol=='X')?'O':'X';
            int position=0, newPosition=0;
            char move;
            bool again;

            do{
                again = false;
                Console.Write("{0}'s turn (<Coin position><which direction to move?>): ",symbol);
                try{position = int.Parse(((char)Console.Read())+"");}
                catch(FormatException)
                {
                    Console.ReadLine();
                    Console.WriteLine("Invalid Input Format");
                    again=true;
                    continue;
                }
                move = (char)Console.Read();
                Console.ReadLine();

                if(position<1 || position>9)
                {
                    Console.WriteLine("Invalid Coin Position");
                    again = true;
                    continue;
                }

                if(_Board[_Index[position-1].Item1,_Index[position-1].Item2]!=symbol)
                {
                    Console.WriteLine("Coin is not present here or it\'s not your coin to move");
                    again = true;
                    continue;
                }

                switch(move+"".ToLower())
                {
                    case "d":newPosition=position+3;break;
                    case "r":newPosition=(position==3||position==6)?0:position+1;break;
                    case "u":newPosition=position-3;break;
                    case "l":newPosition=(position==4||position==7)?0:position-1;break;
                    default:newPosition=0;break;
                }

                if(newPosition<1 || newPosition>9)
                {
                    Console.WriteLine("Invalid direction or noway to move");
                    again = true;
                    continue;
                }

                if(_Board[_Index[newPosition-1].Item1,_Index[newPosition-1].Item2]!=' ')
                {
                    Console.WriteLine("The place is already occupied by another coin!");
                    again = true;
                    continue;
                }

            }while(again);

            _Board[_Index[position-1].Item1,_Index[position-1].Item2]=' ';
            _Board[_Index[newPosition-1].Item1,_Index[newPosition-1].Item2]=symbol;

            if(CheckStrick(newPosition,symbol))
            {
                Display();
                Console.WriteLine("{0}'s win the Match!\n",symbol);
                break;
            }
        }
    }

}


public class Program
{
    public static void Main(string[] args)
    {
        new ThreePoint_Game().Play();
    }
}
