using System;
using System.Diagnostics;

namespace TestforShifting
{
    class Program
    {
        static uint[] uIntArray = new uint[100000];
        static Stopwatch sw = new Stopwatch();

        static long StartTest(Func<uint, uint> calc)
        {
            uint temp;

            sw.Reset();
            sw.Start();

            for (int i = 0; i < 100000; ++i)
            {
                temp = calc(uIntArray[i]);
            }

            sw.Stop();

            return sw.ElapsedTicks;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("This is a test for baseDmg between normal operators and bit-shifting");
            Console.WriteLine("Generating 100,000 indexed array with random damage numbers between 100 - 200...");
            Console.WriteLine();
            
            for (int i = 0; i < 100000; ++i)
            {
                uIntArray[i] = (uint)rnd.Next(100, 200);
            }

            for (int i = 0; i < 20; ++i)
            {
                Console.WriteLine("  {0}", uIntArray[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Array initialized now. Displayed the first 20 numbers of the array");
            Console.WriteLine();

            Console.WriteLine("Starting the expert mode baseDmg test using baseDmg * 2 method...");
            Console.WriteLine("Complete.      Time: {0}", StartTest((x) => { return x * 2; }));

            Console.WriteLine("Starting the expert mode baseDmg test using baseDmg << 1 method...");
            Console.WriteLine("Complete.      Time: {0}", StartTest((x) => { return x << 1; }));

            Console.WriteLine("Starting the normal mode baseDmg test using (int)((double)baseDmg * 1.5) method...");
            Console.WriteLine("Complete.      Time: {0}", StartTest((x) => { return (uint)((double)x * 1.5); }));

            Console.WriteLine("Starting the normal mode baseDmg test using baseDmg + (baseDmg >> 1) method...");
            Console.WriteLine("Complete.      Time: {0}", StartTest((x) => { return x + (x >> 1); }));

            Console.ReadKey();
        }
    }
}
