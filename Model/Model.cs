using DAO;
using Data.DbBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Data.DbGenre;
using Data.DbAuthor;

namespace Model
{
    public class Model : IModel
    {
        BookDAO bookDAO;

        public DbBook dbBook { get; set; }

        public DbGenre dbGenre { get; set; }

        public DbAuthor dbAuthor { get; set; }

        public Model()
        {
            dbBook = new DbBook(Properties.Path.String1);
            DbBook.SetInstance(dbBook);

            dbAuthor = new DbAuthor(Properties.Path.String2);
            DbAuthor.SetInstance(dbAuthor);

            dbGenre = new DbGenre(Properties.Path.String3);
            DbGenre.SetInstance(dbGenre);

            bookDAO = new BookDAO();
        }

        public BookDAO GetBooksDAO()
        {
            return bookDAO;
        }

        public List<Book> SmartSearch(string Name)
        {
            int length = Name.Length;
            List<Book> book = new List<Book>();
            foreach (var a in dbBook.books)
            {
                if (a.Name.Length >= length)
                {
                    string b = (a.Name.Substring(0, length)).ToLower();
                    Name = Name.ToLower();
                    if (b == Name) book.Add(a);
                }
            }
            return book;
        }

        public List<Book> SmartSearchByAuthor(string Name)
        {
            int length = Name.Length;
            var z = dbAuthor.authors;
            List<Book> book = new List<Book>();
            Name = Name.ToLower();
            foreach(var a in z)
            {
                if (a.Name.Length >= length)
                {
                    var q = (a.Name.Substring(0, length)).ToLower();
                    if (Name == q)
                    {
                        foreach (var e in dbBook.books)
                        {
                            if (e.Author_ID == a.ID) book.Add(e);
                        }
                    }
                }
            }
            return book;
        }

        public List<Book> SmartSearchByGenre(string Name)
        {
            int length = Name.Length;
            var z = dbGenre.genres;
            List<Book> book = new List<Book>();
            Name = Name.ToLower();
            foreach (var a in z)
            {
                if (a.Name.Length >= length)
                {
                    var q = (a.Name.Substring(0, length)).ToLower();
                    if (Name == q)
                    {
                        foreach (var e in dbBook.books)
                        {
                            if (e.Genre_ID == a.ID) book.Add(e);
                        }
                    }
                }
            }
            return book;
        }

        public int GetNotReadBooksCountByAuthor(string NameAuthor)
        {
            return bookDAO.GetNotReadBooksCountByAuthor(NameAuthor);
        }

        public int GetReadBooksCountByAuthor(string NameAuthor)
        {
            return bookDAO.GetReadBooksCountByAuthor(NameAuthor);
        }

        public int GetAwaitingBooksCountByAuthor(string NameAuthor)
        {
            return bookDAO.GetAwaitingBooksCountByAuthor(NameAuthor);
        }

        public int GetNotReadBooksCountByGenre(string NameAuthor)
        {
            return bookDAO.GetNotReadBooksCountByGenre(NameAuthor);
        }

        public int GetReadBooksCountByGenre(string NameAuthor)
        {
            return bookDAO.GetReadBooksCountByGenre(NameAuthor);
        }

        public int GetAwaitingBooksCountByGenre(string NameAuthor)
        {
            return bookDAO.GetAwaitingBooksCountByGenre(NameAuthor);
        }

        public string[] Information(Book book)
        {
            var a = bookDAO.genreDAO.GetGenreByID(book.Genre_ID);
            var b = bookDAO.authorDAO.GetAuthorByID(book.Author_ID);
            return new string[] {
                 "Название книги: " + book.Name + '\n',
                 "Описание книги: " + book.Description + "\n" ,
                 "Дата публикации: " + book.TimePublications.Date.ToShortDateString() + "\n" ,
                 "Количество страниц: " + book.Pages + "\n" ,
                 "Количество прочитанных страниц: " + book.PagesRead + "\n" ,
                 "Жанр: " + a.Name + "\n" ,
                 "Автор: " + b.Name + "\n" ,
                 "Биография: " + b.Description
            };
        }

    }
}
