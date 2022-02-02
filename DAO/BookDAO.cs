using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DbBook;
using Business;
using Data.DbAuthor;
using Data.DbGenre;

namespace DAO
{
    public class BookDAO
    {
        static DbBook dbBook = DbBook.GetInstance();

        public AuthorDAO authorDAO;

        public GenreDAO genreDAO;

        public BookDAO()
        {
            authorDAO = new AuthorDAO();

            genreDAO = new GenreDAO();
        }

        public Book FindBookByName(string BookName)
        {
            foreach (var a in dbBook.books)
            {
                if (a.Name == BookName) return a;
            }
            return null;
        }

        public Book NewBook()
        {
            return new Book();
        }

        public IEnumerable<IGrouping<string, Book>> GetAuthors()
        {
            return from book in dbBook.books group book by book.Author_ID;
        }

        public IEnumerable<IGrouping<string, Book>> GetGanres()
        {
            return from book in dbBook.books group book by book.Genre_ID;
        }

        public void SortByDate()
        {
            dbBook.books.Sort((x, y) => x.TimePublications.CompareTo(y.TimePublications));
        }

        public List<Book> GetBooksByAuthor(string ID)
        {
            List<Book> a = dbBook.books.FindAll((Book b) => ID==b.Author_ID);
            return a;
        }

        public int GetNotReadBooksCountByAuthor(string ID)
        {
            return dbBook.books.Count((a) => a.Author_ID == ID && a.Property == property.NotRead);
        }

        public int GetReadBooksCountByAuthor(string ID)
        {
            return dbBook.books.Count((a) => a.Author_ID == ID && a.Property == property.Read);
        }

        public int GetAwaitingBooksCountByAuthor(string ID)
        {
            return dbBook.books.Count((a) => a.Author_ID == ID && a.Property == property.Awaiting);
        }

        public List<Book> GetBooksByGaner(string ID)
        {
            List<Book> a = dbBook.books.FindAll((Book b) => ID == b.Genre_ID);
            return a;
        }

        public int GetNotReadBooksCountByGenre(string ID)
        {
            return dbBook.books.Count((a) => a.Genre_ID == ID && a.Property==property.NotRead);
        }

        public int GetReadBooksCountByGenre(string ID)
        {
            return dbBook.books.Count((a) => a.Genre_ID == ID && a.Property==property.Read);
        }

        public int GetAwaitingBooksCountByGenre(string ID)
        {
            return dbBook.books.Count((a) => a.Genre_ID == ID && a.Property==property.Awaiting);
        }

        public void Save() {
            ReaderWriter.Write(dbBook.connectionString, dbBook.books);
            ReaderWriter.Write(AuthorDAO.dbAuthor.connectionString, AuthorDAO.dbAuthor.authors);
            ReaderWriter.Write(GenreDAO.dbGenre.connectionString, GenreDAO.dbGenre.genres);
        }
    }
}
