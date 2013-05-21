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
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// The Puzzle Solver - Attempting to Solving Word Ladder Problems Since 2013
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = "\\Data\\dictionary.txt";
            var rootWord = "bill";

            // Load Dictionary
            DictionaryWordLoader loader = new DictionaryWordLoader(string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file));
            string[] wordlist = loader.ReadFile();

            // Kick of Recursive Algorithm
            LadderRecurser ladders = new LadderRecurser(rootWord, wordlist);
            ladders.CreateLadders();
        }      
    }
}
