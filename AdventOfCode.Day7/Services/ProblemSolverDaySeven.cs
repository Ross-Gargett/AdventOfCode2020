using System;
using AdventOfCode.Classes;
using AdventOfCode.Day7.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day7.Services
{
    class ProblemSolverDaySeven : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        private readonly Dictionary<string, Bag> _bags = new Dictionary<string, Bag>();

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
            ParseBagRules();
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var totalPossibleParents = _bags["shiny gold"] != null ? CountAllStartingParents(_bags["shiny gold"]) : 0;
            Console.WriteLine(string.Format(DaySevenConstants.DaySevenPartOneAnswer,
                totalPossibleParents));
        }
        
        public void SolvePartTwo()
        {
            var totalRequiredChildren = _bags["shiny gold"] != null ? CountAllContainedChildren(_bags["shiny gold"]) : 0;
            Console.WriteLine(string.Format(DaySevenConstants.DaySevenPartTwoAnswer,
                totalRequiredChildren));
        }

        private void ParseBagRules()
        {
            foreach (var rule in InputLines)
            {
                var splitRule = rule.Split("bags contain");
                var color = splitRule[0].Trim();
                var allContainedBags = splitRule[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(bag => bag.Trim()).ToList();

                if(!_bags.ContainsKey(color))
                    _bags.Add(color, new Bag(color));

                var bag = _bags[color];

                foreach (var containedBag in allContainedBags)
                {
                    if (containedBag.EndsWith("no other bags."))
                        continue;

                    var quantity = Regex.Match(containedBag, @"^\d+").ToString();
                    var subColor = containedBag.Substring(quantity.Length).Split("bag")[0].Trim();

                    if (!_bags.ContainsKey(subColor))
                        _bags.Add(subColor, new Bag(subColor));

                    var childBag = _bags[subColor];
                    childBag.Parents.Add(bag);
                    bag.Children.Add(new ChildBags { Child = childBag, Quantity = quantity.ToInt() });
                }
            }
        }

        private int CountAllStartingParents(Bag bag)
        {
            var possibleParents = 0;
            var bagsToCheck = new Queue<Bag>();
            bag.Counted = true;
            bagsToCheck.Enqueue(bag);

            while (bagsToCheck.Any())
            {
                var checkedBag = bagsToCheck.Dequeue();

                if(checkedBag != bag)
                    possibleParents++;

                foreach (var parent in checkedBag.Parents)
                {
                    if (parent.Counted) continue;
                    parent.Counted = true;
                    bagsToCheck.Enqueue(parent);
                }
            }

            return possibleParents;
        }

        private int CountAllContainedChildren(Bag bag)
        {
            if (!bag.Children.Any())
                return 0;

            var totalChildren = 0;

            foreach (var child in bag.Children)
            {
                totalChildren += child.Quantity;
                totalChildren += child.Quantity * CountAllContainedChildren(child.Child);
            }

            return totalChildren;
        }
    }
}
