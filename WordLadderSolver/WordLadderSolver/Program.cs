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
            string path = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);

            var rootWord = "bill";
            List<string> wordLadder = new List<string>();
            Dictionary<string, int> letterCount = new Dictionary<string, int>();

            // Start The Proceedrue
            DictionaryWordLoader loader = new DictionaryWordLoader(path);
            string[] wordlist = loader.ReadFile();

            var result = ContainsWord(rootWord, ref wordlist);
        }

        private static bool ContainsWord(string word, ref string[] wordlist)
        {
           return wordlist.AsParallel().Contains(word);
        }
    }
}
