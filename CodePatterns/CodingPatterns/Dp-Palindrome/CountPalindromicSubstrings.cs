using System;
namespace Dp_Palindrome
{
    public static  class CountPalindromicSubstrings
    {

        public static int Count(string s)
        {
            var dp = new bool[s.Length][];

            for(int i=0; i< s.Length; i++)
            {
                dp[i] = new bool[s.Length];
                dp[i][i] = true;
            }

            for(int i=0; i< s.Length; i++)
            {
                for(int j=0; j< s.Length; j++)
                {

                    if(s[i] == s[j] && dp[i+1][j-1])
                    {
                        dp[i][j] = true;
                    }
                }
            }


            return s.Length;
        }


      

        public static void Run()
        {
            Console.WriteLine(Count("Test"));
        }
    }
}
