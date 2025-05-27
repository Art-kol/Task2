using System;

namespace Task2
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Function[] functions = new Function[]
                {
                    new LinearFunction(2, 3),
                    new QuadraticFunction(1, -2, 1),
                    new Hyperbola(4),
                    new LinearFunction(-1, 5),
                    new QuadraticFunction(0.5, 0, 0),
                    new Hyperbola(-2)
                };

                Console.WriteLine("Original functions:");
                foreach (var func in functions)
                {
                    func.Display();
                    Console.WriteLine($"y(2) = {func.Calculate(2)}");
                    Console.WriteLine();
                }

                // Сортировка происходит в согласовании с переписанным CompareTo
                Array.Sort(functions);

                Console.WriteLine("\nSorted functions (by coefficient a):");
                foreach (var func in functions)
                {
                    func.Display();
                }

                Console.WriteLine("\nTesting operations:");
                var f1 = new LinearFunction(2, 3);
                var f2 = new LinearFunction(1, 4);
                var sum = f1 + f2;
                sum.Display();

                var q1 = new QuadraticFunction(1, 2, 3);
                var q2 = new QuadraticFunction(2, 3, 4);
                var qSum = q1 + q2;
                qSum.Display();

                var h1 = new Hyperbola(3);
                var h2 = new Hyperbola(5);
                var hSum = h1 + h2;
                hSum.Display();

                Console.WriteLine("\nTesting exceptions:");
                try
                {
                    var badHyperbola = new Hyperbola(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                try
                {
                    var h = new Hyperbola(1);
                    Console.WriteLine(h.Calculate(0));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                try
                {
                    var invalidSum = f1 + q1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            // Сборка мусора и вызов деструкторов
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}