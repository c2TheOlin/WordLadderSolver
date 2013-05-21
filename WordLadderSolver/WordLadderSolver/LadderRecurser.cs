namespace WordLadderSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WordLadderSolver;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class LadderRecurser
    {
        private List<string> _shortestLadder;
        private List<string> _longestLadder;
        private readonly string _rootWord;
        string[] _wordDictionary;

        /// <summary>
        /// Breadth First Search Recursive Algorithm
        /// </summary>
        /// <param name="rootWord">root word for ladder</param>
        /// <param name="wordDictionary">the word collection</param>
        public LadderRecurser(string rootWord, string[] wordDictionary)
        {
            _rootWord = rootWord;
            _wordDictionary = wordDictionary;
        }

        public void CreateLadders()
        {
             FindNextRung(_rootWord, new List<string>(), ref _wordDictionary);
        }

        private void FindNextRung(string word, List<string> ladder, ref string[] wordDictionary)
        {
            List<string> rungWords = new List<string>();
            foreach (char c in word)
            {
                var regexString = word.Replace(c, '.');
                Regex regex = new Regex(regexString);

                // Use Parallel Foreach to build next rungs
                Parallel.ForEach(wordDictionary, current => {
                    if (regex.IsMatch(current))
                    {
                        rungWords.Add(current);
                    }
                }); 
            }
        }

    }
}
