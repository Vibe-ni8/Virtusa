namespace Problems.Dam;
 
class AlanDam
{
    private struct Points
    {
        public int X;
        public int Y;
    }
 
    private void FillWater(char[,] areaMap, Queue<Points> emptyDams)
    {
        int x, y;
        for(int i=1;i<=4;i++)
        {
            x=emptyDams.Peek().X;
            y=emptyDams.Peek().Y;
            switch(i)
            {
                case 1:x+=1;break;
                case 2:y+=1;break;
                case 3:x-=1;break;
                case 4:y-=1;break;
            }
       
            if( x<0 || x>=areaMap.GetLength(0) || y<0 || y>=areaMap.GetLength(1) || areaMap[x,y]!='1' )
                continue;
 
            areaMap[x,y]='2';
            emptyDams.Enqueue(new Points(){X=x,Y=y});
        }
    }
 
 
    public string CalculateTime(char[,] areaMap)
    {
        Queue<Points> emptyDams = new Queue<Points>();

        for(int i=0; i<areaMap.GetLength(0);i++)
            for(int j=0; j<areaMap.GetLength(1);j++)
                if(areaMap[i,j]=='2')
                    emptyDams.Enqueue(new Points(){X=i,Y=j});
        emptyDams.Enqueue(new Points(){X=-1,Y=-1});

        int time = 0;
        
        while(emptyDams.TryPeek(out Points curPoint))
        {
            if(curPoint.X==-1 && curPoint.Y==-1)
            {
                emptyDams.Dequeue();
                if(!emptyDams.TryPeek(out curPoint))
                    break;
                emptyDams.Enqueue(new Points(){X=-1,Y=-1});
                time++;
            }
            FillWater(areaMap,emptyDams);
            emptyDams.Dequeue();
        }

        for(int i=0;i<areaMap.GetLength(0);i++)
            for(int j=0;j<areaMap.GetLength(1);j++)
            {
                if(areaMap[i,j]=='1')
                    return "Some Dams are outoff water";
            }
        return "Times take to feed all Dams: "+time;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter no of rows:");
        int r = int.Parse(Console.ReadLine());
        Console.Write("Enter no of columns:");
        int c = int.Parse(Console.ReadLine());
        char[,] array = new char[r,c];
        Console.WriteLine("Enter the Matrix of "+r+" x "+c+" of 1`s and 0`s and dam as 2");
        for(int i=0;i<r;i++)
        {
            for(int j=0;j<c;j++)
            {
                array[i,j] = (char)Console.Read();
            }
            Console.ReadLine();
        }
        AlanDam obj =new AlanDam();
        string res=obj.CalculateTime(array);
        Console.WriteLine(res);
    }
}

