using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<string> instuction = Console.ReadLine().Split(":|:").ToList();
            while (instuction[0] != "Reveal")
            {
                string comand = instuction[0];
                switch (comand)
                {

                    case "InsertSpace":
                        int index = int.Parse(instuction[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substring = instuction[1];
                        if (message.Contains(substring))
                        {
                            string newString = "";
                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                newString += substring[i];
                            }
                            int startIndex = message.IndexOf(substring);
                            message = message.Remove(startIndex, substring.Length);
                            message += newString;
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string subs = instuction[1];
                        string newSubs = instuction[2];
                        if (message.Contains(subs))
                        {
                            while (message.Contains(subs))
                            {
                                message = message.Replace(subs, newSubs);
                            }
                            Console.WriteLine(message);
                        }
                        break;
                    default:
                        break;
                }



                instuction = Console.ReadLine().Split(":|:").ToList();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}

//•	Reverse:|:{ substring}
//o If the message contains the given substring, cut it out, reverse it and add it at the end of the message.
//o If not, print "error". 
//o This operation should replace only the first occurrence of the given substring if there are more than one such occurrences.
//•	ChangeAll:|:{substring}:|:{replacement} o	Changes all occurrences of the given substring with the replacement text.
