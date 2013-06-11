using System;
using System.Linq;

namespace CountManyWordsInHugeText
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }

        public void AddWord(string word)
        {
            var wordLen = word.Length;
            TrieNode current = root;
            for (int i = 0; i < wordLen; i++)
            {
                var nextStr = word[i];

                if (i == wordLen - 1)
	            {
		             current.AddChild(nextStr, true);
	            }
                else
                {
                    current.AddChild(nextStr, false);
                }

                current = current.Children[word[i]];
            }
        }

        /// <summary>
        /// Searches for a FULL MATCH of predefined word 
        /// Example: will not consider "alp" if "alpha" is predefined as word
        /// and "alp" is not specifically predefined 
        /// word whereas ContainsStr() will consider it a match and will return yes
        /// </summary>
        /// <param name="word">Full word to search for</param>
        /// <returns>True if finds word or false otherwise</returns>
        public bool ContainsWord(string word, out int occurances)
        {
            occurances = 0;

            bool containsWord = false;

            var wordToLower = word.ToLower();            
            var wordLen = word.Length;
            var current = this.root;

            for (int i = 0; i < wordLen; i++)
            {
                var nextChar = wordToLower[i];
                if (current.Children.ContainsKey(nextChar))
                {
                    current = current.Children[nextChar];
                }
                else
                {
                    break;
                }
                
                if (i == wordLen - 1 && current.IsWord)
                {
                    containsWord = true;
                    occurances = current.Occurances;
                }
                
            }

            return containsWord;
        }

        /// <summary>
        /// Searches for a PARTIAL MATCH in begginning of each predefined word 
        /// Example: will find "alp" if "alpha" is predefined as word whereas ContainsWord() will not
        /// </summary>
        /// <param name="str">string or part of word to search for</param>
        /// <returns>true if finds string or false otherwise</returns>
        public bool ContainsStr(string str)
        {
            bool containsStr = true;
            var strLow = str.ToLower();
            var current = this.root;
            for (int i = 0; i < str.Length; i++)
            {
                var nextChar = strLow[i];
                if (current.Children.ContainsKey(nextChar))
                {
                    current = current.Children[nextChar];
                }
                else
                {
                    containsStr = false;
                    break;
                }                
            }

            return containsStr;
        }

        public void BuildTrie(string loongString)
        {
            var current = this.root;

            for (int i = 0; i < loongString.Length; i++)
            {
                var currChar = loongString[i];

                currChar = currChar.ToString().ToLower()[0]; //TODO refactor for performance maybe neccessary...

                if (current.Children.ContainsKey(currChar))
                {
                    if (current.Children[currChar] == null)
                    {
                        current.SetIsWord();
                        current = this.root;
                    }
                    else
                    {
                        current = current.Children[currChar];
                    }
                }
                else
                {
                    current.AddChild(currChar, false);
                    current = current.Children[currChar];
                }                
            }                       
            
        }
    }
}
