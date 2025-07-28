
namespace Problems.Toy;
public class Toys
{
    public static int FindMinimunToys(int[] RackOfToys,int hours)
    {
        if(RackOfToys.Length>hours)
            return -1;
        int MinToy=1, MaxToy = RackOfToys.Max();
        while(MinToy<MaxToy)
        {
            int curToy = (MinToy+MaxToy)/2;
            int time = 0;
            foreach(int curRack in RackOfToys)
            {
                if( curRack%curToy==0 )
                    time+=curRack/curToy;
                else
                    time+=curRack/curToy+1;
                if(time>hours)
                    break;
            }
            if(time<=hours)
                MaxToy = curToy;
            else
                MinToy = curToy+1;
        }
        return (MinToy+MaxToy)/2;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the rack count: ");
        int l = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the integer values that represents no of toys in a rack one by one");
        int[] arr = new int[l];
        for(int i=0;i<l;i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the hour : ");
        int hour = int.Parse(Console.ReadLine());
        Console.WriteLine("Minimum toys that she can play to cover all toys within that hour: "+Toys.FindMinimunToys(arr,hour));
    }
}
