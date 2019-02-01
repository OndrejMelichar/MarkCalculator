using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace MarkCalculator
{
    class ConsoleApp
    {
        //* malá/velká písmena v psaní názvu předmětu
        private StudentBook studentBook = new StudentBook();

        public void Run()
        {
            while (true)
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
                    Console.Clear();
                    Console.Write("Název nového předmětu: ");
                    string subjectName = Console.ReadLine();
                    Console.Write("\n");

                    if (!this.studentBook.SubjectNameExists(subjectName.ToLower()))
                    {
                        this.studentBook.AddSubject(subjectName);
                    } else
                    {
                        Console.WriteLine("Tento předmět již existuje!");
                        this.pause();
                    }

                    
                    this.pause();
                    break;
                case "2":
                    Console.Clear();
                    if (this.studentBook.Subjects.Count != 0)
                    {
                        float mark = this.setValue();
                        int weight = this.setWeight();
                        Subject subject = this.setSubject();
                        this.studentBook.AddMark(mark, weight, subject);
                        this.pause();
                    } else {
                        Console.WriteLine("Nelze přidat novou známku, jelikož zatím nebyl zapsán žádný předmět!");
                        this.pause();
                    }
                    
                    break;
                case "3":
                    Console.Clear();
                    this.print();
                    this.pause();
                    break;
                case "4":
                    System.Environment.Exit(1);
                    break;
            }
        }

        private void pause()
        {
            Console.WriteLine("\n- - - - - - - -\nPro pokračování stiskněte enter.");
            Console.ReadKey();
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

                if (this.studentBook.SubjectNameExists(value.ToLower()))
                {
                    return new Subject() { Name = value.ToLower() };
                }
            }
        }

        private void print()
        {
            List<List<Mark>> marksBySubjects = this.studentBook.MarksBySubjects;

            if (marksBySubjects.Count != 0)
            {
                for (int i = 0; i < marksBySubjects.Count; i++)
                {
                    string subjectName = this.studentBook.Subjects[i].Name;
                    Console.Write(subjectName + ":");

                    foreach (Mark mark in marksBySubjects[i])
                    {
                        Console.Write(" " + mark.Value + " (" + mark.Weight + ");");
                    }

                    Console.Write("\n");
                }
            } else
            {
                Console.WriteLine("Nebyly nalezeny žádné předměty!");
            }
            
        }
    }
}
