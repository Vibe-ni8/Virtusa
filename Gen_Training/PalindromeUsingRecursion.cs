
using System;

namespace Exercise.PalindromeUsingRecursion;

class Program
{
  static string removeOtherChars(string input)
  {
    string result = "";
    foreach(char e in input)
      if((e>='a'&&e<='z')||(e>='A'&&e<='Z')||(e>='0'&&e<='9'))
        result += e;
   return result.ToLower();
  }
  
  static bool isPalindrome(string input)
  {
    if((input.Length==0) || (input.Length==1) || (input[0]==input[input.Length-1] && isPalindrome(input.Substring(1,input.Length-2)) ))
      return true;
    return false;
  }
  
  public static void Main()
  {
    Console.WriteLine(isPalindrome( removeOtherChars(Console.ReadLine()) ));
  }
}
