using Business;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Presenter
{
    public class MainPresenter: IPresenter
    {
        public IModel model;
        public IView view;
        public MainPresenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public TreeNode FindNode(string name, TreeView treeView)
        {
            foreach (TreeNode a in treeView.Nodes)
            {
                if (a.Text == name) return a;
            }
            return null;
        }

        public void FillImage(ImageList imageList)
        {
            foreach (var a in model.dbBook.books)
                imageList.Images.Add(Image.FromFile(a.ImagePath));
        }

        public void Fill(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            foreach (var a in model.dbBook.books)
            {
                TreeNode treeNode = new TreeNode(a.Name);
                treeView.Nodes.Add(treeNode);
            }
        }

        public void FillNotRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            foreach (var a in model.dbBook.books)
            {
                if (a.Property==property.NotRead)
                {
                    TreeNode treeNode = new TreeNode(a.Name);
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillAwaiting(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            foreach (var a in model.dbBook.books)
            {
                if (a.Property==property.Awaiting)
                {
                    TreeNode treeNode = new TreeNode(a.Name);
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            foreach (var a in model.dbBook.books)
            {
                if (a.Property==property.Read)
                {
                    TreeNode treeNode = new TreeNode(a.Name);
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public bool Uniqueness(TreeView treeView, string nodeName)
        {
            foreach (TreeNode a in treeView.Nodes)
            {
                if (a.Text == nodeName) return false;
            }
            return true;
        }

        public void FillAuthorDefaolt(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetAuthors();
            foreach (IGrouping<string, Book> b in a)
            {
                var c = model.GetBooksDAO().authorDAO.GetAuthorByID(b.Key);
                TreeNode treeNode = new TreeNode(c.Name);
                foreach (var d in b)
                {
                    TreeNode treeNode2 = new TreeNode(d.Name);
                    treeNode.Nodes.Add(treeNode2);
                }
                treeView.Nodes.Add(treeNode);
            }
        }

        public void FillGanerDefaolt(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetGanres();

            foreach (IGrouping<string, Book> b in a)
            {
                var c = model.GetBooksDAO().genreDAO.GetGenreByID(b.Key);
                TreeNode treeNode = new TreeNode(c.Name);
                foreach (var d in b)
                {
                    TreeNode treeNode2 = new TreeNode(d.Name);
                    treeNode.Nodes.Add(treeNode2);
                }
                treeView.Nodes.Add(treeNode);
            }
        }

        public void FillAuthorNotRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetAuthors();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetNotReadBooksCountByAuthor(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().authorDAO.GetAuthorByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.NotRead)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillGanerNotRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetGanres();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetNotReadBooksCountByGenre(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().genreDAO.GetGenreByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.NotRead)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillAuthorAwaiting(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetAuthors();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetAwaitingBooksCountByAuthor(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().authorDAO.GetAuthorByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.Awaiting)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillGanerAwaiting(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetGanres();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetAwaitingBooksCountByGenre(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().genreDAO.GetGenreByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.Awaiting)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillAuthorRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetAuthors();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetReadBooksCountByAuthor(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().authorDAO.GetAuthorByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.Read)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public void FillGanerRead(TreeView treeView)//для чтения в treeView
        {
            treeView.Nodes.Clear();
            var a = model.GetBooksDAO().GetGanres();
            foreach (IGrouping<string, Book> b in a)
            {
                if (model.GetBooksDAO().GetReadBooksCountByGenre(b.Key) != 0)
                {
                    var c = model.GetBooksDAO().genreDAO.GetGenreByID(b.Key);
                    TreeNode treeNode = new TreeNode(c.Name);
                    foreach (var d in b)
                    {
                        if (d.Property==property.Read)
                        {
                            TreeNode treeNode2 = new TreeNode(d.Name);
                            treeNode.Nodes.Add(treeNode2);
                        }
                    }
                    treeView.Nodes.Add(treeNode);
                }
            }
        }

        public bool Find(TreeView treeView, string Text)
        {
            foreach(TreeNode a in treeView.Nodes)
            {
                if (a.Text == Text) return false;
            }
            return true;
        }

        public void Save()
        {
            ReaderWriter.Write<List<Book>>(model.dbBook.connectionString, model.dbBook.books);
            ReaderWriter.Write<List<Author>>(model.dbAuthor.connectionString, model.dbAuthor.authors);
            ReaderWriter.Write<List<Genre>>(model.dbGenre.connectionString, model.dbGenre.genres);
        }

    }
}
