using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class StudentBook
    {
        public List<Subject> Subjects { get; set; }
        public List<Mark> Marks { get; set; }
        private SQLAction sqlAction = new SQLAction("database.db");

        public StudentBook()
        {
            this.Subjects = new List<Subject>();
            this.Marks = new List<Mark>();

            //nahrát data z DB do těchto Listů
        }

        public void AddSubject(string subjectName)
        {
            Subject newSubject = new Subject() { Name = subjectName.ToLower() };

            if (!this.Subjects.Contains(newSubject))
            {
                this.Subjects.Add(newSubject);
                this.sqlAction.AddSubject(newSubject);
            }
        }

        public void AddMark(int value, int weight, Subject subject)
        {
            Mark newMark = new Mark() { Value = value, Weight = weight };
            this.Marks.Add(newMark);
            this.sqlAction.AddMark(newMark, subject);
        }
    }
}
