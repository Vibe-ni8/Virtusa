using System;

namespace Exercise.CommonAndUnique;

public class Program
{
  public static int CountLetter(string str, char check)
  {
    int count = 0;
    foreach(char e in str)
      if(e == check)
        count++;
    return count;
  }
  
  public static int CommonAndUnique(string str1, string str2)
  {
    string str = (str1.Length < str2.Length)?str1:str2;
    int count = 0;
    foreach(char e in str)
    {
      if(e != ' ')
        if(CountLetter(str1,e)==1 && CountLetter(str2,e)==1)
          count++;
    }
    return count;
  }
  
	public static void Main(string[] args)
	{
		Console.WriteLine(CommonAndUnique(Console.ReadLine(), Console.ReadLine()));
	}
}
