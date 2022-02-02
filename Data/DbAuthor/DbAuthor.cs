using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbAuthor
{
    public class DbAuthor
    {
        public string connectionString;
        private static DbAuthor instance;
        public List<Author> authors;
        public DbAuthor(string connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                authors = ReaderWriter.Read<List<Author>>(connectionString);

            }
            catch
            {
                authors = new List<Author>();
            }

        }
        public static void SetInstance(DbAuthor dbAuthor)
        {
            instance = dbAuthor;
        }
        public static DbAuthor GetInstance()
        {
            return instance;
        }
    }
}
