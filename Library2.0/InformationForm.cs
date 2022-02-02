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
    public partial class InformationForm : Form,IView
    {
        string name;

        public InformationForm(string Name, bool k, IPresenter presenter)
        {
            this.name = Name;
            this.presenter = presenter;
            InitializeComponent();
            textBox1.Lines = ((MainPresenter)presenter).model.Information(((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name));
            pictureBox2.Image = Image.FromFile(((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name).ImagePath);
            if (k)
            {
                trackBar1.Maximum = ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name).Pages;
                trackBar1.Value = ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name).PagesRead;
                progressBar1.Maximum = trackBar1.Maximum;
                progressBar1.Value = trackBar1.Value;
                label1.Text = trackBar1.Value.ToString();
                trackBar1.Visible = true;
                progressBar1.Visible = true;
                label1.Visible = true;
            }

        }

        public IPresenter presenter { get; set; }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            progressBar1.Value = trackBar1.Value;
            ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name).PagesRead = progressBar1.Value;
            textBox1.Lines = ((MainPresenter)presenter).model.Information(((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(name));
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(presenter, name);
            editForm.Activate();
            editForm.TopMost = true;
            editForm.ShowDialog();
            this.Close();
        }
    }
}
