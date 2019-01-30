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
           
            /*sqlAction.Create();

            x();

            Console.ReadKey();*/
        }

        static private async void x()
        {
            /*foreach (Mark item in await sqlAction.Query())
            {
                Console.WriteLine(item.Value + "(" + item.Weight + ")" + ";");
            }*/
        }
    }
}
