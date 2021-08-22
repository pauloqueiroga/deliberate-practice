using pauloq.SetsSolutionEngine;
using System;

namespace pauloq.SolveTodaysPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(new[]
            {
                new Card(Colors.Purple, Shapes.Diamond, Fills.Solid, Numbers.Triple),
                new Card(Colors.Purple, Shapes.Diamond, Fills.Empty, Numbers.Triple),
                new Card(Colors.Purple, Shapes.Diamond, Fills.Lines, Numbers.Double),
                new Card(Colors.Green, Shapes.Oval, Fills.Empty, Numbers.Single),
                new Card(Colors.Red, Shapes.Oval, Fills.Lines, Numbers.Triple),
                new Card(Colors.Green, Shapes.Diamond, Fills.Lines, Numbers.Triple),
                new Card(Colors.Green, Shapes.Diamond, Fills.Solid, Numbers.Triple),
                new Card(Colors.Purple, Shapes.Squiggle, Fills.Lines, Numbers.Triple),
                new Card(Colors.Green, Shapes.Squiggle, Fills.Empty, Numbers.Triple),
                new Card(Colors.Purple, Shapes.Oval, Fills.Empty, Numbers.Triple),
                new Card(Colors.Purple, Shapes.Oval, Fills.Empty, Numbers.Single),
                new Card(Colors.Red, Shapes.Squiggle, Fills.Solid, Numbers.Triple),
            });

            var solver = new Solver(board);
            var solution = solver.BruteForceSolve();

            foreach (var sol in solution)
            {
                foreach (var card in sol)
                {
                    Console.WriteLine($"{card.Color}, {card.Shape}, {card.Fill}, {card.Number}");
                }

                Console.WriteLine("--------------------");
            }
        }
    }
}
