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
            this.Marks = new List<Mark>(); //* jak?

            //nahrát data z DB do těchto Listů
        }

        public void AddSubject(string subjectName)
        {
            Subject newSubject = new Subject() { Name = subjectName.ToLower() };

            if (!this.Subjects.Contains(newSubject))
            {
                this.Subjects.Add(newSubject);
                this.sqlAction.AddSubject(newSubject);
            } else
            {
                //*
            }
        }

        public void AddMark(float value, int weight, Subject subject)
        {
            if (this.checkMarkValue(value))
            {
                Mark newMark = new Mark() { Value = value, Weight = weight };
                this.Marks.Add(newMark);
                this.sqlAction.AddMark(newMark, subject);
            } else
            {
                //*
            }
            
        }

        private bool checkMarkValue(float mark)
        {
            if (mark == 1f || mark == 1.5f || mark == 2f || mark == 2.5f || mark == 3f || mark == 3.5f || mark == 4f || mark == 4.5f || mark == 5f)
            {
                return true;
            }

            return false;
        }
    }
}
