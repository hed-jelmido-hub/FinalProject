using FinalProject.Models;

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Databasecontext
{
    public class DatabaseContext
    {
        private readonly SQLiteConnection _db;

        
        public DatabaseContext(string dbPath)
        {
            
            _db = new SQLiteConnection(dbPath);

            
            _db.CreateTable<Student>();
        }

       
        public SQLiteConnection Connection => _db;
    }
}
