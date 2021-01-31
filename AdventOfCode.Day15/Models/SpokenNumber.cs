using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day15.Models
{
    public class SpokenNumber
    {
        public SpokenNumber(int number, int firstTimeSpoken)
        {
            Number = number;
            TimesSpoken = new List<int> { firstTimeSpoken };
        }

        public int Number { get; set; }
        public List<int> TimesSpoken { get; set; }

        public void AddSpokenTurn(int turn)
        {
            TimesSpoken.Add(turn);
        }

        public int CalculateNextNum()
        {
            if (TimesSpoken.Count == 1) return 0;

            return TimesSpoken.Last() - TimesSpoken.ElementAt(TimesSpoken.Count - 2);
        }
        
        public override int GetHashCode()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpokenNumber)) return false;

            return this.Number == ((SpokenNumber)obj).Number;
        }
    }
}