namespace WordLadderSolver
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class LadderRecurser
    {
        private readonly string _rootWord;
        private readonly bool _notforTheLulz;
        private string[] _wordDictionary;
        private bool foundWord = false;
        private byte[] wordbytes = { 99, 97, 116, 115 };

        /// <summary>
        /// Ladder Search
        /// </summary>
        /// <param name="rootWord">root word for ladder</param>
        /// <param name="wordDictionary">the word collection</param>
        public LadderRecurser(string rootWord, string[] wordDictionary, bool notforTheLulz)
        {
            _rootWord = rootWord;
            _wordDictionary = wordDictionary;
            _notforTheLulz = notforTheLulz;
        }

        public void CreateLadders()
        {
            if (_notforTheLulz)
            { 
                FindFirstRung(_rootWord, new List<string>(), ref _wordDictionary);
                return;
            }

            FindLadder(_rootWord, new List<string>(), ref _wordDictionary);
        }

        private void FindLadder(string word, List<string> ladder, ref string[] wordDictionary)
        {
            List<string> rungWords = new List<string>();
            int charIndex = 0;
            foreach (char c in word)
            {
                var regexString = word.Replace('.', charIndex);
                Regex regex = new Regex(regexString);

                // Use Foreach to build next rungs
                Array.ForEach(wordDictionary, current =>
                {
                    if (regex.IsMatch(current))
                    {
                        if (current == word || rungWords.Contains(current) || ladder.Contains(current)) return;
                        
                        rungWords.Add(current);
                    }
                });

                charIndex++;
            }  

            ladder.Add(word);

            // end of ladder dont print
            if (rungWords.Count == 0)
            {
                return;
                //    // Output the ladder
                //    Console.WriteLine("\n");
                //    Console.WriteLine("=====New Ladder===");
                //    ladder.ForEach(x =>
                //    {

                //        Console.WriteLine(x);

                //    });
                //    Console.WriteLine("=====Ladder End===");
                //    return;
            }

            rungWords.ForEach(current =>
            {
                
                if (current == Encoding.ASCII.GetString(wordbytes))
                {
                    if (foundWord == true)
                    {
                        return;
                    }

                    foundWord = true;

                    // Output the ladder
                    Console.WriteLine("\n");
                    Console.WriteLine("=====New Ladder===");
                    ladder.ForEach(x =>
                    {
                        Console.WriteLine(x);
                    });

                    Console.WriteLine(current);
                    Process.Start("http://tinyurl.com/ng587pc"); // Should not be visited without running programme first
                    Console.WriteLine("===== Ladder To " + current + " Ends - May it brighten your day :D ===");
                }

                if (foundWord)
                {
                    return;
                }
                
                // Call Recursive for spanning tree 
                FindLadder(current, ladder, ref _wordDictionary);
            });
        }

        private void FindFirstRung(string word, List<string> ladder, ref string[] wordDictionary)
        {
            List<string> rungWords = new List<string>();
            int charIndex = 0;
            foreach (char c in word)
            {
                Regex regex = new Regex(word.Replace('.', charIndex));

                // Use Foreach to build next rungs - could use linq here
                // possibly slower? would need to prove
                Array.ForEach(wordDictionary, current =>
                {
                    if (regex.IsMatch(current))
                    {
                        if (current == word) return;
                        if (rungWords.Contains(current)) return;
                        if (ladder.Contains(current)) return;

                        rungWords.Add(current);
                    }
                });

                charIndex++;
            }

            ladder.Add(word);

            // Since we're only doing first rung - otherwise recursive
            int ladderIndex = 1;
            rungWords.ForEach(current =>
            {
                Console.WriteLine("\n");
                Console.WriteLine("===== Ladder " + ladderIndex + " ===");
                Console.WriteLine(ladder[0]);
                Console.WriteLine(current);
                Console.WriteLine("===================");
                ladderIndex++;
            });
        }
    }
}
