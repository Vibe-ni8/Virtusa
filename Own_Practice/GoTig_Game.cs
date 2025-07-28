
namespace Gaming.GoTig;


sealed class Coin
{
    internal char CoinType{get; set;}=' ';
    internal Coin? Up{get;set;}=null;
    internal Coin? Down{get;set;}=null;
    internal Coin? Left{get;set;}=null;
    internal Coin? Right{get;set;}=null;
 
    internal bool Move(char direction)
    {
        Coin? moveTo=null;
        switch(direction)
        {
            case 'd':moveTo=Down;break;
            case 'u':moveTo=Up;break;
            case 'r':moveTo=Right;break;
            case 'l':moveTo=Left;break;
        }
        if(moveTo  is null)
            return false;
        if(CoinType == ' ' || moveTo.CoinType != ' ')
            return false;
        else
            (CoinType, moveTo.CoinType)=(' ', CoinType);
        return true;
    }
 
    internal bool Jump(char direction1, char direction2)
    {
        Coin? moveTo1=null, moveTo2=null;
        switch(direction1)
        {
            case 'd':moveTo1=Down;break;
            case 'u':moveTo1=Up;break;
            case 'r':moveTo1=Right;break;
            case 'l':moveTo1=Left;break;
        }
        if(moveTo1  is null)
            return false;
        switch(direction2)
        {
            case 'd':moveTo2=moveTo1.Down;break;
            case 'u':moveTo2=moveTo1.Up;break;
            case 'r':moveTo2=moveTo1.Right;break;
            case 'l':moveTo2=moveTo1.Left;break;
        }
        if(moveTo2 is null)
            return false;
        if(CoinType != 'T' || moveTo1.CoinType != 'G' || moveTo2.CoinType != ' ')
            return false;
        else
            (CoinType, moveTo1.CoinType, moveTo2.CoinType)=(' ', ' ', 'T');
        return true;
    }
 
}



abstract class GoTig_Map
{
    internal Dictionary<int,Coin> CreateMap()
    {
        Dictionary<int, Coin> _Place = new Dictionary<int, Coin>();

        for(int i=1;i<6;i++)
            for(int j=1;j<7;j++)
            {
                if( (i==1&&j==2) || (i==5&&j==5) )
                    break;
                _Place.Add(i*10+j, new Coin());
            }
 
        for(int i=2;i<4;i++)
            for(int j=1;j<7;j++)
            {
                if(_Place.ContainsKey((i+1)*10+j))
                {
                    _Place[i*10+j].Down=_Place[(i+1)*10+j];     _Place[(i+1)*10+j].Up=_Place[i*10+j];
                }
                if(_Place.ContainsKey(i*10+j+1))
                {
                    _Place[i*10+j].Right=_Place[i*10+j+1];      _Place[i*10+j+1].Left=_Place[i*10+j];
                }
            }
       
        for(int i=4;i<6;i++)
            for(int j=1;j<6;j++)
            {
                if(i==5&&j==4) break;
                if(_Place.ContainsKey((i+1)*10+j-1))
                {
                    _Place[i*10+j].Down=_Place[(i+1)*10+j-1];     _Place[(i+1)*10+j-1].Up=_Place[i*10+j];
                }
                if(_Place.ContainsKey(i*10+j+1))
                {
                    _Place[i*10+j].Right=_Place[i*10+j+1];      _Place[i*10+j+1].Left=_Place[i*10+j];
                }
            }
       
        _Place[11].Up=_Place[22];     _Place[22].Up=_Place[11];
        _Place[11].Down=_Place[24];     _Place[23].Up=_Place[11];
        _Place[11].Left=_Place[23];     _Place[24].Up=_Place[11];
        _Place[11].Right=_Place[25];     _Place[25].Up=_Place[11];

        return _Place;
    }
}



sealed class GoTig_Game : GoTig_Map
{
    private Dictionary<int, Coin> _Place;

    private int _DeadGoatCount=0;
    private int[] _TigerLocation = new int[3];


    internal GoTig_Game()
    {
        _Place = CreateMap();
    }


    private bool _SuccessMove(int location, char direction, char dirChoice)
    {
        for(int i=0;i<_TigerLocation.Length;i++)
        {
            if(_TigerLocation[i]==location)
            {
                if(location==11)
                    _TigerLocation[i]=location+10+int.Parse(dirChoice+"");
                else if("22 23 24 25".Contains(location+"") && direction=='u')
                    _TigerLocation[i]=11;
                else
                {
                    switch(direction)
                    {
                        case 'u':_TigerLocation[i]=location-10;break;
                        case 'd':_TigerLocation[i]=location+10;break;
                        case 'l':_TigerLocation[i]=location-1;break;
                        case 'r':_TigerLocation[i]=location+1;break;
                    }
                }
            }
        }
        return false;
    }

