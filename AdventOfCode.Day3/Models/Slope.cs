using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day3.Models
{
    class Slope
    {
        public Slope(int right, int down)
        {
            Right = right;
            Down = down;
        }

        public int Right { get; set; }
        public int Down { get; set; }
    }
}
