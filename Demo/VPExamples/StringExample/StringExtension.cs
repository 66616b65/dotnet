using System;

namespace StringExample
{
    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static StringInfo Info(this string str)
        {
            return new StringInfo() { length = str.Length, digits = 10, other = 20 };
        }
    }

    public class C
    {
        void M()
        {
            string testString = "abcdef";
            testString.Info();
        }
    }

    public struct StringInfo
    {
        public int length;
        public int digits;
        public int other;
    }
}
