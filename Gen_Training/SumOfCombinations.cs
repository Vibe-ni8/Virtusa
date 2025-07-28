
namespace Problems.SumOfCombi;
sealed class SumOfCombinations
{
    //Print Array
    internal void PrintArray<T>(T[] array)
    {
        Console.Write("[");
        foreach(T element in array)
            Console.Write(element+", ");
        Console.Write("\b\b]");
    }

    internal int CombinationsCount = 0;
    internal void PrintCombinations(int[] numbers, int target, int[]? curCombiArr = null, int indexToStart = 0)
    {
        if(curCombiArr == null)
        {
            curCombiArr = new int[]{};
            CombinationsCount = 0;
        }
        int sumOfCombi = 0;
        if(curCombiArr.Length != 0)
            foreach(int element in curCombiArr)
                sumOfCombi += element;

        if(sumOfCombi == target)
        {
            PrintArray(curCombiArr);
            Console.Write(" ");
            CombinationsCount++;
        }
        else if(sumOfCombi < target)
        {
            int len = curCombiArr.Length, i = 0;
            int[] nextCombiArr = new int[len+1];
            foreach(int element in curCombiArr)
                nextCombiArr[i++] = element;

            while(indexToStart<numbers.Length)
            {
                nextCombiArr[len] = numbers[indexToStart];
                PrintCombinations(numbers, target, nextCombiArr, indexToStart++);
            }
        }
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
        Console.Write("Enter the sum number: ");
        int sum = int.Parse(Console.ReadLine());
        SumOfCombinations obj = new SumOfCombinations();
        obj.PrintCombinations( arr, sum );
        Console.WriteLine("\nTotal no of Combinations: "+obj.CombinationsCount);
    }
}
