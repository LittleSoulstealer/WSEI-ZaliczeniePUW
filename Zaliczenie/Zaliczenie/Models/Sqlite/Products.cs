using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zaliczenie.Models.Sqlite
{
    public class Products : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Cup { get; set; }
        public int BSpoon { get; set; }
        public int SSpoon { get; set; }
    }
}
