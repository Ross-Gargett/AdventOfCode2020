using System;
using System.Collections.Generic;
using AdventOfCode.Day15.Models;

namespace AdventOfCode.Day15.Services
{
    public class ElfMemoryGameSimulator
    {
        private readonly IEnumerable<int> _input;

        private HashSet<SpokenNumber> _spokenNumbers;

        public ElfMemoryGameSimulator(IEnumerable<int> input)
        {
            _input = input;
            _spokenNumbers = new HashSet<SpokenNumber>();
        }
        
        public int SimulateElfGame(int targetTurn)
        {
            var turn = 1;
            var lastNum = -1;

            foreach (var num in _input)
            {
                _spokenNumbers.Add(new SpokenNumber(num, turn));
                lastNum = num;
                turn++;
            }

            while (turn <= targetTurn)
            {
                var lastNumObj = GetSpokenNumFromCollectionOrCreateNew(lastNum, turn);
                lastNum = lastNumObj.CalculateNextNum();

                AddSpokenNumToCollectionOrAddTurn(lastNum, turn);
                turn++;
            }

            return lastNum;
        }

        private SpokenNumber GetSpokenNumFromCollectionOrCreateNew(int lastNum, int turn)
        {
            SpokenNumber spokenNum;
            var tempSpokenNum = new SpokenNumber(lastNum, turn);

            if (!_spokenNumbers.TryGetValue(tempSpokenNum, out spokenNum))
            {
                _spokenNumbers.Add(tempSpokenNum);
                spokenNum = tempSpokenNum;
            }
                
            return spokenNum;
        }

        private void AddSpokenNumToCollectionOrAddTurn(int lastNum, int turn)
        {
            SpokenNumber spokenNum;
            var tempSpokenNum = new SpokenNumber(lastNum, turn);

            if (_spokenNumbers.TryGetValue(tempSpokenNum, out spokenNum))
                spokenNum.AddSpokenTurn(turn);
            else
                _spokenNumbers.Add(tempSpokenNum);
        }
    }
}