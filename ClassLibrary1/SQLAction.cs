using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SQLAction
    {
        private SQLiteAsyncConnection db;

        public SQLAction(string databaseName)
        {
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), databaseName);
            var databasePath = databaseName;
            this.db = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTables()
        {
            await db.CreateTableAsync<Mark>();
            await db.CreateTableAsync<Subject>();
            await db.CreateTableAsync<Binding>();
        }

        public async Task<List<Mark>> GetMarks()
        {
            var query = db.Table<Mark>();
            return await query.ToListAsync();
        }

        public async Task<List<Mark>> GetMarks(Subject subject)
        {
            int subjectId = await this.getSubjectId(subject);
            List<int> bindingIds = await this.getMarkIds(subjectId);

            List<Mark> marks = new List<Mark>();

            foreach (int bindingId in bindingIds)
            {
                var query = db.Table<Mark>().Where(v => v.MarkId.Equals(bindingId));
                var result = await query.ToListAsync();
                marks.AddRange(result);
            }

            return marks;
        }

        public async void AddMark(Mark mark, Subject subject)
        {
            int newMarkId = await db.InsertAsync(mark);
            int subjectId = await this.getSubjectId(subject);

            await db.InsertAsync(new Binding() { SubjectId = subjectId, MarkId = newMarkId });
        }

        public async void AddSubject(Subject subject)
        {
            await db.InsertAsync(subject);
        }

        private async Task<int> getSubjectId(Subject subject)
        {
            var query = db.Table<Subject>().Where(v => v.Name.Equals(subject.Name));
            var data = await query.ToListAsync();

            if (data.Count == 1)
            {
                return data[0].SubjectId;
            } else
            {
                //chyba ve čtení databáze (? - vzít první, pokud vůbec existuje) //*
                return 0;
            }
        }

        private async Task<List<int>> getMarkIds(int subjectId)
        {
            var query = db.Table<Binding>().Where(v => v.SubjectId.Equals(subjectId));
            var data = await query.ToListAsync();

            List<int> ids = new List<int>();

            foreach (Binding value in data)
            {
                ids.Add(value.MarkId);
            }

            return ids;
        }

    }
}
