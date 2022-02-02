using Business;
using DAO;
using Data.DbAuthor;
using Data.DbBook;
using Data.DbGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel
    {
        DbBook dbBook { get; set; }

        DbGenre dbGenre { get; set; }

        DbAuthor dbAuthor { get; set; }

        BookDAO GetBooksDAO();

        List<Book> SmartSearch(string Name);

        List<Book> SmartSearchByAuthor(string Name);

        List<Book> SmartSearchByGenre(string Name);

        int GetNotReadBooksCountByAuthor(string NameAuthor);

        int GetReadBooksCountByAuthor(string NameAuthor);

        int GetAwaitingBooksCountByAuthor(string NameAuthor);

        int GetNotReadBooksCountByGenre(string NameAuthor);

        int GetReadBooksCountByGenre(string NameAuthor);

        int GetAwaitingBooksCountByGenre(string NameAuthor);

        string[] Information(Book book);
    }
}
