﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class StudentBook
    {
        public List<Subject> Subjects { get; set; }
        public List<List<Mark>> MarksBySubjects { get; set; }
        private SQLAction sqlAction = new SQLAction("database.db");

        public StudentBook()
        {
            this.setSubjects();
        }

        private async void setSubjects()
        {
            this.Subjects = new List<Subject>(await this.sqlAction.GetSubjects());
        }

        private async void setMarks()
        {
            this.MarksBySubjects = new List<List<Mark>>();

            foreach (Subject subject in this.Subjects)
            {
                List<Mark> subjectMarks = await this.sqlAction.GetMarks(subject);
                this.MarksBySubjects.Add(subjectMarks);
            }

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
            if (this.checkMarkValue(value) && this.Subjects.Contains(subject))
            {
                Mark newMark = new Mark() { Value = value, Weight = weight };

                int subjectIndex = this.Subjects.IndexOf(subject);
                this.MarksBySubjects[subjectIndex].Add(newMark);

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
