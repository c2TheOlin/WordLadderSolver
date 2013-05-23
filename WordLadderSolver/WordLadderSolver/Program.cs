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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Text;

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public static class Extentions
    {
        /// <summary>
        /// Given and index replace the character at that index with a new character
        /// use of index to avoid duplicate letter clash
        /// </summary>
        /// <param name="word">the word</param>
        /// <param name="newChar">the new character</param>
        /// <param name="index">the index of the target character</param>
        /// <returns>the word after the replacement</returns>
        public static string Replace(this string word, char newChar, int index)
        {
            StringBuilder sb = new StringBuilder(word);
            sb[index] = newChar;
            return sb.ToString();
        }
    }

    /// <summary>
    /// The Puzzle Solver - Attempting to Solving Word Ladder Problems Since 2013
    /// I'm certain there are better algorithms to do this. 
    /// </summary>
    public class Program
    {
        private const string _File = "\\Data\\dictionary.txt";
        private const string _RootWord = "bill";

        public static void Main(string[] args)
        {
            Console.BufferHeight = short.MaxValue - 1;
            Console.Write("Enter [1] Run short First Rung Example or... [2] For 'other' search\n");
            bool waitForInput = true;
            bool processChoice = true;

            while (waitForInput)
            {
                string userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2")
                {
                    waitForInput = false;
                    processChoice = userInput != "2";
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }

            Console.WriteLine("==========Starting========");
         
            // Load Dictionary
            DictionaryWordLoader loader = new DictionaryWordLoader(string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _File));
            string[] wordlist = loader.ReadFile();

            // Kick of Search
            LadderRecurser ladders = new LadderRecurser(_RootWord, wordlist, processChoice);
            ladders.CreateLadders();

            Console.WriteLine("\nFree 12 variety box of Crispy Creme's if I Get the Role....");
            Console.Write("Any character to finish");
            Console.ReadLine();
        }      
    }

  
}
