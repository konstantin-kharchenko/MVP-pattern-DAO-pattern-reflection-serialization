using Business;
using Data.DbBook;
using Data.DbGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GenreDAO
    {
        public static DbGenre dbGenre = DbGenre.GetInstance();

        public Genre GetGenreByName(string GenreName)
        {
            return dbGenre.genres.Find(a => a.Name == GenreName);
        }

        public Genre GetGenreByID(string ID)
        {
            return dbGenre.genres.Find(a => a.ID == ID);
        }

        public string GetGenreIDByName(string Name)
        {
            foreach (var a in dbGenre.genres)
            {
                if (a.Name == Name) return a.ID;
            }
            return null;
        }

        public string GetGenreNameByID(string ID)
        {
            foreach (var a in dbGenre.genres)
            {
                if (a.ID == ID) return a.Name;
            }
            return null;
        }

        public bool Uniqueness(string Name)
        {
            foreach (var a in dbGenre.genres)
            {
                if (a.Name == Name) return false;
            }
            return true;
        }

    }
}
