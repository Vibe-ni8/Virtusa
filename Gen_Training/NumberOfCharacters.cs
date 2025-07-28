using System;

namespace Exercise.NumberOfCharacters;

public class Program
{
  public static int NumberOfCharacters(string str)
  {
    int count = 0, finalCount = 0;
    char letter = str[0];
    foreach(char e in str.ToLower())
    {
      if(letter != e)
      {
        letter = e;
        count = 1;
      }
      else
        count++;
      if(count == 3)
        finalCount++;
    }
    return finalCount;
  }
  
	public static void Main(string[] args)
	{
		Console.WriteLine(NumberOfCharacters(Console.ReadLine()));
	}
}
