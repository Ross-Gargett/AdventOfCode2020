using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day6.Services
{
    internal class ProblemSolverDaySix : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllText("Input.txt").Split(Environment.NewLine + Environment.NewLine);
            InputLines = InputLines.Select(l => l.Replace(Environment.NewLine, "")).ToList();
        }

        public void ReadInputFileWithGrouping()
        {
            InputLines = File.ReadAllText("Input.txt").Split(Environment.NewLine + Environment.NewLine);
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            Console.WriteLine(string.Format(DaySixConstants.DaySixPartOneAnswer,
                                InputLines.Sum(CountUniqueLetters)));
        }

        public void SolvePartTwo()
        {
            ReadInputFileWithGrouping();
            var totalSharedQuestions = 0;

            foreach (var group in InputLines)
            {
                var groupMembers = group.Split(Environment.NewLine);
                var groupAnswers = new int[groupMembers.Length];
                
                for (var i = 0; i < groupMembers.Length; i++)
                {
                    groupAnswers[i] = GetBitVectorForOneLineString(groupMembers[i]);
                }

                //AND all group members answers to find common answers and count.
                var andResult = groupAnswers[0];

                for (var i = 1; i < groupAnswers.Length; i++)
                {
                    andResult &= groupAnswers[i];
                }

                totalSharedQuestions += CountSetBits(andResult);
            }

            Console.WriteLine(string.Format(DaySixConstants.DaySixPartTwoAnswer, 
                              totalSharedQuestions));
        }

        private static int CountUniqueLetters(string groupAnswers)
        {
            return CountSetBits(GetBitVectorForOneLineString(groupAnswers));
        }

        /// <summary>
        /// Get a single integer with a bit flipped to 1 in
        /// the position 1 through 26 representing each letter
        /// of the alphabet.
        /// </summary>
        /// <param name="groupAnswers"></param>
        /// <returns></returns>
        private static int GetBitVectorForOneLineString(string groupAnswers)
        {
            var bitVector = 0;

            foreach (var letter in groupAnswers.ToCharArray())
            {
                if (!char.IsLetter(letter)) continue;

                var charIndex = GetNumericalIndexForLetter(letter);

                if ((bitVector & (1 << charIndex)) == 0)
                {
                    bitVector |= (1 << charIndex);
                }
            }

            return bitVector;
        }

        private static int GetNumericalIndexForLetter(char letter)
        {
            return letter % 32;
        }

        private static bool IsValid(int character)
        {
            return character >= 1 && character <= 26; ;
        }

        private static int CountSetBits(int bitVector)
        {
            var count = 0;

            //Continue until the bitVector is all 0's
            while (bitVector > 0)
            {
                //If the LSB is 1, count it.
                //Then shift all bits to the left
                count += bitVector & 1;
                bitVector >>= 1;
            }

            return count;
        }
    }
}
