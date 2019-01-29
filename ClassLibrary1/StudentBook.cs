using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClassLibrary1
{
    class StudentBook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<Mark> Math { get; set; }
        public List<Mark> Physics { get; set; }
        public List<Mark> Biology { get; set; }
    }
}
