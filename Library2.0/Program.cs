using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Library2._0
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model.Model model = new Model.Model();
            var MainForm = new MainForm();
            MainPresenter mainPresenter = new MainPresenter(model, MainForm);
            MainForm.presenter = mainPresenter;
            Application.Run(MainForm);
        }
    }
}