    private bool _SuccessJump(int location, char direction, char dirChoice)
    {
        _DeadGoatCount++;

        for(int i=0;i<_TigerLocation.Length;i++)
        {
            if(_TigerLocation[i]==location)
            {
                if(location==11)
                    _TigerLocation[i]=location+20+int.Parse(dirChoice+"");
                else if("22 23 24 25".Contains(location+"") && direction=='u')
                    _TigerLocation[i]=21+int.Parse(dirChoice+"");
                else if("32 33 34 35".Contains(location+"") && direction=='u')
                    _TigerLocation[i]=11;
                else
                {
                    switch(direction)
                    {
                        case 'u':_TigerLocation[i]=location-20;break;
                        case 'd':_TigerLocation[i]=location+20;break;
                        case 'l':_TigerLocation[i]=location-2;break;
                        case 'r':_TigerLocation[i]=location+2;break;
                    }
                }
            }
        }
        return false;
    }


    private void Display()
    {
        int[] locations = new int[]{11,21,22,23,24,25,26,31,32,33,34,35,36,41,42,43,44,45,46,51,52,53,54};
        string[] display = new string[10]
                    {
                        "                    ^",
                        "1->              >  P  <",
                        "                /  / \\  \\",
                        "2->    P-------P--P---P--P-------P",
                        "       |      /   |   |   \\      |",
                        "3->    P-----P----P---P----P-----P",
                        "       |    /    /     \\    \\    |",
                        "4->    P---P----P-------P----P---P",
                        "          /     |       |     \\",
                        "5->      P------P-------P------P"
                    };
        for(int i=0,k=0;i<display.Length;i++)
        {
            for(int j=0;j<display[i].Length;j++)
            {
                if(display[i][j]=='P')
                {
                    Console.Write(_Place[locations[k]].CoinType);
                    k++;
                }
                else
                    Console.Write(display[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }


    private bool IsTigerLock()
    {
        bool IsLock = true;
        for(int i=0;i<3;i++)
        {
            int loc =  _TigerLocation[i];
            Coin Tiger = _Place[loc];

            if(Tiger.Up is not null && Tiger.Up.CoinType == ' ') { IsLock=false; break; }
            if(Tiger.Down is not null && Tiger.Down.CoinType == ' ') { IsLock=false; break; }
            if(Tiger.Left is not null && Tiger.Left.CoinType == ' ') { IsLock=false; break; }
            if(Tiger.Right is not null && Tiger.Right.CoinType == ' ') { IsLock=false; break; }

            if(loc==11)
            {
                if(_Place[32].CoinType == ' ') { IsLock=false; break; }
                if(_Place[33].CoinType == ' ') { IsLock=false; break; }
                if(_Place[34].CoinType == ' ') { IsLock=false; break; }
                if(_Place[35].CoinType == ' ') { IsLock=false; break; }
            }
            else if("22 23 24 25".Contains(loc+""))
            {
                if(loc!=22 && _Place[22].CoinType == ' ') { IsLock=false; break; }
                if(loc!=23 && _Place[23].CoinType == ' ') { IsLock=false; break; }
                if(loc!=24 && _Place[24].CoinType == ' ') { IsLock=false; break; }
                if(loc!=25 && _Place[25].CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Down is not null && Tiger.Down.Down is not null && Tiger.Down.Down.CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Left is not null && Tiger.Left.Left is not null && Tiger.Left.Left.CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Right is not null && Tiger.Right.Right is not null && Tiger.Right.Right.CoinType == ' ') { IsLock=false; break; }
            }
            else
            {
                if(Tiger.Up is not null && Tiger.Up.Up is not null && Tiger.Up.Up.CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Down is not null && Tiger.Down.Down is not null && Tiger.Down.Down.CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Left is not null && Tiger.Left.Left is not null && Tiger.Left.Left.CoinType == ' ') { IsLock=false; break; }
                if(Tiger.Right is not null && Tiger.Right.Right is not null && Tiger.Right.Right.CoinType == ' ') { IsLock=false; break; }
            }
        }
        return IsLock;
    }

 
    internal void Play()
    {
        int tigerCount = 3, goatCount = 15;
        _DeadGoatCount = 0;
        char coinType='T';
        while(true)
        {
            Display();
            coinType = (coinType=='T')?'G':'T';
            bool again;
            int location;
            char direction;
            char dirChoice;
            do{
                again = false;
 
                if(coinType=='T' && tigerCount>0)
                    Console.Write("Tiger's turn(where to place Coin?): ");
                else if(coinType=='G' && goatCount>0)
                    Console.Write("Goats's turn(where to place Coin?): ");
                else
                    Console.Write("{0}'s turn(where to move?): ",(coinType=='T')?"Tiger":"Goat");
 
                string input = Console.ReadLine()+"";
                try{ location = int.Parse(""+input[0]+input[1]); }
                catch(Exception){ Console.WriteLine("Invalid Input Format"); again=true; continue;}
                if(!_Place.ContainsKey(location))
                { Console.WriteLine("Invalid Location"); again=true; continue; }
               
 
                if( (coinType=='T' && tigerCount>0) || (coinType=='G' && goatCount>0) )
                {
                    if(_Place[location].CoinType!=' ')
                        { Console.WriteLine("Coin is there, try another place"); again=true; continue; }
                    _Place[location].CoinType = coinType;
                    if(coinType=='T') 
                    {
                        tigerCount--;
                        _TigerLocation[tigerCount]=location;
                    }
                    else goatCount--;
                }
                else
                {
                    if(_Place[location].CoinType!=coinType)
                        { Console.WriteLine("you can't move another players coin or there is no Coin to move"); again=true; continue; }
                    try{ direction = input[2]; }
                    catch(Exception){ Console.WriteLine("Invalid Input"); again=true; continue;}
 
                    if(location+""=="11")
                    {
                        if(direction!='d')
                        {
                            Console.WriteLine("Invalid direction"); again = true; continue;
                        }
                        try{ dirChoice = input[3]; }
                        catch(Exception){ Console.WriteLine("Invalid Input or confuse which path to take"); again=true; continue;}
                        if( dirChoice==' ' || !"1 2 3 4".Contains(dirChoice) )
                        {
                            Console.WriteLine("Invalid path"); again=true; continue;
                        }
                        switch(dirChoice)
                        {
                            case '1': again = _Place[location].Move('u')? _SuccessMove(location,direction,dirChoice) : _Place[location].Jump('u','d')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '2': again = _Place[location].Move('l')? _SuccessMove(location,direction,dirChoice) : _Place[location].Jump('l','d')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '3': again = _Place[location].Move('d')? _SuccessMove(location,direction,dirChoice) : _Place[location].Jump('d','d')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '4': again = _Place[location].Move('r')? _SuccessMove(location,direction,dirChoice) : _Place[location].Jump('r','d')? _SuccessJump(location,direction,dirChoice) : true; break;
                        }
                        if(again)
                        {
                            Console.WriteLine("Can't move{0}",(coinType=='T')?" or jump, try another path":", try another path");
                            continue;
                        }
                    }
                    else if("22 23 24 25".Contains(location+"") && coinType=='T' && direction=='u')
                    {
                        if(_Place[location].Move('u'))
                        {
                            again = _SuccessMove(location,direction,'0');
                            continue;
                        }
                        try{ dirChoice = input[3]; }
                        catch(Exception){ Console.WriteLine("Invalid Input or confuse which place to jump"); again=true; continue;}
                        if( dirChoice==' ' || !"1 2 3 4".Contains(dirChoice) )
                        {
                            Console.WriteLine("Invalid path"); again=true; continue;
                        }
                        if(dirChoice+""==location%10-1+"")
                        {
                            Console.WriteLine("You can't jump to the same location, try another path"); again=true; continue;
                        }
                        switch(dirChoice)
                        {
                            case '1': again = _Place[location].Jump('u','u')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '2': again = _Place[location].Jump('u','l')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '3': again = _Place[location].Jump('u','d')? _SuccessJump(location,direction,dirChoice) : true; break;
                            case '4': again = _Place[location].Jump('u','r')? _SuccessJump(location,direction,dirChoice) : true; break;
                        }
                        if(again)
                        {
                            Console.WriteLine("Can't move or jump, try another path");
                            continue;
                        }
                    }
                    else
                    {
                        if(_Place[location].Move(direction)) { again=_SuccessMove(location,direction,'0'); }
                        else if(_Place[location].Jump(direction,direction)) { again=_SuccessJump(location,direction,'0'); }
                        else
                        {
                            Console.WriteLine("Invalid direction or can't move{0}",(coinType=='T')?" or jump":"");
                            again = true;
                            continue;
                        }
                    }
                }
               
 
            }while(again);

            if(_DeadGoatCount==15)
            {
                Display();
                Console.WriteLine("Tiger wins the match!");
                break;
            }

            if(tigerCount==0 && IsTigerLock())
            {
                Display();
                Console.WriteLine("Goat wins the match!");
                break;
            }
        }
    }
 
}
 


public class Program
{
    public static void Main(string[] args)
    {
        new GoTig_Game().Play();
    }
}
