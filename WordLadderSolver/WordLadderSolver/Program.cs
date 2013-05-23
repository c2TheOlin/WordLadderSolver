// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="SSE">
//   Fo Shizzle Productions 
// </copyright>
// <summary>
//   Puzzle Solver for ETT
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordLadderSolver
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// The Puzzle Solver - Attempting to Solving Word Ladder Problems Since 2013
    /// Im certain there are better algorthms to do this. 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.Write("Enter [1] Run short First Rung Example or... [2] For 'other' search\n");
            bool waitForInput = true;
            bool processChoice = true;
            string userInput = string.Empty;
            while(waitForInput)
            {
                userInput = Console.ReadLine();
                if(userInput == "1" || userInput == "2")
                {
                    waitForInput = false;
                    processChoice = (userInput == "2") ? false : true;
                }
                else
                {
                    Console.WriteLine("Try Again - you have 10 seconds to comply");
                }
            }

            Console.WriteLine("==========Starting========");
            var file = "\\Data\\dictionary.txt";
            var rootWord = "bill";

            // Load Dictionary
            DictionaryWordLoader loader = new DictionaryWordLoader(string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file));
            string[] wordlist = loader.ReadFile();

            // Kick of Search
            LadderRecurser ladders = new LadderRecurser(rootWord, wordlist, processChoice);
            ladders.CreateLadders();

            Console.WriteLine("\nFree 12 variety box of Crispy Creme's if I Get the Role....");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("At least dont give it to Dan Bower..... what a bastard");
            System.Threading.Thread.Sleep(2000);
            Console.Write("Any character to finish");
            var name = Console.ReadLine();
        }      
    }

    public static class Extentions
    {
        public static string Replace(this String word, char newChar, int index)
        {
            StringBuilder sb = new StringBuilder(word);
            sb[index] = newChar;
            return sb.ToString();
        }
    }
}
