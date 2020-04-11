using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(@|#){1}([a-zA-Z]{3,})(\1)(\1)([a-zA-Z]{3,})(\1)";
            Regex reg = new Regex(pattern);
            MatchCollection Match = reg.Matches(input);
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (Match item in Match)
            {
                string word1 = item.Groups[2].Value;
                string word2 = item.Groups[5].Value;
                string newWord2 = "";
                if (word1.Length == word2.Length)
                {
                    for (int i = word2.Length - 1; i >= 0; i--)
                    {
                        newWord2 += word2[i];
                    }
                    if (word1 == newWord2)
                    {
                        if (!(dict.ContainsKey(word1) || dict.ContainsKey(word2)))
                        {
                            dict.Add(word1, word2);
                        }
                    }
                }
            }
            if (Match.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");

            }
            else
            {
                List<string> list = new List<string>();
                Console.WriteLine($"{Match.Count} word pairs found!");
                if (dict.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");

                    foreach (var item in dict)
                    {
                        list.Add(item.Key + " <=> " + item.Value);

                    }
                    Console.WriteLine(string.Join(", ", list));
                }
            }
        }
    }
}

