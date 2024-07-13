using System;
using System.Collections.Generic;

namespace CoordinatePaths
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter X:");
            string inputX = Console.ReadLine();

            Console.Write("Enter Y: ");
            string inputY = Console.ReadLine();

            int X = 0;
            int Y = 0;

            try
            {

                if (X < 0 || X > 1000 || Y < 0 || Y > 1000)
                {
                    Console.WriteLine("Value must be 0 to 1000");
                    return;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Invalid input");
                return;
            }

            int pathCount = CalculatePaths(X, Y);

            Console.WriteLine($"Number of paths: {pathCount}");

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

    }
}
