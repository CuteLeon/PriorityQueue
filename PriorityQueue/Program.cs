using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var queue = new PriorityQueue(new[] { 7, 1, 4, 2, 8, 3, 5, 9, 8, 6 });
            Console.WriteLine(string.Join("\n", queue));
        }
    }
}
