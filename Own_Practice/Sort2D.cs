
namespace Sorting2D;
sealed class Sort2D
{
	internal void GravitySort(char[,] array2D, string type)
	{
        int row = array2D.GetLength(0);
        int col = array2D.GetLength(1);
        for(int i=0; i<col; i++)
        {
            for(int j=0; j<row-1; j++)
                for(int k=j+1; k<row; k++)
                    if(type.Equals("des")?array2D[j,i]>array2D[k,i]:array2D[j,i]<array2D[k,i])
                    {
                        char temp;
                        temp = array2D[j,i];
                        array2D[j,i] = array2D[k,i];
                        array2D[k,i] = temp;
                        //(array2D[j,i] , array2D[k,i]) = (array2D[k,i] , array2D[j,i]);
                    }
        }
	}
}


public class Program
{
    public static void Main(string[] args)
    {
        Sort2D ob = new Sort2D();
        char[,] arr = 
        {
            {'#','-'},
            {'-','#'},
            {'#','-'}
        };
        
        Console.WriteLine("gravity on");
        ob.GravitySort(arr,"asc");
        int i=0;
        foreach(char e in arr)
        {
            Console.Write(e);
            i++;
            if(i%2==0)
            Console.WriteLine();
        }

        Console.WriteLine("gravity off");
        ob.GravitySort(arr,"des");
        i=0;
        foreach(char e in arr)
        {
            Console.Write(e);
            i++;
            if(i%2==0)
            Console.WriteLine();
        }
    }
}
