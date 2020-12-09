using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9.Models
{
    public class RollingList
    {
        public RollingList(int maxSize)
        {
            MaxSize = maxSize;
            Set = new List<long>(MaxSize);
            EntriesInOrder = new Queue<long>(MaxSize);
        }

        public List<long> Set { get; set; }
        public Queue<long> EntriesInOrder { get; set; }
        public int MaxSize { get; set; }
       
        public void AddNewEntry(long entry)
        {
            if (Set.Count == MaxSize)
                Set.Remove(EntriesInOrder.Dequeue());

            Set.Add(entry);
            EntriesInOrder.Enqueue(entry);
        }

        public bool HasPairThatTotalNum(long target)
        {
            return Set.Any(number => Set.Contains(target - number));
        }
    }
}