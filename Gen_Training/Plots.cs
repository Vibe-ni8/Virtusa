
namespace Problems.Plot;
 
public class Plot{
    private void MarkPlotsAsVisited(int i, int j, Char[,] Plots)
    {
        if(i<0||j<0||i>=Plots.GetLength(0)||j>=Plots.GetLength(1)||Plots[i,j]!='1')
       {
            return;
       }
        Plots[i,j] = '.';  //Make as visited land
        MarkPlotsAsVisited(i+1 , j , Plots); //downward
        MarkPlotsAsVisited(i , j +1, Plots); //right
        MarkPlotsAsVisited(i -1 , j , Plots); //upward
        MarkPlotsAsVisited(i , j-1 , Plots); //left
 
    }
    public int AvailablePlots(char[,] Plots)
    {
        int counterForLand=0;
        for(int i=0;i<Plots.GetLength(0);i++)
        {
            for(int j=0;j<Plots.GetLength(1);j++)
            {
                if(Plots[i,j] == '1')
                {
                    MarkPlotsAsVisited(i , j , Plots);
                    counterForLand++;
                }
            }
        }
        return counterForLand;
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
        Console.WriteLine("Enter the Matrix of "+r+" x "+c+" of 1`s and 0`s");
        for(int i=0;i<r;i++)
        {
            for(int j=0;j<c;j++)
            {
                array[i,j] = (char)Console.Read();
            }
                Console.ReadLine();
            }
            Plot obj =new Plot();
            int res=obj.AvailablePlots(array);
            Console.WriteLine("Available Plots : "+res);
    }
}
