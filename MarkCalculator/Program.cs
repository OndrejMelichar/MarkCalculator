using System;
using System.Threading.Tasks;
using ClassLibrary1;

namespace MarkCalculator
{
    class Program
    {
        static SQLAction sqlAction = new SQLAction("database.db");
        static void Main(string[] args)
        {
           
            sqlAction.Create();
            sqlAction.Add(new Mark() { Value = 2, Weight = 30 });

            x();

            Console.ReadKey();
        }

        static private async void x()
        {
            foreach (var item in await sqlAction.Query())
            {
                Console.WriteLine(item.Value + "(" + item.Weight + ")" + ";");
            }
        }
    }
}
