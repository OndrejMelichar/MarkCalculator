using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1;

namespace MarkCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp();
            await app.Run();

            Console.ReadKey();
        }

        
    }
}
