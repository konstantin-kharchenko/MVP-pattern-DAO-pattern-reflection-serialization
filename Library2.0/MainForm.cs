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
    public partial class MainForm : Form, IView
    {
        InformationForm newForm;
        public TreeView treeView, ParentTreeView;
        ToolStripMenuItem toolStripMenuItemByGenre;
        ToolStripMenuItem toolStripMenuItemByAuthor;
        ToolStripMenuItem toolStripMenuItemAdd;
        ToolStripMenuItem toolStripMenuItemRemove;
        ToolStripMenuItem toolStripMenuItemDefaolt;
        int index;
        string BookName;
        public MainForm()
        {
            InitializeComponent();

            toolStripMenuItemByGenre = new ToolStripMenuItem("По жанрам");
            toolStripMenuItemByAuthor = new ToolStripMenuItem("По автарам");
            toolStripMenuItemRemove = new ToolStripMenuItem("Удалить");
            toolStripMenuItemAdd = new ToolStripMenuItem("Добавить");
            toolStripMenuItemDefaolt = new ToolStripMenuItem("Весь список");
            
            toolStripMenuItemDefaolt.Click += ByDefaolt;

            toolStripMenuItemByGenre.Click += ByGanre;

            toolStripMenuItemByAuthor.Click += ByAuthor;

            toolStripMenuItemAdd.Click += AddBook;

            toolStripMenuItemRemove.Click += RemoveBook;

            contextMenuStrip1.Items.AddRange(new[] { toolStripMenuItemByGenre, toolStripMenuItemByAuthor, toolStripMenuItemAdd });



            

            //contextMenuStrip2 = contextMenuStrip1;
            //contextMenuStrip3 = contextMenuStrip1;
            //contextMenuStrip4 = contextMenuStrip1;

            treeView1.ContextMenuStrip = contextMenuStrip1;
            treeView2.ContextMenuStrip = contextMenuStrip1;
            treeView3.ContextMenuStrip = contextMenuStrip1;
            treeView4.ContextMenuStrip = contextMenuStrip1;
        }

        public IPresenter presenter { get; set; }

        private void RemoveBook(object sender, EventArgs e)
        {
            
            if (treeView.Equals(treeView1))
            {
                ((MainPresenter)presenter).model.dbBook.books.RemoveAt(index);
                treeView1.Nodes.RemoveAt(index);
            }
            else if (treeView.Equals(treeView2))
            {
                var a = ((MainPresenter)presenter).FindNode(BookName, treeView2);
                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(BookName).Property = Business.property.Nothing;
                treeView2.Nodes.Remove(a);
            }
            else if (treeView.Equals(treeView3))
            {
                var a = ((MainPresenter)presenter).FindNode(BookName, treeView3);
                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(BookName).Property = Business.property.Nothing;
                treeView3.Nodes.Remove(a);
            }
            else if (treeView.Equals(treeView4))
            {
                var a = ((MainPresenter)presenter).FindNode(BookName, treeView4);
                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(BookName).Property = Business.property.Nothing;
                treeView4.Nodes.Remove(a);
            }
        }

        private void AddBook(object sender, EventArgs e)
        {
            int i1 = ((MainPresenter)presenter).model.dbBook.books.Count;
            AddForm addForm = new AddForm(presenter);
            addForm.Activate();
            addForm.TopMost = true;
            addForm.ShowDialog();
            if (i1 != ((MainPresenter)presenter).model.dbBook.books.Count)
                treeView1.Nodes.Add(((MainPresenter)presenter).model.dbBook.books[((MainPresenter)presenter).model.dbBook.books.Count - 1].Name);
        }

        private void ByDefaolt(object sender, EventArgs e)
        {
            treeView.ContextMenuStrip.Items.Remove(toolStripMenuItemDefaolt);
            if (treeView.Equals(treeView1))
            {
                ((MainPresenter)presenter).Fill(treeView);
            }
            else if (treeView.Equals(treeView2))
            {
                ((MainPresenter)presenter).FillNotRead(treeView);
            }
            else if (treeView.Equals(treeView3))
            {
                ((MainPresenter)presenter).FillAwaiting(treeView);
            }
            else if (treeView.Equals(treeView4))
            {
                ((MainPresenter)presenter).FillRead(treeView);
            }
        }

        private void ByAuthor(object sender, EventArgs e)
        {
            treeView.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            if (treeView.Equals(treeView1))
            {
                ((MainPresenter)presenter).FillAuthorDefaolt(treeView);
            }
            else if (treeView.Equals(treeView2))
            {
                ((MainPresenter)presenter).FillAuthorNotRead(treeView);
            }
            else if (treeView.Equals(treeView3))
            {
                ((MainPresenter)presenter).FillAuthorAwaiting(treeView);
            }
            else if (treeView.Equals(treeView4))
            {
                ((MainPresenter)presenter).FillAuthorRead(treeView);
            }
        }

        private void ByGanre(object sender, EventArgs e)
        {
                treeView.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            if (treeView.Equals(treeView1))
            {
                ((MainPresenter)presenter).FillGanerDefaolt(treeView);
            }
            else if (treeView.Equals(treeView2))
            {
                ((MainPresenter)presenter).FillGanerNotRead(treeView);
            }
            else if (treeView.Equals(treeView3))
            {
                ((MainPresenter)presenter).FillGanerAwaiting(treeView);
            }
            else if (treeView.Equals(treeView4))
            {
                ((MainPresenter)presenter).FillGanerRead(treeView);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ((MainPresenter)presenter).Fill(treeView1);
            ((MainPresenter)presenter).FillNotRead(treeView2);
            ((MainPresenter)presenter).FillAwaiting(treeView3);
            ((MainPresenter)presenter).FillRead(treeView4);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ParentTreeView = treeView1;
            if (treeView1.Nodes.Count > 0) DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if(treeView1.Nodes[0].Nodes.Count==0) treeView1.ContextMenuStrip.Items.Remove(toolStripMenuItemDefaolt);
            else treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            treeView1.ContextMenuStrip.Items.Remove(toolStripMenuItemRemove);
            if (treeView1.ContextMenuStrip.Items.IndexOf(toolStripMenuItemAdd) == -1)
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
            treeView = treeView1;
            treeView1.Focus();
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            treeView = treeView1;
            if (newForm != null) newForm.Close();
            index = ((TreeView)sender).GetNodeAt(e.X, e.Y).Index;
            var b = ((TreeView)sender).GetNodeAt(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemRemove);
            }
            else
            {
                if (((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(b.Text)!=null)
                {
                    newForm = new InformationForm(b.Text, false, presenter);
                    newForm.Activate();
                    newForm.TopMost = true;
                    newForm.Show(this);

                }
            }
            treeView1.Focus();
            listBox1.Items.Clear();
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ParentTreeView = treeView2;
            if (treeView2.Nodes.Count > 0) DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            if (ParentTreeView.Equals(treeView1))
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    TreeNode treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    TreeNode treeNode1 = ((TreeView)sender).GetNodeAt(((TreeView)sender).PointToClient(new Point(e.X, e.Y)));
                    var zx = ((MainPresenter)presenter).Find(treeView3, treeNode.Text);
                    var zxx= ((MainPresenter)presenter).Find(treeView4, treeNode.Text);
                    if (zx == true && zxx == true)
                    {
                        if (treeNode1 != null)
                        {
                            int o = treeNode.Level;
                            if (treeNode.Level < 0)
                            {
                                treeNode1.Nodes.Add((TreeNode)treeNode.Clone());
                                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode1.Text).Property = Business.property.NotRead;
                                BookName = treeNode1.Text;
                                treeNode1.Expand();
                            }
                        }
                        else
                        {
                            TreeNode treeNode2 = new TreeNode(treeNode.Text);
                            if (((MainPresenter)presenter).Uniqueness(treeView2, treeNode2.Text))
                            {
                                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode2.Text).Property = Business.property.NotRead;
                                treeView2.Nodes.Add(treeNode2);
                                BookName = treeNode2.Text;
                                treeView2.ExpandAll();
                            }
                        }
                    }

                }
            }
        }

        private void treeView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView2_MouseClick(object sender, MouseEventArgs e)
        {
            treeView = treeView2;
            if (newForm != null) newForm.Close();
            index = ((TreeView)sender).GetNodeAt(e.X, e.Y).Index;
            var b = ((TreeView)sender).GetNodeAt(e.X, e.Y);
            BookName = b.Text;
            if (e.Button == MouseButtons.Right)
            {
                treeView2.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
                treeView2.ContextMenuStrip.Items.Add(toolStripMenuItemRemove);
            }
            else
            {
                if (((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(b.Text) != null)
                {
                    newForm = new InformationForm(b.Text, false, presenter);
                    newForm.Activate();
                    newForm.TopMost = true;
                    newForm.Show(this);

                }
            }
            treeView2.Focus();
            listBox1.Items.Clear();
        }

        private void treeView2_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (treeView2.Nodes.Count==0||treeView2.Nodes[0].Nodes.Count == 0) treeView2.ContextMenuStrip.Items.Remove(toolStripMenuItemDefaolt);
            else treeView2.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            treeView2.ContextMenuStrip.Items.Remove(toolStripMenuItemRemove);
            if (treeView2.ContextMenuStrip.Items.IndexOf(toolStripMenuItemAdd) == -1)
                treeView2.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
            treeView = treeView2;
            treeView1.Focus();
        }

        private void treeView3_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ParentTreeView = treeView3;
            if (treeView3.Nodes.Count > 0) DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView3_DragDrop(object sender, DragEventArgs e)
        {
            if (ParentTreeView.Equals(treeView2))
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    TreeNode treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    TreeNode treeNode1 = ((TreeView)sender).GetNodeAt(((TreeView)sender).PointToClient(new Point(e.X, e.Y)));
                    var zxx = ((MainPresenter)presenter).Find(treeView4, treeNode.Text);
                    if (zxx == true)
                    {
                        if (treeNode1 != null)
                        {
                            int o = treeNode.Level;
                            if (treeNode.Level < 0)
                            {
                                treeNode1.Nodes.Add((TreeNode)treeNode.Clone());
                                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode1.Text).Property = Business.property.Awaiting;
                                //((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode1.Text).NotRead = false;
                                treeView2.Nodes.Remove(treeNode);
                                BookName = treeNode1.Text;
                                treeView3.ExpandAll();
                            }
                        }
                        else
                        {
                            TreeNode treeNode2 = new TreeNode(treeNode.Text);
                            if (((MainPresenter)presenter).Uniqueness(treeView3, treeNode2.Text))
                            {
                                ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode2.Text).Property = Business.property.Awaiting;
                                //((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode2.Text).NotRead = false;
                                treeView3.Nodes.Add(treeNode2);
                                BookName = treeNode2.Text;
                                treeView2.Nodes.Remove(treeNode);
                                treeView3.ExpandAll();
                            }
                        }
                    }
                }
            }
        }

        private void treeView3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView3_MouseClick(object sender, MouseEventArgs e)
        {
            treeView = treeView3;
            if (newForm != null) newForm.Close();
            index = ((TreeView)sender).GetNodeAt(e.X, e.Y).Index;
            var b = ((TreeView)sender).GetNodeAt(e.X, e.Y);
            BookName = b.Text;
            if (e.Button == MouseButtons.Right)
            {
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemRemove);
            }
            else
            {
                if (((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(b.Text) != null)
                {
                    newForm = new InformationForm(b.Text, true, presenter);
                    newForm.Activate();
                    newForm.TopMost = true;
                    newForm.Show(this);

                }
            }
            treeView1.Focus();
            listBox1.Items.Clear();
        }

        private void treeView3_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (treeView3.Nodes.Count == 0 || treeView3.Nodes[0].Nodes.Count == 0) treeView3.ContextMenuStrip.Items.Remove(toolStripMenuItemDefaolt);
            else treeView3.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            treeView3.ContextMenuStrip.Items.Remove(toolStripMenuItemRemove);
            if (treeView3.ContextMenuStrip.Items.IndexOf(toolStripMenuItemAdd) == -1)
                treeView3.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
            treeView = treeView3;
            treeView1.Focus();
        }

        private void treeView4_DragDrop(object sender, DragEventArgs e)
        {

            if (ParentTreeView.Equals(treeView3))
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    TreeNode treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    TreeNode treeNode1 = ((TreeView)sender).GetNodeAt(((TreeView)sender).PointToClient(new Point(e.X, e.Y)));
                    if (treeNode1 != null)
                    {
                        int o = treeNode.Level;
                        if (treeNode.Level < 0)
                        {
                            treeNode1.Nodes.Add((TreeNode)treeNode.Clone());
                            ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode1.Text).Property = Business.property.Read;
                            //((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode1.Text).Awaiting = false;
                            treeView3.Nodes.Remove(treeNode);
                            BookName = treeNode1.Text;
                            treeNode1.Expand();
                        }
                    }
                    else
                    {
                        TreeNode treeNode2 = new TreeNode(treeNode.Text);
                        if (((MainPresenter)presenter).Uniqueness(treeView4, treeNode2.Text))
                        {
                            ((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode2.Text).Property = Business.property.Read;
                            //((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(treeNode2.Text).Awaiting = false;
                            treeView4.Nodes.Add(treeNode2);
                            treeView3.Nodes.Remove(treeNode);
                            BookName = treeNode2.Text;
                            treeView4.ExpandAll();
                        }
                    }
                }
            }
        }

        private void treeView4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView4_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ParentTreeView = treeView4;
            if (treeView4.Nodes.Count > 0) DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView4_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (treeView4.Nodes.Count == 0 || treeView4.Nodes[0].Nodes.Count == 0) treeView4.ContextMenuStrip.Items.Remove(toolStripMenuItemDefaolt);
            else treeView4.ContextMenuStrip.Items.Add(toolStripMenuItemDefaolt);
            treeView4.ContextMenuStrip.Items.Remove(toolStripMenuItemRemove);
            if (treeView4.ContextMenuStrip.Items.IndexOf(toolStripMenuItemAdd) == -1)
                treeView4.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
            treeView = treeView4;
            treeView1.Focus();
        }

        private void treeView4_MouseClick(object sender, MouseEventArgs e)
        {
            treeView = treeView4;
            if (newForm != null) newForm.Close();
            index = ((TreeView)sender).GetNodeAt(e.X, e.Y).Index;
            var b = ((TreeView)sender).GetNodeAt(e.X, e.Y);
            BookName = b.Text;
            if (e.Button == MouseButtons.Right)
            {
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemAdd);
                treeView1.ContextMenuStrip.Items.Add(toolStripMenuItemRemove);
            }
            else
            {
                if (((MainPresenter)presenter).model.GetBooksDAO().FindBookByName(b.Text) != null)
                {
                    newForm = new InformationForm(b.Text, false, presenter);
                    newForm.Activate();
                    newForm.TopMost = true;
                    newForm.Show(this);

                }
            }
            treeView1.Focus();
            listBox1.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string nn = ((TextBox)sender).Text;
            List<Book> a;
            if(listBox2.SelectedItem==null||listBox2.SelectedItem.ToString()=="Весь список" )
                a = ((MainPresenter)presenter).model.SmartSearch(nn);
            else if(listBox2.SelectedItem.ToString() == "По авторам")
                a = ((MainPresenter)presenter).model.SmartSearchByAuthor(nn);
            else 
                a = ((MainPresenter)presenter).model.SmartSearchByGenre(nn);
            foreach (var b in a)
            {
                listBox1.Items.Add(b.Name);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainPresenter)presenter).model.GetBooksDAO().Save();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.SelectedNode = ((MainPresenter)presenter).FindNode(listBox1.SelectedItem.ToString(), treeView1);
            treeView1.Focus();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1_TextChanged(sender, e);
        }
    }
}
