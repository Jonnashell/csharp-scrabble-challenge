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
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
            // Score = 0
            // For hver bokstav:
            //     Er vi i en double eller triple?
            //          Yes: Multiplier = 2 eller 3
            //          No: Multiplier = 1
            //     Score = Score + _scoreTable[bokstav] * Multiplier

            int score = 0;
            bool inDouble = false;
            bool inTriple = false;
            int multiplier = 1;
            foreach (char letter in _word)
            {
                // Detect double scores
                if (letter == '{')
                {
                    inDouble = true; multiplier = 2;
                }
                if (letter == '}')
                {
                    inDouble = false; multiplier = 1;
                }

                // Detect triple scores
                if (letter == '[')
                {
                    inTriple = true; multiplier = 3;
                }
                if (letter == ']')
                {
                    inTriple = false; multiplier = 1;
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
