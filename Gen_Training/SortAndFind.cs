using System;

namespace Exercise.SortAndFind;

public class Program
{

  public static int CompareStrings(string str1, string str2)
  {
    for(int i=0; i<str2.Length; i++)
    {
      if(i == str1.Length)
        return 1;
      if(str1[i]<str2[i])
        return 1; 
      else if(str1[i]>str2[i])
        return -1;
    }
    return -1;
  }
  
  public static int SortAndFind(string[] arr, string str)
  {
    string temp = "";
    for(int i=0; i<arr.Length-1 ;i++)
    {
      for(int j=i+1; j<arr.Length; j++)
      {
        if(CompareStrings(arr[i],arr[j]) == 1)
        {
          temp = arr[i];
          arr[i] = arr[j];
          arr[j] = temp;
        }
      }
      if(arr[i] == str)
        return i+1;
    }
    if(arr[arr.Length-1] == str)
      return arr.Length;
    return 0;
  }
  
	public static void Main(string[] args)
	{
	  int size = int.Parse(Console.ReadLine());
	  string[] arr = new string[size];
	  for(int i=0; i<size; i++)
	  {
	    arr[i] = Console.ReadLine();
	  }
	  string str = Console.ReadLine();
		Console.WriteLine(SortAndFind(arr, str));
	}
}
