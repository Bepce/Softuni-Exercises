using System;
using System.Collections.Generic;

namespace Exam23
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowelInput = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);
            char[] consonantsInput = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);

            Queue<char> vowel = new Queue<char>(vowelInput);
            Stack<char> consontants = new Stack<char>(consonantsInput);

            List<char> letters = new List<char>();
            List<string> wordsConstant = new List<string>() { "pear", "flour", "pork", "olive" };
            List<string> words = new List<string>() { "pear", "flour", "pork", "olive" };

            while (consontants.Count > 0)
            {
                char currentVowel = vowel.Peek();
                char currentConsontant = consontants.Peek();
                for (int i = 0; i < 4; i++)
                {
                    if (consontants.Count <= 0)
                    {
                        break;
                    }
                    
                    if (words[i].Contains(currentVowel))
                    {
                        words[i] = words[i].Replace(currentVowel, ' ');
                    }

                    if (words[i].Contains(currentConsontant))
                    {
                        words[i] = words[i].Replace(currentConsontant, ' ');
                    }


                }
                vowel.Dequeue();
                vowel.Enqueue(currentVowel);
                consontants.Pop();
            }

            int wordsCount = 0;
            foreach (var word in words)
            {
                if (word.ToString().Trim() == "")
                {
                    wordsCount++;
                }
            }

            Console.WriteLine($"Words found: {wordsCount}");
            for (int i = 0; i < 4; i++)
            {
                if (words[i].Trim() == "")
                {
                    Console.WriteLine(wordsConstant[i]);
                }
            }
        }
    }
}
