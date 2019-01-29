using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClassLibrary1
{
    public class Synapse
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SynapseId { get; set; }
    }
}
