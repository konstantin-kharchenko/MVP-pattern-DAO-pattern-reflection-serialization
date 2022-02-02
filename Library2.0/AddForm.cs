using Business;
using Business.BusibessRules;
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
    public partial class AddForm : Form, IView
    {
        public AddForm(IPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }

        public IPresenter presenter { get; set; }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

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
            int zxf;
            if (int.TryParse(textBox4.Text,out zxf)&&Convert.ToInt32(textBox4.Text) > 0)
            {
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

                    Book book = new Book()
                    {
                        Name = textBox1.Text,
                        Description = textBox2.Text.Correct(),//метод расширения и исправление текста
                        TimePublications = Convert.ToDateTime(textBox3.Text),
                        Pages = Convert.ToInt32(textBox4.Text),
                        PagesRead = 0,
                        ImagePath = textBox8.Text,
                        Author_ID = AuthorID,
                        Genre_ID = GenreID
                    };
                    ((MainPresenter)presenter).model.dbBook.books.Add(book);
                    this.Close();
                }
                else label9.Text = "Все поля должны быть заполнены";
            }
            else label9.Text = "количество страниц должно быть неотрицательное";
        }



        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.BackColor = Color.White;
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.BackColor = Color.White;
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.BackColor = Color.White;
        }
        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.BackColor = Color.White;
        }
        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.BackColor = Color.White;
        }
        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.BackColor = Color.White;
        }
        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            textBox8.BackColor = Color.White;
        }
    }
}
