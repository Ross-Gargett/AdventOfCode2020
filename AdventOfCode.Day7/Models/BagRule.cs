using System.Collections.Generic;

namespace AdventOfCode.Day7.Models
{
    public class BagRule
    {
        public BagRule(string color, List<string> bags)
        {
            Color = color;
            ContainedBag = bags;
        }

        public string Color { get; set; }
        public List<string> ContainedBag { get; set; }
    }
}
