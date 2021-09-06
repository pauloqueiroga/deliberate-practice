using pauloq.SetsSolutionEngine;
using System;

namespace pauloq.SolveTodaysPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = new WebSiteTranslator();
            var board = translator.FetchTodaysBoard();
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
