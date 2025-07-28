
namespace Problems.QSort;

class QuickSort
{
    internal void Sort(int[] array, int low = 0, int? high = null)
    {
        if(high == null)
            high = array.Length-1;
        int i=low, j=(int)high, pivot=array[(i+j)/2];
        while(i<=j)
        {
            while(array[i]<pivot)
                i++;

            while(array[j]>pivot)
                j--;

            if(i<=j)
                ( array[i] , array[j] ) = ( array[j--] , array[i++] );
        }

        if(low<j)
            Sort(array, low, j);

        if(i<high)
            Sort(array, i, high);
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
        Console.Write("Where to begin sorting? : ");
        int w = int.Parse(Console.ReadLine());
        new QuickSort().Sort(arr,w-1);
        foreach(int e in arr)
            Console.Write(e+" ");
    }
}
