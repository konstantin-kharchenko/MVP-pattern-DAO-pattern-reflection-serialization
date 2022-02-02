using Business;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Library2._0
{
    public partial class EditForm : Form, IView
    {
        Book book;
        public EditForm(IPresenter presenter, string bookName)
        {
            InitializeComponent();
            this.presenter = presenter;
            book = ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(bookName);
            textBox1.Text = book.Name;
            textBox2.Text = book.Description;
            textBox3.Text = book.TimePublications.ToString();
            textBox4.Text = book.Pages.ToString();
            textBox5.Text = ((MainPresenter)presenter).model.GetBooksDAO().authorDAO.GetAuthorByID(book.Author_ID).Name;  //book.Author_.Name;
            textBox6.Text = ((MainPresenter)presenter).model.GetBooksDAO().authorDAO.GetAuthorByID(book.Author_ID).Description;//book.Author_.Description;
            textBox7.Text = ((MainPresenter)presenter).model.GetBooksDAO().genreDAO.GetGenreByID(book.Genre_ID).Name; //book.Genre_.Name;
            textBox8.Text = book.ImagePath;
        }

        public IPresenter presenter { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.BackColor = Color.Red;
            if (textBox2.Text == "") textBox2.BackColor = Color.Red;
            if (textBox3.Text == "") textBox3.BackColor = Color.Red;
            if (textBox4.Text == "") textBox4.BackColor = Color.Red;
            if (textBox5.Text == "") textBox5.BackColor = Color.Red;
            if (textBox6.Text == "") textBox6.BackColor = Color.Red;
            if (textBox7.Text == "") textBox7.BackColor = Color.Red;
            if (textBox8.Text == "") textBox8.BackColor = Color.Red;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" &&
                textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                string GenreID, AuthorID;
                if (((MainPresenter)presenter).model.GetBooksDAO().genreDAO.Uniqueness(textBox7.Text))
                {
                    ((MainPresenter)presenter).model.dbGenre.genres.Add(new Genre()
                    {
                        Name = textBox7.Text,
                        ID = (Convert.ToInt32(((MainPresenter)presenter).model.dbGenre.genres[((MainPresenter)presenter).model.dbGenre.genres.Count - 1].ID) - 47).ToString()
                        ,
                        Description = ""
                    });
                    GenreID = ((MainPresenter)presenter).model.dbGenre.genres[((MainPresenter)presenter).model.dbGenre.genres.Count - 1].ID;
                }
                else
                {
                    GenreID = ((MainPresenter)presenter).model.GetBooksDAO().genreDAO.GetGenreIDByName(textBox7.Text);
                }
                if (((MainPresenter)presenter).model.GetBooksDAO().authorDAO.Uniqueness(textBox5.Text))
                {
                    ((MainPresenter)presenter).model.dbAuthor.authors.Add(new Author()
                    {
                        Name = textBox5.Text,
                        ID =
                        (Convert.ToInt32(((MainPresenter)presenter).model.dbAuthor.authors[((MainPresenter)presenter).model.dbAuthor.authors.Count - 1].ID) - 47).ToString(),
                        Description = textBox6.Text
                    });
                    AuthorID = ((MainPresenter)presenter).model.dbAuthor.authors[((MainPresenter)presenter).model.dbAuthor.authors.Count - 1].ID;
                }
                else
                {
                    AuthorID = ((MainPresenter)presenter).model.GetBooksDAO().authorDAO.GetAuthorIDByName(textBox5.Text);

                }
                book.Name=textBox1.Text;
                book.Description=textBox2.Text;
                book.TimePublications=Convert.ToDateTime(textBox3.Text);
                book.Pages=Convert.ToInt32(textBox4.Text);
                book.Author_ID = AuthorID;
                book.Genre_ID = GenreID;
                ((MainPresenter)presenter).model.GetBooksDAO().authorDAO.GetAuthorByID(book.Author_ID).Description=textBox6.Text;
                book.ImagePath=textBox8.Text;
                this.Close();
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
