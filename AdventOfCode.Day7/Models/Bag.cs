using System.Collections.Generic;

namespace AdventOfCode.Day7.Models
{
    public class Bag
    {
        public Bag(string color)
        {
            Color = color;
            Children = new List<ChildBags>();
            Parents = new List<Bag>();
        }

        public string Color { get; set; }
        public List<ChildBags> Children { get; set; }
        public List<Bag> Parents { get; set; }
        public bool Counted { get; set; }
    }

    public class ChildBags
    {
        public int Quantity { get; set; }
        public Bag Child { get; set; }
    }
}