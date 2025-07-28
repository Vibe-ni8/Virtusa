
namespace Problems.LSWOD;

sealed class LongestSubstringWithoutDuplicate
{
    //Check Duplicate char present or not 
    internal bool IsContainDuplicateChar(string word)
    {
        foreach(char letter in word)
            if( word.Replace(letter+"","").Length+1 != word.Length )
                return true;
        return false;
    }

    internal bool IsNotContainDuplicateChar(string word)
    {
        return !IsContainDuplicateChar(word);
    }

    //using for loops
    internal string Execute(string word)
    {
        for(int i=word.Length; i>0; i--)
            for(int j=0; i+j<=word.Length; j++)
                if(IsNotContainDuplicateChar(word.Substring(j,i)))
                    return word.Substring(j,i);
        return "";
    }


    //using for and recursion
    internal string Execute(string word, int len)
    {
        if(len == 0 || word.Length == 0)
            return "";
        for(int low=0; low+len<=word.Length; low++)
            if(IsNotContainDuplicateChar(word.Substring(low,len)))
                return word.Substring(low,len);
        return Execute(word, len-1);
    }


    //using recursion
    internal string Execute(string word, int len, int low)
    {
        if(len == 0 || word.Length == 0)
            return "";
        if(IsNotContainDuplicateChar(word.Substring(low,len)))
                return word.Substring(low,len);
        else if(low+len<word.Length)
            return Execute(word, len, low+1);
        return Execute(word, len-1, 0);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the word: ");
        string? word = Console.ReadLine();
        if(word!=null)
        {
            LongestSubstringWithoutDuplicate obj = new LongestSubstringWithoutDuplicate();
            Console.WriteLine("Longest Substring Without Duplicate is : "+obj.Execute(word));
        }
    }
}
