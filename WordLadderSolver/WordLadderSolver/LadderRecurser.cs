namespace WordLadderSolver
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

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
            _shortestLadder = new List<string>();
            _longestLadder = new List<string>();
        }

        public void CreateLadders()
        {
             FindNextRung(_rootWord, new List<string>(), ref _wordDictionary);
        }

        private void FindNextRung(string word, List<string> ladder, ref string[] wordDictionary)
        {
            List<string> rungWords = new List<string>();
            int charIndex = 0;
            foreach (char c in word)
            {
                var regexString = word.Replace('.', charIndex);
                Regex regex = new Regex(regexString);

                // Use Parallel Foreach to build next rungs
                Parallel.ForEach(wordDictionary, current => {
                    if (regex.IsMatch(current))
                    {
                        if (current == _rootWord) return;
                        if (rungWords.Contains(current)) return;
                        
                        rungWords.Add(current);
                    }
                });

                charIndex++;
            }
        }
    }
}
