using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Classes
{
    public interface IProblemSolver<T>
    {
        IEnumerable<T> InputLines { get; set; }

        void ReadInputFile();
        void SolvePartOne();
        void SolvePartTwo();
    }
}
