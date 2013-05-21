namespace WordLadderSolver
{
    using System.IO;

    /// <summary>
    /// The file loader.
    /// </summary>
    public class DictionaryWordLoader
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryWordLoader"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public DictionaryWordLoader(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Load the file into an array
        /// </summary>
        /// <returns>string array of dictionary letters</returns>
       public string[] ReadFile()
       {
           return File.ReadAllLines(this._filePath);
       }
    }
}
