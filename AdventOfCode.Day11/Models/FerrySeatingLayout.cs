using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace AdventOfCode.Day11.Models
{
    public class FerrySeatingLayout
    {
        private readonly SeatState[,] _seatLayout;

        #region Constructors

        public FerrySeatingLayout(FerrySeatingLayout existingLayout)
        {
            Rows = existingLayout.Rows;
            Columns = existingLayout.Columns;
            _seatLayout = new SeatState[Rows, Columns];
        }

        public FerrySeatingLayout(char[][] input)
        {
            Rows = input.Length;
            Columns = input[0].Length;
            _seatLayout = new SeatState[Rows, Columns];

            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    _seatLayout[row, column] = MapCharToSeatState(input[row][column]);
                }
            }
        }

        #endregion

        #region Properties
        
        public int Rows { get; set; }
        public int Columns { get; set; }

        #endregion

        #region Methods

        public FerryRuleResult ApplyRulesToAllSeats()
        {
            var result = new FerryRuleResult {NewLayout = new FerrySeatingLayout(this), TotalChanges = 0};
            //PrintFerry();

            for (var row = 0; row < _seatLayout.GetLength(0); row++)
            {
                for (var column = 0; column < _seatLayout.GetLength(1); column++)
                {
                    var newState = ApplyRule(_seatLayout[row, column], row, column);
                    result.NewLayout.SetSeat(newState, row, column);

                    if (newState != _seatLayout[row, column])
                        result.TotalChanges ++;
                }
            }

            return result;
        }

        public FerryRuleResult ApplyRuleTwoToAllSeats()
        {
            var result = new FerryRuleResult { NewLayout = new FerrySeatingLayout(this), TotalChanges = 0 };
            //PrintFerry();

            for (var row = 0; row < _seatLayout.GetLength(0); row++)
            {
                for (var column = 0; column < _seatLayout.GetLength(1); column++)
                {
                    var newState = ApplyRuleTwo(_seatLayout[row, column], row, column);
                    result.NewLayout.SetSeat(newState, row, column);

                    if (newState != _seatLayout[row, column])
                        result.TotalChanges++;
                }
            }

            return result;
        }

        private void SetSeat(SeatState newState, int row, int column)
        {
            _seatLayout[row, column] = newState;
        }

        #region Rule One Methods

        private SeatState ApplyRule(SeatState state, int row, int column)
        {
            var newState = state;

            List<SeatState> adjacentSeats;

            switch (state)
            {
                case SeatState.Empty:
                    adjacentSeats = GetAdjacentSeats(row, column);

                    if (adjacentSeats.TrueForAll(s => s != SeatState.Occupied))
                    {
                        newState = SeatState.Occupied;
                    }
                    break;
                case SeatState.Occupied:
                    adjacentSeats = GetAdjacentSeats(row, column);

                    if (adjacentSeats.Count(s => s == SeatState.Occupied) >= 4)
                    {
                        newState = SeatState.Empty;
                    }
                    break;
            }

            return newState;
        }

        private List<SeatState> GetAdjacentSeats(int row, int column)
        {
            var adjacent = new List<SeatState>();
            bool firstRow = row == 0,
                lastRow = row == Rows - 1,
                firstCol = column == 0,
                lastCol = column == Columns - 1;

            if (!firstRow)
            {
                if (!firstCol)
                {
                    adjacent.Add(_seatLayout[row - 1, column - 1]);
                }

                adjacent.Add(_seatLayout[row - 1, column]);

                if (!lastCol)
                {
                    adjacent.Add(_seatLayout[row - 1, column + 1]);
                }
            }

            if (!firstCol)
            {
                adjacent.Add(_seatLayout[row, column - 1]);
            }

            if (!lastCol)
            {
                adjacent.Add(_seatLayout[row, column + 1]);
            }

            if (lastRow) return adjacent;

            if (!firstCol)
            {
                adjacent.Add(_seatLayout[row + 1, column - 1]);
            }

            adjacent.Add(_seatLayout[row + 1, column]);

            if (!lastCol)
            {
                adjacent.Add(_seatLayout[row + 1, column + 1]);
            }

            return adjacent;
        }

        #endregion

        #region Rule Two Methods

        private SeatState ApplyRuleTwo(SeatState state, int row, int column)
        {
            var newState = state;

            List<SeatState> adjacentSeats;

            switch (state)
            {
                case SeatState.Empty:
                    adjacentSeats = GetVisibleAdjacentOccupiedSeats(row, column);

                    if (!adjacentSeats.Any())
                    {
                        newState = SeatState.Occupied;
                    }
                    break;
                case SeatState.Occupied:
                    adjacentSeats = GetVisibleAdjacentOccupiedSeats(row, column);

                    if (adjacentSeats.Count() >= 5)
                    {
                        newState = SeatState.Empty;
                    }
                    break;
            }

            return newState;
        }

        private List<SeatState> GetVisibleAdjacentOccupiedSeats(int row, int column)
        {
            var adjacent = new List<SeatState>
            {
                
                GetFirstVisibleOccupiedInDirection(row, column, -1, 0) ?? SeatState.Floor,  //N
                GetFirstVisibleOccupiedInDirection(row, column, -1, 1) ?? SeatState.Floor,  //NE
                GetFirstVisibleOccupiedInDirection(row, column, 0, 1) ?? SeatState.Floor,   //E
                GetFirstVisibleOccupiedInDirection(row, column, 1, 1) ?? SeatState.Floor,   //SE
                GetFirstVisibleOccupiedInDirection(row, column, 1, 0) ?? SeatState.Floor,   //S
                GetFirstVisibleOccupiedInDirection(row, column, 1, -1) ?? SeatState.Floor,  //SW
                GetFirstVisibleOccupiedInDirection(row, column, 0, -1) ?? SeatState.Floor,  //W
                GetFirstVisibleOccupiedInDirection(row, column, -1, -1) ?? SeatState.Floor, //NW
            };

            adjacent.RemoveAll(s => s == SeatState.Floor);

            return adjacent;
        }

        private SeatState? GetFirstVisibleOccupiedInDirection(int row, int column, int rowIncrement, int colIncrement)
        {
            int currentRowIndex = row + rowIncrement,
                currentColIndex = column + colIncrement;

            while (currentRowIndex < Rows && currentColIndex < Columns &&
                   currentRowIndex >= 0 && currentColIndex >= 0)
            {
                switch (_seatLayout[currentRowIndex, currentColIndex])
                {
                    case SeatState.Occupied:
                        return SeatState.Occupied;
                    case SeatState.Empty:
                        return null;
                    default:
                        currentRowIndex += rowIncrement;
                        currentColIndex += colIncrement;
                        break;
                }
            }

            return null;
        }

        #endregion

        public int CountOccupiedSeats()
        {
            return (from seat in _seatLayout.Cast<SeatState>()
                    where seat == SeatState.Occupied
                    select seat).Count();
        }

        private static SeatState MapCharToSeatState(char charSeat)
        {
            return charSeat switch
            {
                '.' => SeatState.Floor,
                'L' => SeatState.Empty,
                '#' => SeatState.Occupied,
                _ => throw new System.NotImplementedException()
            };
        }

        private void PrintFerry()
        {
            for (var row = 0; row < _seatLayout.GetLength(0); row++)
            {
                for (var column = 0; column < _seatLayout.GetLength(1); column++)
                {
                    Console.Write(MapSeatStateToChar(_seatLayout[row, column]));
                }

                Console.Write("\n");
            }
            Console.Write("\n\n");
        }

        private char MapSeatStateToChar(SeatState state)
        {
            return state switch
            {
                SeatState.Floor => '.',
                SeatState.Empty => 'L',
                SeatState.Occupied => '#',
                _ => throw new System.NotImplementedException()
            };
        }

        #endregion
    }

    internal enum SeatState
    {
        Floor = 0,
        Empty,
        Occupied
    }
}