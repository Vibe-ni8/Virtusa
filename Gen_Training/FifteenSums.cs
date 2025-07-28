using System;
using System.Text.RegularExpressions;

namespace Exercise.Fifteen;

public class Program
{
	public static void Main(string[] args)
	{
        Console.WriteLine("\nFollowing are the programs available:");
        Console.WriteLine("\t1.CheckSum of Odd Digits");
        Console.WriteLine("\t2.Number validation");
        Console.WriteLine("\t3.Sum of Squares of even digits");
        Console.WriteLine("\t4.Fetching Middle Characters from String");
        Console.WriteLine("\t5.check Characters in a String");
        Console.WriteLine("\t6.Forming New Word from a String");
        Console.WriteLine("\t7.Reversing a Number");
        Console.WriteLine("\t8.Validating Date Format");
        Console.WriteLine("\t9.Validate Time");
        Console.WriteLine("\t10.String Encryption");
        Console.WriteLine("\t11.Password Validation");
        Console.WriteLine("\t12.Calculate Electricity Bill");
        Console.WriteLine("\t13.Sum of Digits in a String");
        Console.WriteLine("\t14.validate Color Code");

        Console.Write("\nEnter your choice: ");

        switch(int.Parse(Console.ReadLine()))
        {
            case 1:

	            //CheckSum of Odd digits
	            Console.Write("CheckSum of Odd Digits:");
		        Console.WriteLine("Output:" + ( (UserMainCode.checkSum( int.Parse(Console.ReadLine()) ) == 1 )? "Odd" : "Even" ) );
            break;


            case 2:
		
		        //Number validation
		        Console.Write("\nNumber validation:");
		        Console.WriteLine("Output:" + ( (UserMainCode.validateNumber(Console.ReadLine()) == 1 )? "Valid" : "Invalid" ) );
            break;


            case 3:
		
		        //Sum of Squares of even digits
		        Console.Write("\nSum of Squares of even digits:");
		        Console.WriteLine("Output:"+UserMainCode.sumOfSquaresOfEven( int.Parse(Console.ReadLine()) ));
            break;


            case 4:
		
		        // Fetching Middle Characters from String
		        Console.Write("\nFetching Middle Characters from String:");
	            Console.WriteLine("Output:"+UserMainCode.getMiddleChars(Console.ReadLine()));
            break;


            case 5:
	  
	            //check Characters in a String
	            Console.Write("\ncheck Characters in a String:");
	            Console.WriteLine("Output:"+ ( (UserMainCode.checkCharacters(Console.ReadLine()) == 1 )? "Valid" : "Invalid" ) );
            break;


            case 6:
	  
	            //Forming New Word from a String
	            Console.Write("\nForming New Word from a String:\n");
	            Console.WriteLine("Output:"+UserMainCode.formNewWord(Console.ReadLine(),int.Parse(Console.ReadLine())));
            break;


            case 7:
	  
	            //Reversing a Number
	            Console.Write("\nReversing a Number:");
	            Console.WriteLine("Output:"+UserMainCode.reverseNumber(int.Parse(Console.ReadLine())));
            break;


            case 8:
	  
	            //Validating Date Format
	            Console.Write("\nValidating Date Format:");
		        Console.WriteLine("Output:" + ( (UserMainCode.validateDate(Console.ReadLine()) == 1 )? "Valid dateformat":"Invalid dateformat" ) ); 
            break;


            case 9:
		
		        //Validate Time
		        Console.Write("\nValidate Time:");
		        Console.WriteLine("Output:" + ( (UserMainCode.validateTime(Console.ReadLine()) == 1 )? "Valid time":"Invalid time" ) );
            break;


            case 10:
		
		        //String Encryption
		        Console.Write("\nString Encryption:");
	            Console.WriteLine("Output:"+UserMainCode.encrypt(Console.ReadLine()));
            break;


            case 11:
	  
	            //Password Validation
	            Console.Write("\nPassword Validation:");
		        Console.WriteLine("Output:" + ( (UserMainCode.validatePassword(Console.ReadLine()) == 1 )? "Valid password":"Invalid password" ) );
            break;


            case 12:
		
		        //Calculate Electricity Bill
		        Console.Write("\nCalculate Electricity Bill:\n");
	            Console.WriteLine("Output:"+
	                UserMainCode.calculateElectricityBill(
	                    int.Parse(Console.ReadLine().Substring(5,5)),
	                    int.Parse(Console.ReadLine().Substring(5,5)),
	                    int.Parse(Console.ReadLine()) 
                    ) );
            break;


            case 13:
	  
	            //Sum of Digits in a String
	            Console.Write("\nSum of Digits in a String:");
	            Console.WriteLine("Output:"+UserMainCode.sumOfDigits(Console.ReadLine()));
            break;


            case 14:
	  
	            //validate Color Code
	            Console.Write("\nvalidate Color Code:");
	            Console.WriteLine("Output:" + ( (UserMainCode.validateColorCode(Console.ReadLine()) == 1 )? "Valid":"Invalid" ) ); 
            break;


            default:
                Console.WriteLine("Invalid input");
            break;
        }
        Console.Write("\nDo you want to continue? yes /no: ");
		if(Console.ReadLine() == "yes")
        {
            Main(args);
        }
	}
}

