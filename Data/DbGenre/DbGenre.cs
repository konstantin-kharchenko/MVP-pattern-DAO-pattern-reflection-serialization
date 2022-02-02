using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbGenre
{
    public class DbGenre
    {
        public string connectionString;
        private static DbGenre instance;
        public List<Genre> genres;
        public DbGenre(string connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                genres = ReaderWriter.Read<List<Genre>>(connectionString);

            }
            catch
            {
                genres = new List<Genre>();
            }

        }
        public static void SetInstance(DbGenre dbGenre)
        {
            instance = dbGenre;
        }
        public static DbGenre GetInstance()
        {
            return instance;
        }
    }
}
