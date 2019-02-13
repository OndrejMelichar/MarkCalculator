using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class StudentBook
    {
        private SQLAction sqlAction;
        public List<Subject> Subjects { get; set; }
        public List<List<Mark>> MarksBySubjects { get; set; }

        public bool Ready = false;

        public StudentBook(SQLAction sqlAction)
        {
            this.sqlAction = sqlAction;
            this.setData();
        }
        private async void setData()
        {
            await this.loadSubjects();
            await this.loadMarks();
        }

        private async Task loadSubjects()
        {
            this.Subjects = new List<Subject>(await this.sqlAction.GetSubjects());
        }

        private async Task loadMarks()
        {
            this.MarksBySubjects = new List<List<Mark>>();

            if (this.Subjects != null && this.Subjects.Count > 0) //* je to nutné (celé)
            {
                foreach (Subject subject in this.Subjects)
                {
                    List<Mark> subjectMarks = await this.sqlAction.GetMarks(subject);
                    this.MarksBySubjects.Add(subjectMarks);
                }
            }

            this.Ready = true;
        }

        public void AddSubject(string subjectName)
        {
            Subject newSubject = new Subject() { Name = subjectName.ToLower() };
            this.Subjects.Add(newSubject);
            this.MarksBySubjects.Add(new List<Mark>());
            this.sqlAction.AddSubject(newSubject);
        }

        public void AddMark(float value, int weight, Subject subject)
        {
            Mark newMark = new Mark() { Value = value, Weight = weight };

            int subjectIndex = this.SubjectNameIndex(subject.Name);
            this.MarksBySubjects[subjectIndex].Add(newMark);

            this.sqlAction.AddMark(newMark, subject);
        }

        private bool checkMarkValue(float mark)
        {
            if (mark == 1f || mark == 1.5f || mark == 2f || mark == 2.5f || mark == 3f || mark == 3.5f || mark == 4f || mark == 4.5f || mark == 5f)
            {
                return true;
            }

            return false;
        }

        public bool SubjectNameExists(string name)
        {
            foreach (Subject subject in this.Subjects)
            {
                if (subject.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public int SubjectNameIndex(string name)
        {
            for (int i=0; i < this.Subjects.Count; i++)
            {
                if (this.Subjects[i].Name == name)
                {
                    return i;
                }
            }

            return 0;
        }

        public float GetMarksAverage(List<Mark> marks)
        {
            float marksWeightsSum = 0;
            int weightsSum = 0;

            foreach (Mark mark in marks)
            {
                marksWeightsSum += mark.Value * mark.Weight;
                weightsSum += mark.Weight;
            }

            if (marks.Count != 0)
            {
                return marksWeightsSum / weightsSum;
            } else
            {
                return 0;
            }
            
        }
    }
}
