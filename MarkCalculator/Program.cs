using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1;

namespace MarkCalculator
{
    class Program
    {
        static SQLAction sqlAction = new SQLAction("database.db");
        static void Main(string[] args)
        {
            start();

            write();

            Console.ReadKey();
        }

        private static void start()
        {
            List<Subject> subjects = new List<Subject>() { new Subject() { Name = "matematika" }, new Subject() { Name = "fyzika" }, new Subject() { Name = "chemie" } };

            sqlAction.CreateTables();

            sqlAction.AddSubject(subjects[0]);
            sqlAction.AddSubject(subjects[1]);
            sqlAction.AddSubject(subjects[2]);

            sqlAction.AddMark(new Mark() { Value = 1, Weight = 30 }, subjects[0]);
            sqlAction.AddMark(new Mark() { Value = 2, Weight = 30 }, subjects[1]);
            sqlAction.AddMark(new Mark() { Value = 1, Weight = 10 }, subjects[1]);
            sqlAction.AddMark(new Mark() { Value = 2, Weight = 20 }, subjects[0]);
            sqlAction.AddMark(new Mark() { Value = 3, Weight = 50 }, subjects[2]);
        }

        private static async void write()
        {
            var data = await sqlAction.GetMarks();

            foreach (Mark mark in data)
            {
                Console.WriteLine(mark.Value + "(" + mark.Weight + ")" + ";");
            }
        }
    }
}
