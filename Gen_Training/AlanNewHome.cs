
namespace Problems.NewHome;

class AlanNewHome
{
    internal int FindBestHome(int[] gasLeft, int[] gasCost)
    {
        int AlanHomeIn = 0, gasCount = 0, shortage = 0;
        for(int i=0; i<gasLeft.Length; i++)
        {
            gasCount += gasLeft[i]-gasCost[i];
            if(gasCount<0)
            {
                shortage += gasCount;
                gasCount = 0;
                AlanHomeIn = i+1;
            }
        }
        if(gasCount+shortage>=0)
            return AlanHomeIn;
        return -1;
    }      
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the array length:");
        int l = int.Parse(Console.ReadLine());
        int[] gasleft = new int[l];
        int[] gascost = new int[l];
        Console.WriteLine("Enter the gasleft details.");
        for(int i=0;i<l;i++)
        {
            gasleft[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter the gascost details.");
        for(int i=0;i<l;i++)
        {
            gascost[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Alan New Home is in the position:");
        Console.WriteLine(new AlanNewHome().FindBestHome(gasleft, gascost));
    }
}
