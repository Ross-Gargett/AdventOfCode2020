using System;

namespace AdventOfCode.Classes
{
    public interface IProblemSolver
    {
        void ReadInputFile();
        object SolvePartOne();
        object SolvePartTwo();
    }
}
