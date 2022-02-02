using Business;
using Data.DbAuthor;
using Data.DbBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAO
{
    public class AuthorDAO
    {
        public static DbAuthor dbAuthor = DbAuthor.GetInstance();

        public Author GetAuthorByName(string AuthorName)
        {
            return dbAuthor.authors.Find(a => a.Name == AuthorName);
        }

        public Author GetAuthorByID(string ID)
        {
            return dbAuthor.authors.Find(a => a.ID == ID);
        }

        public string GetAuthorIDByName(string Name)
        {
            foreach (var a in dbAuthor.authors)
            {
                if (a.Name == Name) return a.ID;
            }
            return null;
        }

        public string GetAuthorNameByID(string ID)
        {
            foreach (var a in dbAuthor.authors)
            {
                if (a.ID == ID) return a.Name;
            }
            return null;
        }

        public bool Uniqueness(string Name)
        {
            foreach (var a in dbAuthor.authors)
            {
                if (a.Name == Name) return false;
            }
            return true;
        }

        public List<Author> GetAuthors()
        {
            return dbAuthor.authors;
        }
    }
}
