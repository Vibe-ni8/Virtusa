using System;

namespace Exercise.LetterCheck;

public class Program
{
  public static bool isContains(string str, char letter)
  {
    foreach(char e in str)
      if(e == letter)
        return true;
    return false;
  }
  
  public static bool letterCheck(string[] arr)
  {
    arr = Array.ConvertAll(arr,(i)=>i.ToLower());
    foreach(char e in arr[1])
    {
      if(!isContains(arr[0],e))
        return false;
    }
    return true;
  }
  
	public static void Main(string[] args)
	{
	  string[] arr = new string[2];
	  for(int i=0; i<2; i++)
	  {
	    arr[i] = Console.ReadLine();
	  }
		Console.WriteLine(letterCheck(arr));
	}
}
