using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
namespace Data.DbBook
{
    public class DbBook
    {
        public string connectionString;
        private static DbBook instance;
        public List<Book> books;
        public DbBook(string connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                books = ReaderWriter.Read<List<Book>>(connectionString);

            }
            catch
            {
                books = new List<Book>();
            }

        }
        public static void SetInstance(DbBook dbBook)
        {
            instance = dbBook;
        }
        public static DbBook GetInstance()
        {
            return instance;
        }
    }
}
