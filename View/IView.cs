using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;
namespace View
{
    public interface IView
    {
        IPresenter presenter { get; set; }
    }
}