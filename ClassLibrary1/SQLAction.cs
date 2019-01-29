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
        public List<Mark> Data { get; set; }

        public SQLAction(string databaseName)
        {
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), databaseName);
            var databasePath = databaseName;
            this.db = new SQLiteAsyncConnection(databasePath);
        }

        public async void Create()
        {
            await db.CreateTableAsync<Mark>();
        }

        public void Add(Mark mark)
        {
            db.InsertAsync(mark);
        }

        public async Task<List<Mark>> Query()
        {
            var query = db.Table<Mark>();
            return await query.ToListAsync();
        }

    }
}
