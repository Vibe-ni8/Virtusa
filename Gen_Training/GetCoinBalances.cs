using System;

namespace Exercise.GetCoinBalances;

public class Program
{
  public static int[] getCoinBalances(string[] person1, string[] person2)
  {
    int person1Bal = 3, person2Bal = 3;//Initially set both persons balance as 3 coins
    for(int i =0; i<person1.Length; i++)//Loop runs for every turns that they play
    {
      if(person1[i]=="share")
      {
        person1Bal -= 1;//person1 share 3 coin and get 2 coin as net earn, so -3+2=-1
        person2Bal += 3;//person1 shared 3 coin will go to person2
      }
      if(person2[i]=="share")
      {
        person2Bal -= 1;//person2 share 3 coin and get 2 coin as net earn, so -3+2=-1
        person1Bal += 3;//person2 shared 3 coin will go to person1
      }
    }
    return ( new int[]{person1Bal,person2Bal} );
  }
	public static void Main(string[] args)
	{
		foreach(int e in getCoinBalances(Console.ReadLine().Split(' '), Console.ReadLine().Split(' ')))
		  Console.WriteLine(e);
	}
}
