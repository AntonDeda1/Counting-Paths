using System;
using System.Collections.Generic;

namespace CoordinatePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter X: ");
            string inputX = Console.ReadLine();

            Console.Write("Enter Y: ");
            string inputY = Console.ReadLine();

            int X = 0;
            int Y = 0;

            try
            {
                X = int.Parse(inputX);
                Y = int.Parse(inputY);

                if (X < 0 || X > 1000 || Y < 0 || Y > 1000)
                {
                    Console.WriteLine("Input values must be between 0 and 1000");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            int pathCount = CalculatePaths(X, Y);
            Console.WriteLine($"Number of paths: {pathCount}");

            var paths = GeneratePaths(X, Y);
            Console.WriteLine("All posible routes:");
            foreach (var path in paths)
            {
                Console.WriteLine(path);
            }
        }

        static int CalculatePaths(int X, int Y)
        {
            return Factorial(X + Y) / (Factorial(X) * Factorial(Y));
        }

        static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static List<string> GeneratePaths(int X, int Y)
        {
            List<string> paths = new List<string>();
            GeneratePathsRecursive(X, Y, 0, 0, "", 0, 0, paths);
            return paths;
        }

        static void GeneratePathsRecursive(int X, int Y, int currentX, int currentY, string path, int consecutiveE, int consecutiveN, List<string> paths)
        {
            if (currentX == X && currentY == Y)
            {
                paths.Add(path);
                return;
            }

            if (currentX < X && consecutiveE < 2)
            {
                GeneratePathsRecursive(X, Y, currentX + 1, currentY, path + "E", consecutiveE + 1, 0, paths);
            }

            if (currentY < Y && consecutiveN < 2)
            {
                GeneratePathsRecursive(X, Y, currentX, currentY + 1, path + "N", 0, consecutiveN + 1, paths);
            }
        }
    }
}
