using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.ViewModels.Dialogs
{
    public class AddWaitUCViewModel :BindableBase, IDialogAware
    {
        private string _Title = "添加待办事项";

        public string Title
        {
            get { return _Title; }
            set => SetProperty(ref _Title, value);
        }


        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
