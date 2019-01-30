using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClassLibrary1
{
    class Binding
    {
        [PrimaryKey, AutoIncrement]
        public int BindingId { get; set; }
        public int SubjectId { get; set; }
        public int MarkId { get; set; }
    }
}