sealed class UserMainCode
{
  //Concat String
  public static string concatString(string word1, string word2)
  {
    return (word1.Length == word2.Length)?
      (word1+word2)
      :
      (word1.Length>word2.Length)?
        word1.Substring(word1.Length-word2.Length,word2.Length)+word2
        :
        word1+word2.Substring(word2.Length-word1.Length,word1.Length)
      ;
  }
  
  //CheckSum of Odd Digits
  public static int checkSum(int number)
  {
    int result = 0;
    while(number>0)
    {
      result += ((number%10)%2 != 0)?(number%10):(0);
      number /= 10;
    }
    
    if(result%2 != 0)
      return 1;
    return -1;
  }
  
  
  //Number validation
  public static int validateNumber(string pin)
  {
    Regex rg = new Regex("^([0-9]{3})-([0-9]{3})-([0-9]{4})$");
    if(rg.IsMatch(pin))
      return 1;
    return -1;
  }
  
  
  //Sum of squares of even digits
  public static int sumOfSquaresOfEven(int number)
  {
    int result = 0;
    while(number>0)
    {
      result += ((number%10)%2 == 0)? ((number%10)*(number%10)) : (0);
      number /= 10;
    }
    return result;
  }
  
  
  //Fetching Middle Characters from String
  public static string getMiddleChars(string input)
  {
    if(input.Length%2 == 0)
      return input.Substring(input.Length/2-1,2);
    return input.Substring(input.Length/2,1);
  }
  
  
  //check Characters in a String
  public static int checkCharacters(string input)
  {
    return (input[0] == input[input.Length-1])?1:0;
  }
  
  
  //Forming New Word from a String
  public static string formNewWord(string word, int len)
  {
    return (word.Substring(0,len)+word.Substring(word.Length-len,len));
  }
  
  
  //Reversing a Number
  public static int reverseNumber(int number)
  {
    int result = 0;
    while(number>0)
    {
      result = (result+(number%10))*10;
      number /= 10;
    }
    return result/10;
  }
  
  
  //Validating Date Format
  public static int validateDate(string date)
  {
    Regex rg = new Regex("^([0-9]{2})/([0-9]{2})/([0-9]{4})$");
    if(rg.IsMatch(date))
      return 1;
    return -1;
  }
  
  
  //Validate Time
  public static int validateTime(string time)
  {
    Regex rg = new Regex("^([0-9]{2}):([0-9]{2})\\s([pPaA]{1})([mM]{1})$");
    if(rg.IsMatch(time))
      return 1;
    return -1;
  }
  
  
  //String Encryption
  public static string encrypt(string input)
  {
    string encryptString="";
    for(int i=0;i<input.Length;i++)
      encryptString += (i%2 == 0)?((input[i] != 'z')?(char)(input[i]+1):'a'):input[i];
    return encryptString;
  }
  
  
  //Password Validation
  public static int validatePassword(string Password)
  {
    bool number=false, symbol=false;
    string num = "1234567890", sym = "@#$";
    if(Password.Length >5 && Password.Length<21)
      foreach(char e in Password)
      {
        if(num.Contains(e+""))
          number = true;
        if(sym.Contains(e+""))
          symbol = true;
      }
    if(number && symbol)
      return 1;
    return -1;
  }
  
  
  //Calculate Electricity Bill
  public static int calculateElectricityBill(int previousMeter, int currentMeter, int unitCharge)
  {
    return ((currentMeter - previousMeter)*unitCharge);
  }
  
  
  //Sum of Digits in a String
  public static int sumOfDigits(string input)
  {
    int sum = 0;
    foreach(char e in input)
      if(e>='0' && e<='9')
        sum += int.Parse(e+"");
    return ((sum==0)?-1:sum);
  }
  
  
  //validate Color Code
  public static int validateColorCode(string colorCode)
  {
    Regex rg = new Regex("^#[A-F0-9]{6}$");
    if(rg.IsMatch(colorCode))
      return 1;
    return -1;
  }
  
}
