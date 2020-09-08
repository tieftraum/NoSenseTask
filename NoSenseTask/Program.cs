using NoSenseTask.Extensions;
using System.Collections.Generic;
using System.Linq;
using System;
using NoSenseTask.Helpers;
using System.Threading;

namespace NoSenseTask
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[1];
            Console.Write("Enter coma separated numbers: ");
            
            args[0] = Console.ReadLine();
            var collection = HelperTools.StringToIntEnumerable(args[0]);
            var result = collection.ThisDoesntMakeSense(p => p < int.MaxValue, l =>
            {
                IList<int> vs1 = new List<int>();
                foreach (var item in l)
                {
                    vs1.Add(item + 5);
                }
                return vs1;
            });
            result.ToList().ForEach(p =>
            {
                Console.Write($"{p} ");
            });

            Thread.Sleep(1000);
            Console.WriteLine();
            Thread.Sleep(1000);

            var collection1 = HelperTools.StringToIntEnumerable(args[0]);
            var result1 = collection1.ThisDoesntMakeSense(p => p > int.MaxValue, l =>
            {
                IList<int> vs1 = new List<int>();
                foreach (var item in l)
                {
                    vs1.Add(item + 5);
                }
                return vs1;
            });
            result1.ToList().ForEach(p =>
            {
                Console.Write($"{p} ");
            });

            Thread.Sleep(1000);
            Console.WriteLine();

            args[0] = null;

            var collection2 = HelperTools.StringToIntEnumerable(args[0]);
            try
            {
                var result2 = collection2.ThisDoesntMakeSense(p => p % 2 == 0, l =>
                {
                    IList<int> vs1 = new List<int>();
                    foreach (var item in l)
                    {
                        vs1.Add(item + 5);
                    }
                    return vs1;
                });

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
