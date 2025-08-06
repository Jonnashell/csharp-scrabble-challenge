using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        // Initialize letter score dict
        private Dictionary<char, int> _scoreTable = new Dictionary<char, int> {
            { 'A', 1 },
            { 'E', 1 },
            { 'I', 1 },
            { 'O', 1 },
            { 'U', 1 },
            { 'L', 1 },
            { 'N', 1 },
            { 'R', 1 },
            { 'S', 1 },
            { 'T', 1 },

            { 'D', 2 },
            { 'G', 2 },

            { 'B', 3 },
            { 'C', 3 },
            { 'M', 3 },
            { 'P', 3 },

            { 'F', 4 },
            { 'H', 4 },
            { 'V', 4 },
            { 'W', 4 },
            { 'Y', 4 },

            { 'K', 5 },

            { 'J', 8 },
            { 'X', 8 },

            { 'Q', 10 },
            { 'Z', 10 },
        };
        public Scrabble(string word)
        {
            _word = word.ToUpper();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            // Score = 0
            // Multiplier = 1
            // For hver bokstav:
            //     Går vi inn i en bracket?
            //      Double: Multiplier = Multiplier * 2
            //      Triple: Multiplier = Multiplier * 3
            //     Score = Score + _scoreTable[bokstav] * Multiplier

            int score = 0;
            int multiplier = 1;
            bool inDouble = false;
            bool inTriple = false;
            foreach (char letter in _word)
            {
                // Check for numbers (invalid input)
                if (Char.IsDigit(letter))
                {
                    return 0;
                }

                // Detect double scores
                if (letter == '{')
                {
                    inDouble = true;
                    multiplier = multiplier * 2;
                }
                if (letter == '}')
                {
                    // Invalid case, no opening curly bracket first
                    if (!inDouble)
                    {
                        return 0;
                    }
                    multiplier = multiplier / 2;
                    inDouble = false;
                }

                // Detect triple scores
                if (letter == '[')
                {
                    inTriple = true;
                    multiplier = 3;
                }
                if (letter == ']')
                {
                    // Invalid case, no opening square bracket first
                    if (!inTriple)
                    {
                        return 0;
                    }
                    multiplier = multiplier / 3;
                    inTriple = false;
                }

                // Check for valid letters
                if (!_alphabet.Contains(letter))
                {
                    continue;
                }

                // Calculate score for valid letters
                score = score + _scoreTable[letter] * multiplier;
            }
            return score;
        }
    }
}
