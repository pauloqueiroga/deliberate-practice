using pauloq.SetsSolutionEngine;
using System;

namespace pauloq.SolveTodaysPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = new WebSiteTranslator();
            var board = new Board(new[]
            {
                translator.CardById(9),
                translator.CardById(7),
                translator.CardById(6),
                translator.CardById(64),
                translator.CardById(30),
                translator.CardById(49),
                translator.CardById(66),
                translator.CardById(77),
                translator.CardById(72),
                translator.CardById(8),
                translator.CardById(37),
                translator.CardById(54),
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
