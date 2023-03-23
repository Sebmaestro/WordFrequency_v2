namespace WordFrequency
{
    public class WordFrequency
    {
        /// <summary>
        /// Calculates the amount of times a word occured in a text
        /// </summary>
        public Dictionary<string, int> CalculateWords(string text)
        {        
            char[] delimiter = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '\t', '"', '(', ')', '-' };
            string[] words = text.Split(delimiter);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                //Converts all the words to lowercase
                string lowerCaseWord = word.ToLower();

                if (word.Length >= 2)
                {
                    if (wordCounts.ContainsKey(lowerCaseWord))
                    {
                        wordCounts[lowerCaseWord]++;
                    }
                    else if (!wordCounts.ContainsKey(lowerCaseWord))
                    {
                        wordCounts.Add(lowerCaseWord, 1);
                    }
                }
            }

            //Sort by word occurence
            Dictionary<string, int> ordered = wordCounts.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, int> mostFrequentWords = new Dictionary<string, int>();

            //Trim to top 10 most occured words
            int count = 0;
            foreach (KeyValuePair<string, int> word in ordered)
            {
                if (count == 10)
                    break;
                mostFrequentWords.Add(word.Key, word.Value);
                count++;
            }

            return mostFrequentWords;
        }
    }
}
