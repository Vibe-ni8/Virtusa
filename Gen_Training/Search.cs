
namespace Problems.Search;

sealed class Search
{
    internal int BinarySearch(int[] array, int key)
    {
        int low=0, high=array.Length-1;
        while( low <= high )
        {
            int mid = (low+high)/2;
            if(key == array[mid])
                return mid+1;
            else if(key < array[mid])
                high = mid-1;
            else
                low = mid+1;
        }
        return -1;
    }


    internal int LinearSearch(int[] array, int key)
    {
        int cur=0;
        while(cur<array.Length)
            if(key == array[cur++])
                return cur;
        return -1;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the array size: ");
        int l = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the integer values one by one");
        int[] arr = new int[l];
        for(int i=0;i<l;i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the search element : ");
        int searchElement = int.Parse(Console.ReadLine());
        Console.WriteLine(new Search().LinearSearch(arr,searchElement));
    }
}
