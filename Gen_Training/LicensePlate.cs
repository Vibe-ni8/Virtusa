using System;

namespace Exercise.LicensePlate;

public class Program
{
  public static string getLicensePlate(string dmy, int groupLen)
  {
    string licensePlate = "";
    for(int i=dmy.Length-1,curGroupLen=0; i>=0; i--)
    {
      if(curGroupLen==groupLen)
      {
        licensePlate = "-"+licensePlate;
        curGroupLen=0;
      }
      if(dmy[i] != '-')
      {
        licensePlate = dmy[i]+licensePlate;
        curGroupLen++;
      }
    }
    return licensePlate.ToUpper();
  }
  
	public static void Main(string[] args)
	{
		Console.WriteLine( getLicensePlate( Console.ReadLine(), int.Parse(Console.ReadLine()) ) );
	}
}
