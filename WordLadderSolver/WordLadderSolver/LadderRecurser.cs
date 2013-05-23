namespace WordLadderSolver
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class LadderRecurser
    {
        private readonly byte[] _wordBytes = { 99, 97, 116, 115 };
        private readonly byte[] _otherWords = { 73, 32, 67, 65, 78, 32, 72, 65, 83, 32 };
        private readonly string _rootWord;
        private readonly bool _notforTheLulz;
        private string[] _wordDictionary;
        private bool foundWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="LadderRecurser"/> class. 
        /// Ladder Search
        /// </summary>
        /// <param name="rootWord"> root word for ladder  </param>
        /// <param name="wordDictionary"> the word collection  </param>
        /// <param name="notforTheLulz"> The not for The Lulz.  </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public LadderRecurser(string rootWord, string[] wordDictionary, bool notforTheLulz)
        {
            // Apologies for the this' everywhere
            this._rootWord = rootWord;
            this._wordDictionary = wordDictionary;
            this._notforTheLulz = notforTheLulz;
        }

        public void CreateLadders()
        {
            if (this._notforTheLulz)
            { 
                this.FindFirstRung(this._rootWord, new List<string>(), ref this._wordDictionary);
                return;
            }

            this.FindLadder(this._rootWord, new List<string>(), ref this._wordDictionary);
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
                Array.ForEach(
                    wordDictionary,
                    current =>
                        {
                            if (!regex.IsMatch(current))
                            {
                                return;
                            }

                            if (current == word || rungWords.Contains(current) || ladder.Contains(current))
                            {
                                return;
                            }

                            rungWords.Add(current);
                        });

                charIndex++;
            }  

            ladder.Add(word);

            // end of ladder dont print
            if (rungWords.Count == 0)
            {
                // For Recursive where i'd out put ladder that has ended
                return;
            }

            rungWords.ForEach(current =>
            {
                if (current == Encoding.ASCII.GetString(this._wordBytes))
                {
                    if (this.foundWord)
                    {
                        return;
                    }

                    foundWord = true;

                    #region output
                    // Output the ladder
                    Console.WriteLine("\n");
                    Console.WriteLine("=====New Ladder===");
                    ladder.ForEach(Console.WriteLine);

                    Console.WriteLine(current + "?");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine(Encoding.ASCII.GetString(this._otherWords) + current + "?");
                    System.Threading.Thread.Sleep(2000);
                    Process.Start("http://tinyurl.com/ng587pc"); // Should not be visited without running programme first
                    #endregion
                }

                if (foundWord)
                {
                    return;
                }
                
                // Call Recursive for spanning tree 
                FindLadder(current, ladder, ref _wordDictionary);
            });
        }

        private void FindFirstRung(string word, IList<string> ladder, ref string[] wordDictionary)
        {
            List<string> rungWords = new List<string>();
            int charIndex = 0;
            foreach (char c in word)
            {
                Regex regex = new Regex(word.Replace('.', charIndex));

                // Use Foreach to build next rungs - could use linq here
                // Opted against Parrallel for as probably not much faster on such a small set
                // possibly slower? would need to prove
                Array.ForEach(
                    wordDictionary,
                    current =>
                        {
                            if (!regex.IsMatch(current))
                            {
                                return;
                            }

                            if (current == word || rungWords.Contains(current) || ladder.Contains(current))
                            {
                                return;
                            }

                            rungWords.Add(current);
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
