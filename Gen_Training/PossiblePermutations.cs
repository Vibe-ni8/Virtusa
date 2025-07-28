
namespace Problems.PosPermu;

sealed class PossiblePermutations
{
    //Print Array
    internal void PrintArray<T>(T[] array)
    {
        Console.Write("[");
        foreach(T element in array)
            Console.Write(element+", ");
        Console.Write("\b\b]");
    }


    //Possible permutations for a array input and array based output
    internal void Execute(string[] arr, int low=0)
    {
        if(low == arr.Length)
        {
            PrintArray(arr);
            Console.Write(" ");
        }
        for(int i=low; i<arr.Length; i++)
        {
            string temp = "";
            temp = arr[low];
            arr[low] = arr[i];
            arr[i] = temp;

            Execute(arr,low+1);
            
            temp = arr[low];
            arr[low] = arr[i];
            arr[i] = temp;
        }
    }


    //Possible permutations for a string input and string based output
    internal void Execute(string word, int low=0)
    {
        char[] arr = word.ToCharArray();
        if(low == arr.Length)
            Console.Write(String.Join("",arr)+" ");
        for(int i=low; i<arr.Length; i++)
        {
            char temp = '0';
            
            temp = arr[low];
            arr[low] = arr[i];
            arr[i] = temp;
            
            Execute(String.Join("",arr),low+1);

            temp = arr[low];
            arr[low] = arr[i];
            arr[i] = temp;
        }
    }

}


public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Which type of input you want? string/array : ");
        switch(Console.ReadLine())
        {
            case "array":
                Console.Write("Enter array length : ");
                int l = int.Parse(Console.ReadLine());
                string[] arr = new string[l];
                Console.WriteLine("Enter the values one by one");
                for(int i=0;i<l;i++)
                {
                    arr[i] = Console.ReadLine();
                }
                Console.WriteLine("Possible permutation are:");
                new PossiblePermutations().Execute(arr);
                break;
            case "string":
                Console.Write("Enter value : ");
                string val = Console.ReadLine();
                Console.WriteLine("Possible permutation are:");
                new PossiblePermutations().Execute(val);
                break;
            default:
                Console.WriteLine("Invalid choice");break;

        }
    }
}
