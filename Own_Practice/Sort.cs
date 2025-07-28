
namespace Sorting;

sealed class Sort
{

    internal delegate object? MyConverter(object? element);



    //method used to compare two string lexicologically
    private int CompareLexico(string str1, string str2)
    {
        for(int i=0; i<str2.Length; i++)
        {
            if(i==str1.Length)
                return 1;
            if(str1[i]<str2[i])
                return 1;
            if(str1[i]>str2[i])
                return -1;
        }
        if(str1.Length == str2.Length)
            return 0;
        return -1;
    }



    //Selection Sorting
    internal void SelectionSort<T>(T[] array, MyConverter? elementConverter = null)
    {
        if(elementConverter == null)
            elementConverter = (i) => i;

        if( elementConverter(array[0]) is string || elementConverter(array[0]) is char )
            for(int i=0; i<array.Length-1; i++)
                for(int j=i+1; j<array.Length; j++)
                    if( CompareLexico(elementConverter(array[i])+"" , elementConverter(array[j])+"") == -1 )
                    {
                        T temp;
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        //( array[i] , array[j] ) = ( array[j] , array[i] );
                    }

        if( elementConverter(array[0]) is int || elementConverter(array[0]) is long || elementConverter(array[0]) is float || elementConverter(array[0]) is double )
            for(int i=0; i<array.Length-1; i++)
                for(int j=i+1; j<array.Length; j++)
                    if( double.Parse(elementConverter(array[i])+"") > double.Parse(elementConverter(array[j])+"") )
                    {
                        T temp;
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        //( array[i] , array[j] ) = ( array[j] , array[i] );
                    }
    } 



    //Bubble Sorting
    internal void BubbleSort<T>(T[] array, MyConverter? elementConverter = null)
    {
        if(elementConverter == null)
            elementConverter = (i) => i;

        if( elementConverter(array[0]) is string || elementConverter(array[0]) is char )
            for(int i=0; i<array.Length-1; i++)
                for(int j=0; j<array.Length-i-1; j++)
                    if( CompareLexico(elementConverter(array[j])+"" , elementConverter(array[j+1])+"") == -1 )
                    {
                        T temp;
                        temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                        //( array[j] , array[j+1] ) = ( array[j+1] , array[j] );
                    }

        if( elementConverter(array[0]) is int || elementConverter(array[0]) is long || elementConverter(array[0]) is float || elementConverter(array[0]) is double )
            for(int i=0; i<array.Length-1; i++)
                for(int j=0; j<array.Length-i-1; j++)
                    if( double.Parse(elementConverter(array[j])+"") > double.Parse(elementConverter(array[j+1])+"") )
                    {
                        T temp;
                        temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                        //( array[j] , array[j+1] ) = ( array[j+1] , array[j] );
                    }
    } 



    //Method used to reverse the array
    internal void Reverse<T>(T[] array)
    {
        for(int i=0,j=array.Length-1; i<j; i++,j--)
        {
            ( array[i] , array[j] ) = ( array[j] , array[i] );
        }
    }

}


public class Program
{
    public static void Main(string[] args)
    {
        Sort obj = new Sort();
        int[] arrI = {1,3,5,7,9,8,2,4,6};
        float[] arrF = {5.0f,4.0f,6.0f,3.0f,7.0f,2.9f,8.7f,1.5f,9.3f};
        char[] arrC = {'E','D','F','C','G','B','H','A','I'};
        string[] arrS = {"E","ED","F","C","G","B","H","A","I"};
        obj.SelectionSort(arrI,(i)=>{return (((int)i)%2==0)?(int)i+100:i;});
        foreach(int e in arrI )
            Console.Write(e+" ");
        Console.WriteLine();
        obj.SelectionSort(arrF);
        foreach(float e in arrF )
           Console.Write(e+" ");
        Console.WriteLine();
        obj.SelectionSort(arrC);
        foreach(char e in arrC )
            Console.Write(e+" ");
        Console.WriteLine();
        obj.BubbleSort(arrS);
        foreach(string e in arrS)
            Console.Write(e+" ");
        Console.WriteLine();
    }
}
