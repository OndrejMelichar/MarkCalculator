using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace MarkCalculator
{
    class ConsoleApp
    {
        //* malá/velká písmena v psaní názvu předmětu
        private StudentBook studentBook;

        public void Run()
        {
            this.studentBook = new StudentBook();

            this.start();
            this.print();
        }

        private async void start()
        {
            /*List<Subject> subjects = new List<Subject>() { new Subject() { Name = "matematika" }, new Subject() { Name = "fyzika" }, new Subject() { Name = "chemie" } };

            await sqlAction.CreateTables();

            sqlAction.AddSubject(subjects[0]);
            sqlAction.AddSubject(subjects[1]);
            sqlAction.AddSubject(subjects[2]);

            sqlAction.AddMark(new Mark() { Value = 1, Weight = 30 }, subjects[0]);
            sqlAction.AddMark(new Mark() { Value = 2, Weight = 30 }, subjects[1]);
            sqlAction.AddMark(new Mark() { Value = 1, Weight = 10 }, subjects[1]);
            sqlAction.AddMark(new Mark() { Value = 2, Weight = 20 }, subjects[0]);
            sqlAction.AddMark(new Mark() { Value = 3, Weight = 50 }, subjects[2]);*/

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Vyberte akci:\n1) Přidat předmět\n2) Přidat znáku\n3) Vypsat známky\n4) Ukončit\n");
                string option = Console.ReadLine();
                this.processAction(option);
            }
            
        }

        private void processAction(string option)
        {
            switch (option)
            {
                case "1":
                    string subjectName = Console.ReadLine();
                    this.studentBook.AddSubject(subjectName);
                    break;
                case "2":
                    float mark = this.setValue();
                    int weight = this.setWeight();
                    Subject subject = this.setSubject();
                    this.studentBook.AddMark(mark, weight, subject);
                    break;
                case "3":
                    break;
                case "4":
                    System.Environment.Exit(1);
                    break;

            }
        }

        private float setValue()
        {
            float parsedValue;

            while (true)
            {
                Console.Clear();
                Console.Write("Vložte známku: ");
                string value = Console.ReadLine();
                Console.Write("\n");
                bool parse = float.TryParse(value, out parsedValue);

                if (parse && (parsedValue == 1f || parsedValue == 1.5f || parsedValue == 2f || parsedValue == 2.5f || parsedValue == 3f || parsedValue == 3.5f || parsedValue == 4f || parsedValue == 4.5f || parsedValue == 5f))
                {
                    return parsedValue;
                }
            }
        }

        private int setWeight()
        {
            int parsedValue;

            while (true)
            {
                Console.Clear();
                Console.Write("Vložte hodnotu známky: ");
                string value = Console.ReadLine();
                Console.Write("\n");
                bool parse = int.TryParse(value, out parsedValue);

                if (parse) //* ? více kontrol (popřípadě i v StudenBook!)
                {
                    return parsedValue;
                }
            }
        }

        private Subject setSubject()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Vložte název předmětu: ");
                string value = Console.ReadLine();
                Console.Write("\n");
                Subject subject = new Subject() { Name = value.ToLower() };

                if (this.studentBook.Subjects.Contains(subject))
                {
                    return subject;
                }
            }
        }

        private async void print()
        {
            /*var data = await sqlAction.GetMarks();

            foreach (Mark mark in data)
            {
                Console.WriteLine(mark.Value + "(" + mark.Weight + ")" + ";");
            }*/


        }
    }
}
